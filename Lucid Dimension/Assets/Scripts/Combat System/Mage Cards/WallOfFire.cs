using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallOfFire : Card 
{
	private float damage = 7f;

	public WallOfFire(Deck parentDeck) : base(parentDeck)
	{
		this.cardName = "Wall Of Fire";
		this.castTime = 2f;
		this.resourceCost = 6f;
	}

	public override void Play(Alive cardTarget)
	{
		cardTarget.GetDamage (damage);
	}
}
