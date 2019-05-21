using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combustion : Card 
{
	private float damage = 4f;

	public Combustion(Deck parentDeck) : base(parentDeck)
	{
		this.cardName = "Combustion";
		this.castTime = 2f;
		this.resourceCost = 3f;
	}

	public override void Play(Alive cardTarget)
	{
		cardTarget.GetDamage (damage);
	}
}
