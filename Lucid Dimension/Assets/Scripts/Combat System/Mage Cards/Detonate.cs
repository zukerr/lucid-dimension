using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detonate : Card 
{
	private float damage = 12f;

	public Detonate(Deck parentDeck) : base(parentDeck)
	{
		this.cardName = "Detonate";
		this.castTime = 6f;
		this.resourceCost = 3f;
	}

	public override void Play(Alive cardTarget)
	{
		cardTarget.GetDamage (damage);
	}
}
