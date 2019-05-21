using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitFrameBuffs : MonoBehaviour 
{
    public Alive UfOwner { get; set; }

    public GameObject buffs;
	public GameObject debuffs;

	private GameObject[] buffIcons;
	private GameObject[] debuffIcons;


	// Use this for initialization
	void Start () 
	{
		buffIcons = new GameObject[4];
		debuffIcons = new GameObject[4];
		for (int i = 0; i < 4; i++) 
		{
			buffIcons [i] = buffs.transform.GetChild (i).gameObject;
			debuffIcons [i] = debuffs.transform.GetChild (i).gameObject;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		for (int i = 0; i < 4; i++) 
		{
			BuffOrDebuffSingleUpdate (UfOwner.BuffManagement.Buffs.ToArray (), buffIcons, i);
			BuffOrDebuffSingleUpdate (UfOwner.BuffManagement.Debuffs.ToArray (), debuffIcons, i);
		}
	}

	private void BuffOrDebuffSingleUpdate(Buff[] bArray, GameObject[] iconsArray, int iterator)
	{
		Buff temp = null;
		if (iterator < bArray.Length) 
		{
			temp = bArray [iterator];
		}
		if (temp != null)
		{
			iconsArray [iterator].GetComponent<Image> ().sprite = FileRef.spriteRef.GetDebuffSpriteByName (temp.BuffName);
			iconsArray [iterator].SetActive (true);
			iconsArray [iterator].transform.GetChild (0).GetComponent<Image> ().fillAmount = (1 - (temp.RemainingDuration / temp.Duration));
			if (temp.RemainingDuration == 0) 
			{
				iconsArray [iterator].SetActive (false);
			}
		} 
		else 
		{
			iconsArray [iterator].SetActive (false);
		}
	}
}
