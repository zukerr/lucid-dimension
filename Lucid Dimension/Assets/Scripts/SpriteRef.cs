using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRef : MonoBehaviour 
{
	//Card images

	//Mage Cards
	public Sprite bolide;
	public Sprite combustion;
	public Sprite desintegration;
	public Sprite detonate;
	public Sprite eruption;
	public Sprite fireball;
	public Sprite firebolt;
	public Sprite flamestrike;
	public Sprite ignite;
	public Sprite wallOfFire;


	//Buff images


	//Debuff images
	public Sprite burning;


	//Actionbar casting and in-queue indicators
	public Sprite castingIndicator;
	public Sprite inQueueIndicator;

	//Card Type indicators
	public Sprite offensiveIndicator;
	public Sprite deffensiveIndicator;
	public Sprite supportiveIndicator;

	//Card description background
	public Sprite cardDescriptionBackground;

	public Sprite GetCardSpriteByName(string str)
	{
		switch (str) 
		{
		case "Bolide":
			return bolide;
		case "Combustion":
			return combustion;
		case "Desintegration":
			return desintegration;
		case "Detonate":
			return detonate;
		case "Eruption":
			return eruption;
		case "Fireball":
			return fireball;
		case "Firebolt":
			return firebolt;
		case "Flamestrike":
			return flamestrike;
		case "Ignite":
			return ignite;
		case "Wall Of Fire":
			return wallOfFire;
		default:
			return null;
		}
	}

	public Sprite GetDebuffSpriteByName(string str)
	{
		switch (str) 
		{
		case "Burning":
			return burning;
		default:
			return null;
		}
	}

	public Sprite GetCardTypeIndicator(CardType t)
	{
		switch (t) 
		{
		case CardType.offensive:
			return offensiveIndicator;
		case CardType.deffensive:
			return deffensiveIndicator;
		case CardType.supportive:
			return supportiveIndicator;
		default:
			return null;
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
