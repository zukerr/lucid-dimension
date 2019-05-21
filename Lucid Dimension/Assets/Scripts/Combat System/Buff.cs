using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Buff 
{
	protected string buffName;
	public string BuffName
	{
		get { return buffName; }
		set { buffName = value; }
	}

	protected float duration = 3f;
	public float Duration
	{
		get { return duration; }
		set { duration = value; }
	}

	protected float remainingDuration = 0f;
	public float RemainingDuration
	{
		get { return remainingDuration; }
		set { remainingDuration = value; }
	}

	protected Alive owner;
	public Alive Owner
	{
		get { return owner; }
		set { owner = value; }
	}

	protected bool positive;
	public bool Positive
	{
		get { return positive; }
		set { positive = value; }
	}

	protected float iteratingEffectInterval;
	public float IteratingEffectInterval
	{
		get { return iteratingEffectInterval; }
		set { iteratingEffectInterval = value; }
	}

	public Buff(Alive owner)
	{
		this.owner = owner;
	}

	public void SetupStats (string buffName, float duration, bool positive, float iteratingEffectInterval)
	{
		this.buffName = buffName;
		this.duration = duration;
		this.positive = positive;
		this.iteratingEffectInterval = iteratingEffectInterval;
	}

	public abstract void EffectOn();
	public abstract void EffectOff();
	public abstract void IteratingEffect();
}
