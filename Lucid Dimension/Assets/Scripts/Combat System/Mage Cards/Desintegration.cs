using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desintegration : Card 
{
	private float damage = 15f;

	public Desintegration(Deck parentDeck) : base(parentDeck)
	{
		this.cardName = "Desintegration";
		this.castTime = 0.4f;
		this.resourceCost = 13f;
	}

	public override void Play(Alive cardTarget)
	{
		cardTarget.GetDamage (damage);
	}
}
