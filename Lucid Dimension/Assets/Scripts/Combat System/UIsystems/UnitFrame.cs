using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitFrame : MonoBehaviour 
{
	public Alive owner;

	public Healthbar hBar;
	public Resourcebar rBar;
	public UnitFrameBuffs buffFrame;

	// Use this for initialization
	void Start () 
	{
		hBar.owner = owner;
		rBar.owner = owner;
		buffFrame.UfOwner = owner;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

	public void SetOwner(Alive newOwner)
	{
        hBar.gameObject.SetActive(true);
        rBar.gameObject.SetActive(true);
        buffFrame.gameObject.SetActive(true);

        owner = newOwner;
		hBar.owner = owner;
		rBar.owner = owner;
		buffFrame.UfOwner = owner;
	}

    public void ClearOwner()
    {
        hBar.gameObject.SetActive(false);
        rBar.gameObject.SetActive(false);
        buffFrame.gameObject.SetActive(false);
        owner = null;
    }
}
