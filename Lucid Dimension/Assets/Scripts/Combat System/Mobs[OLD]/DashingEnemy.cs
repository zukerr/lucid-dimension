using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashingEnemy : Alive {
    [Space]
    [Header("Dashing Enemy Properties")]
    public float radiusFromPlayer=1f;
    [Range(0, 1)]
    public float speed;
    public float dashCastTime;
    [Range(0,0.5f)]
    public float dashDelta;

    Transform player;
    bool isDashing;

    public override void SetupDeck()
    {
        // ???
    }
    
    // Use this for initialization
    public override void Start () 
    {
        base.Start();
        player = FindObjectOfType<Player>().transform;
       
	}
	
	// Update is called once per frame
	void Update () {

        MakeMove();
	}

    private void MakeMove()
    {
        if (CloseEnough())
        {
            if (!isDashing)
            {
                DashInPlayerDirection();
            }

        }
        else
        {
            if (!isDashing)
            {
                MoveForward();
            }
           
        }
    }

    private void MoveForward()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed*Time.deltaTime);
    }

    private void DashInPlayerDirection()
    {
        isDashing = true;
        StartCoroutine(Dash());
    }
    private IEnumerator Dash()
    {
        Vector3 playerPosAtThisMoment = player.position;
        Vector3 currentPosition = transform.position;
        Vector3 directionVector = playerPosAtThisMoment - currentPosition;
        Vector3 desirePosition = playerPosAtThisMoment + directionVector;
        yield return new WaitForSeconds(dashCastTime);
        float t = 0;
        while (t < 1)
        {
            yield return new WaitForSeconds(0.1f);
            transform.position = Vector3.Lerp(currentPosition, desirePosition, t);
            t += dashDelta;
        }
        transform.position = Vector3.Lerp(currentPosition, desirePosition, 1);
        isDashing = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        if(player != null)Gizmos.DrawSphere(player.position,radiusFromPlayer);
    }
    private void OnValidate()
    {
        namePlate = GetComponentInChildren<NamePlate>();
    }
    private bool CloseEnough()
    {
        if (Vector3.Distance(transform.position, player.position) < radiusFromPlayer)
        {
            return true;
        }
        else return false;
    }
}
