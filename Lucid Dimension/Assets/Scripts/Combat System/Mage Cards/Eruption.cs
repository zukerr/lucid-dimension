using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eruption : Card 
{
	private float damage = 50f;

	public Eruption(Deck parentDeck) : base(parentDeck)
	{
		this.cardName = "Eruption";
		this.castTime = 1.2f;
		this.resourceCost = 3f;
	}

	public override void Play(Alive cardTarget)
	{
		cardTarget.GetDamage (damage);
	}
}
