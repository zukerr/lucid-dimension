using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eruption : Card 
{
	private float damage = 12f;

	public Eruption(Deck parentDeck) : base(parentDeck)
	{
		this.cardName = "Eruption";
		this.castTime = 6f;
		this.resourceCost = 3f;
	}

	public override void Play(Alive cardTarget)
	{
		cardTarget.GetDamage (damage);
	}
}
