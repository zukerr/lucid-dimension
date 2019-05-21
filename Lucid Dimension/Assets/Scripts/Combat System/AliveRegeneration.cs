using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliveRegeneration : MonoBehaviour
{
    public Alive ParentAlive { get; set; }

    //value per second
    private float hpRegen = 0.5f;
	public float HpRegen
	{
		get { return hpRegen; }
		set { hpRegen = value; }
	}

	private bool hpRegenSwitch = true;
	public bool HpRegenSwitch
	{
		get { return hpRegenSwitch; }
		set { hpRegenSwitch = value; }
	}

	//value per second
	private float resourceRegen = 1f;
	public float ResourceRegen
	{
		get { return resourceRegen; }
		set { resourceRegen = value; }
	}

	private bool resourceRegenSwitch = true;
	public bool ResourceRegenSwitch
	{
		get { return resourceRegenSwitch; }
		set { resourceRegenSwitch = value; }
	}

	public void StartPassiveHpRegen()
	{
		StartCoroutine (PassiveHpRegen ());
	}

	public void StartPassiveResourceRegen()
	{
		StartCoroutine (PassiveResourceRegen ());
	}

	private IEnumerator PassiveHpRegen()
	{
		while (hpRegenSwitch) 
		{
			yield return null;
			ParentAlive.Heal (Time.deltaTime * hpRegen);
		}
	}

	private IEnumerator PassiveResourceRegen()
	{
		while (resourceRegenSwitch) 
		{
			yield return null;
			ParentAlive.RestoreResource (Time.deltaTime * resourceRegen);
		}
	}

	// Use this for initialization
	void Start () 
	{
		StartPassiveHpRegen ();
		StartPassiveResourceRegen ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
