using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resourcebar : MonoBehaviour 
{
	public Alive owner;

	// Update is called once per frame
	void Update ()
	{
		GetComponent<Image> ().fillAmount = owner.resource / owner.maxResource;
	}
}
