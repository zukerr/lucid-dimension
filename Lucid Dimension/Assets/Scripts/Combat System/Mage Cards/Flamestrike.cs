using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamestrike : Card 
{
	private float damage = 12f;

	public Flamestrike(Deck parentDeck) : base(parentDeck)
	{
		this.cardName = "Flamestrike";
		this.castTime = 6f;
		this.resourceCost = 3f;
	}

	public override void Play(Alive cardTarget)
	{
		cardTarget.GetDamage (damage);
	}
}
