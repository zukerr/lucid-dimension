using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firebolt : Card 
{
	private float damage = 12f;

	public Firebolt(Deck parentDeck) : base(parentDeck)
	{
		this.cardName = "Firebolt";
		this.castTime = 1.2f;
		this.resourceCost = 3f;
	}

	public override void Play(Alive cardTarget)
	{
		cardTarget.GetDamage (damage);
	}
}
