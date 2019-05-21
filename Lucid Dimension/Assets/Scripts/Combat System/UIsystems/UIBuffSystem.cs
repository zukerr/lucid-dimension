using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBuffSystem : MonoBehaviour 
{
	public GameObject buffs;
	public GameObject debuffs;
    public GameObject[] BuffIconsArray { get; set; }
    public GameObject[] DebuffIconsArray { get; set; }

    public void DisplayBuff(int iconNumber, Buff buff)
	{
		StartCoroutine (DisplayBuffOrDebuff(iconNumber, buff, BuffIconsArray));
	}

	public void DisplayDebuff(int iconNumber, Buff debuff)
	{
		StartCoroutine (DisplayBuffOrDebuff(iconNumber, debuff, DebuffIconsArray));
	}

	public void StopDisplayingBuff(int iconNumber)
	{
		StopDisplayingBuffOrDebuff (iconNumber, BuffIconsArray);
	}

	public void StopDisplayingDebuff(int iconNumber)
	{
		StopDisplayingBuffOrDebuff (iconNumber, DebuffIconsArray);
	}


	private IEnumerator DisplayBuffOrDebuff(int iconNumber, Buff buff, GameObject[] iconsArray)
	{
		iconsArray [iconNumber].GetComponent<Image> ().sprite = FileRef.spriteRef.GetDebuffSpriteByName (buff.BuffName);
		iconsArray [iconNumber].SetActive (true);
		if (buff.RemainingDuration > 0) 
		{
			iconsArray [iconNumber].transform.GetChild (0).GetComponent<Image> ().fillAmount = 0;
			while (buff.RemainingDuration > 0) 
			{
				yield return null;
				iconsArray [iconNumber].transform.GetChild (0).GetComponent<Image> ().fillAmount = (1 - (buff.RemainingDuration / buff.Duration));
			}
			iconsArray [iconNumber].SetActive (false);
		}
	}

	private void StopDisplayingBuffOrDebuff(int iconNumber, GameObject[] iconsArray)
	{
		iconsArray [iconNumber].SetActive (false);
	}

	/*
	public void MoveIconsOneLeftFromIndex(int index, GameObject[] iconsArray)
	{
		if (index > 0) 
		{
			for (int i = index; i <= 4; i++) 
			{
				GameObject temp = iconsArray [i];
				iconsArray [i].transform.localPosition.Set (iconsArray [i - 1].transform.position.x, 
															iconsArray [i].transform.position.y, 
															iconsArray [i].transform.position.z);
				iconsArray [i - 1].transform.localPosition.Set (temp.transform.position.x, 
																iconsArray [i].transform.position.y, 
																iconsArray [i].transform.position.z);
			}
		}
	}
	*/

	// Use this for initialization
	void Start () 
	{
		BuffIconsArray = new GameObject[4];
		DebuffIconsArray = new GameObject[4];
		for (int i = 0; i < 4; i++) 
		{
			BuffIconsArray [i] = buffs.transform.GetChild (i).gameObject;
			DebuffIconsArray [i] = debuffs.transform.GetChild (i).gameObject;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
