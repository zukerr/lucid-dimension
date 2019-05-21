using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burning : Buff
{
	private float damage;

	public Burning(Alive owner) : base(owner)
	{
		SetupStats ("Burning", 5f, false, 1f);
	}

	public override void EffectOn ()
	{
		damage = Mathf.Round (1f);
	}

	public override void IteratingEffect ()
	{
		owner.GetDamage (damage);
	}

	public override void EffectOff ()
	{
		//do nothing when burn expires
	}
}
