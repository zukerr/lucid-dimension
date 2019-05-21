using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Card 
{
	private float damage = 10f;

	public Fireball(Deck parentDeck) : base(parentDeck)
	{
		this.cardName = "Fireball";
		this.castTime = 2f;
		this.resourceCost = 12f;
	}

	public override void Play(Alive cardTarget)
	{
		cardTarget.GetDamage (damage);
	}
}
