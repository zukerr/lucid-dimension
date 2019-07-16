using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puncher : MonoBehaviour {

    [SerializeField]
    private Image castBar;

    [SerializeField]
    private float movementSpeed = 1f;
    [SerializeField]
    private float punchingStartRange = 3f;
    [SerializeField]
    private float punchingCastTime = 1f;
    [SerializeField]
    private int punchingAngle = 30;
    [SerializeField]
    private int punchQuantity = 10;

    private Rigidbody2D rbody;

    private bool punching = false;

    // Use this for initialization
    void Start ()
    {
        rbody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void FollowPlayer()
    {
        Vector2 position2d = new Vector2(transform.position.x, transform.position.y);
        Vector2 player = FileRef.playerRef.gameObject.transform.position;
        Vector2 movementVector = new Vector2(transform.position.x - player.x, transform.position.y - player.y);
        movementVector = -movementVector;
        if ((Vector2.Distance(position2d, player) > punchingStartRange) && (!punching))
        {
            //Follow player
            rbody.MovePosition(rbody.position + movementVector.normalized * Time.deltaTime * movementSpeed);
        }
        else if (!punching)
        {
            //Start casting dash
            //Debug.Log("Dashing! " + movementVector);
            StartCoroutine(Punch(movementVector));
        }
    }


    private IEnumerator Punch(Vector2 playerDirection)
    {
        punching = true;
        float time = 0;
        //Debug.Log("Starting casting dash");
        while (time < punchingCastTime)
        {
            yield return null;
            castBar.fillAmount = time / punchingCastTime;
            time += Time.deltaTime;
        }
        //Debug.Log("Finished casting dash");
        castBar.fillAmount = 0f;
        
        //setup
        playerDirection.Normalize();

        //algorithm
        Vector2 startingPosition = transform.position;

        bool side = true;
        for(int i = 0; i < punchQuantity; i++)
        {
            //Get random angle from 0 to given
            int angle = Random.Range(0, punchingAngle);

            if(side)
            {
                Vector2 dirVector = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
                side = false;
            }
            else
            {
                Vector2 dirVector = new Vector2(Mathf.Cos(angle), -Mathf.Sin(angle));
                side = true;
            }

            
        }
        punching = false;
    }
}
