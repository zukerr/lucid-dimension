using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Card
{
	[SerializeField]
	protected string cardName;
	[SerializeField]
	protected float castTime;
	[SerializeField]
	protected float cooldown =  5f;
	[SerializeField]
	protected bool gcd = true;

	[SerializeField]
	protected float resourceCost;
	public float ResourceCost
	{
		get { return resourceCost; }
	}

	[SerializeField]
	protected Deck parentDeck;
	protected bool currentlyOnCooldown;
	protected bool currentlyOnGCD;
	protected float remainingCooldown = 0;
	protected bool canBeCastedWhileMoving = false;
	private bool castingInterrupted = false;
	public bool CastingInterrupted
	{
		get{ return castingInterrupted; }
	}
	protected CardExtension extension;
	public CardExtension Extension
	{
		get { return extension; }
	}
	//protected float remainingGCD = 0;

	public abstract void Play (Alive cardTarget);

	public string GetCardName()
	{
		return cardName;
	}
	public float GetCastTime()
	{
		return castTime;
	}
	public float GetCooldown()
	{
		return cooldown;
	}
	public bool GetGcd()
	{
		return gcd;
	}
	public bool GetCurrentlyOnCooldown()
	{
		return currentlyOnCooldown;
	}
	public void SetCurrentlyOnCooldown(bool currentlyOnCooldown)
	{
		this.currentlyOnCooldown = currentlyOnCooldown;
	}
	public bool GetCurrentlyOnGCD()
	{
		return currentlyOnGCD;
	}
	public void SetCurrentlyOnGCD(bool currentlyOnGCD)
	{
		this.currentlyOnGCD = currentlyOnGCD;
	}
	public float GetRemainingCooldown()
	{
		return remainingCooldown;
	}

	public Card(Deck parentDeck)
	{
		extension = new CardExtension (this);
		this.parentDeck = parentDeck;
	}

	public override string ToString ()
	{
		return cardName;
	}

	public bool Equals(Card card)
	{
		if (card.cardName.Equals (this.cardName)) 
		{
			return true;
		} 
		else 
		{
			return false;
		}
	}

	public bool castingFinished = true;

	public IEnumerator Cast(Image img)
	{
		castingFinished = false;
		Alive tempCardTarget = parentDeck.Owner.target;
		castingInterrupted = false;
		parentDeck.Owner.UseResource (resourceCost);
		parentDeck.Owner.casting = true;
		parentDeck.Owner.CooldownManagement.TriggerCardCooldownOnDeck (cardName);
		parentDeck.Owner.CooldownManagement.TriggerGcdOnDeck ();
		float time = 0;
		float speed = 1f;
		while ((time < castTime) && (CheckConditionsWhileCasting(tempCardTarget)))
		{
			yield return null;
			time += speed * Time.deltaTime;
			img.fillAmount = (time / castTime);
			if (!CheckConditionsWhileCasting (tempCardTarget)) 
			{
				castingInterrupted = true;
			}
		}
		img.fillAmount = 0f;
		if (!castingInterrupted) 
		{
			Play (tempCardTarget);
		}
		castingFinished = true;
		parentDeck.Owner.casting = false;
	}

	public IEnumerator TriggerCooldown()
	{
		if (cooldown > 0f) 
		{
			currentlyOnCooldown = true;
			remainingCooldown = cooldown;
			float speed = 1f;
			while (remainingCooldown > 0) 
			{
				yield return null;
				remainingCooldown -= speed * Time.deltaTime;
			}
			remainingCooldown = 0;
			currentlyOnCooldown = false;
		}
	}

	public virtual bool CheckConditionsBeforeCasting()
	{
		if (parentDeck.Owner.target != null) 
		{
			return CheckCastingWhileMovingCondition () && CheckTargetInRangeCondition (parentDeck.Owner.target);
		}
		else
			return false;
	}

    private bool CheckConditionsWhileCasting(Alive target)
    {
        return CheckCastingWhileMovingCondition() && CheckTargetInRangeCondition(target);
    }

	private bool CheckCastingWhileMovingCondition()
	{
		if (!canBeCastedWhileMoving)
		{
			if (parentDeck.Owner.gameObject.GetComponent<PlayerMovement> ().IsWalking) 
			{
				return false;
			}
			else
			{
				return true;
			}
		}
		else
		{
			return true;
		}
	}

    private bool CheckTargetInRangeCondition(Alive target)
    {
        if(((Opponent)target).InRange)
        {
            return true;
        }
        else
        {
            Debug.LogWarning("Target is not in range!");
            return false;
        }
    }
}
