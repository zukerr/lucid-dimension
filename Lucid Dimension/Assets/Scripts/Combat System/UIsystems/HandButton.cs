using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandButton : MonoBehaviour 
{
	public Hand hand;

	public void PlayCard()
	{
		int sibIndex = gameObject.transform.GetSiblingIndex ();
		hand.UseCard (sibIndex);
	}

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
