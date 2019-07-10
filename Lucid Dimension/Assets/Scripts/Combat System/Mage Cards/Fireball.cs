using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Card 
{
	private float damage = 25f;

	public Fireball(Deck parentDeck) : base(parentDeck)
	{
		this.cardName = "Fireball";
		this.castTime = 0.4f;
		this.resourceCost = 12f;
	}

	public override void Play(Alive cardTarget)
	{
		cardTarget.GetDamage (damage);
	}
}
