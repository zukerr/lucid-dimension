using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
	private Rigidbody2D rbody;

	private bool isWalking = false;
	public bool IsWalking
	{
		get { return isWalking; }
	}

	[SerializeField]
	private float speed = 1.2f;
	//Animator anim;

	// Use this for initialization
	void Start () {

		rbody = GetComponent<Rigidbody2D> ();
		//anim = GetComponent<Animator> ();

	
	}
	
	// Update is called once per frame
	void Update () {

		Vector2 movement_vector = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));

		if (movement_vector != Vector2.zero) 
		{
			isWalking = true;
			/*
			anim.SetBool ("iswalking", true);
			anim.SetFloat ("input_x", movement_vector.x);
			anim.SetFloat ("input_y", movement_vector.y);

			if (movement_vector.x > 0f) 
			{
				anim.SetBool ("last_dir_right", true);
			}

			if (movement_vector.x < 0f) 
			{
				anim.SetBool ("last_dir_right", false);
			}
			*/
		}
		else 
		{
			isWalking = false;
			//anim.SetBool ("iswalking", false);
		}

	
		rbody.MovePosition (rbody.position + movement_vector * Time.deltaTime * speed);



	}

	/*
    private void OnDisable()
    {
        if (anim.gameObject.activeSelf)
        {
            anim.SetBool("iswalking", false);
        }
    }
    */
}
