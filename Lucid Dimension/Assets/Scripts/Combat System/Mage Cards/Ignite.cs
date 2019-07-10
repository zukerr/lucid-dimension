using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ignite : Card 
{
	private float damage = 5f;

	public Ignite(Deck parentDeck) : base(parentDeck)
	{
		this.cardName = "Ignite";
		this.castTime = 0.4f;
		this.resourceCost = 6f;
	}

	public override void Play(Alive cardTarget)
	{
		cardTarget.GetDamage (damage);
		cardTarget.BuffManagement.AddDebuff (new Burning (cardTarget));
	}
}
