using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combustion : Card 
{
	private float damage = 20f;

	public Combustion(Deck parentDeck) : base(parentDeck)
	{
		this.cardName = "Combustion";
		this.castTime = 0.4f;
		this.resourceCost = 3f;
	}

	public override void Play(Alive cardTarget)
	{
		cardTarget.GetDamage (damage);
	}
}
