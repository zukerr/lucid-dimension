using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallOfFire : Card 
{
	private float damage = 20f;

	public WallOfFire(Deck parentDeck) : base(parentDeck)
	{
		this.cardName = "Wall Of Fire";
		this.castTime = 0.4f;
		this.resourceCost = 6f;
	}

	public override void Play(Alive cardTarget)
	{
		cardTarget.GetDamage (damage);
	}
}
