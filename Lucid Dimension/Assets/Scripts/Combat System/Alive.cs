using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class Alive : MonoBehaviour
{
	public NamePlate namePlate;
    public float hp;
    public float maxHp;
	public float resource;
	public float maxResource;
	public Deck deck;
	public Alive target;
	public bool casting = false;
    public AliveCooldownManagement CooldownManagement { get; set; }
    public AliveBuffManagement BuffManagement { get; set; }
    public AliveRegeneration Regeneration { get; set; }

    public abstract void SetupDeck ();

	public virtual void SetTarget(Alive newTarget)
	{
		target = newTarget;
	}

	public virtual void ClearTarget()
	{
		target = null;
	}

	public void GetDamage(float damage)
	{
		hp -= damage;
		if (hp < 0) 
		{
			//Die
			Debug.Log(this.name + " died.");
			Regeneration.HpRegenSwitch = false;
			Regeneration.ResourceRegenSwitch = false;
            if (FileRef.playerRef.targetFrame.owner == this)
            {
                FileRef.playerRef.targetFrame.ClearOwner();
            }
            Destroy(gameObject);
		}
	}

	public void Heal(float amount)
	{
		Restore (amount, ref hp, ref maxHp);
	}

	public void RestoreResource(float amount)
	{
		Restore (amount, ref resource, ref maxResource);
	}

	private void Restore(float amount, ref float value, ref float maxValue)
	{
		if ((value + amount) <= maxValue) 
		{
			value += amount;
		} 
		else
		{
			value = maxValue;
		}
	}

	public void UseResource(float amount)
	{
		if (amount < resource) 
		{
			resource -= amount;
		} 
		else 
		{
			Debug.Log ("You don't have enough resource!");
		}
	}



	public virtual void Start()
	{
		CooldownManagement = gameObject.AddComponent<AliveCooldownManagement> ();
		CooldownManagement.ParentAlive = this;
		BuffManagement = gameObject.AddComponent<AliveBuffManagement> ();
		BuffManagement.ParentAlive = this;
		Regeneration = gameObject.AddComponent<AliveRegeneration> ();
		Regeneration.ParentAlive = this;
		this.deck = new Deck (this);
		SetupDeck ();
		this.hp = maxHp;
		this.resource = maxResource;
	}
}
