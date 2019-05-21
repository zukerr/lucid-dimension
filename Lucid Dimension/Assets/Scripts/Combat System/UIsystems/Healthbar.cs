using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour 
{
	public Alive owner;

	// Update is called once per frame
	void Update ()
	{
		GetComponent<Image> ().fillAmount = owner.hp / owner.maxHp;
	}
}
