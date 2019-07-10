using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolide : Card 
{
	private float damage = 20f;

	public Bolide(Deck parentDeck) : base(parentDeck)
	{
		this.cardName = "Bolide";
		this.castTime = 1f;
		this.resourceCost = 20f;
	}

	public override void Play(Alive cardTarget)
	{
		cardTarget.GetDamage (damage);
		cardTarget.BuffManagement.AddDebuff (new Burning (cardTarget));
	}
}
