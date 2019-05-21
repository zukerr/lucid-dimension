using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
	public Image castingBar;

	public Alive owner;
	protected Card[] hand;
	protected Deck deck;
	protected int queuedCard = -1;
	protected int indexBeingCast = -1;
	protected bool queueDone = false;

	public Card[] GetHand()
	{
		return hand;
	}

	public void DrawStartingHand()
	{
		deck.ShuffleLibrary ();
		for (int i = 0; i < 5; i++) 
		{
			DrawStartingCard (i);
		}
	}

	protected virtual void DrawStartingCard(int ind)
	{
		hand [ind] = deck.DrawFromLibrary ();
	}

	public void UseCard(int index)
	{
		if (CardAtIndexAvailibleForUse (index)) 
		{
			SafeUseCard_1 (index);
		}
		else 
		{
			if (CardAtIndexNotOnCd (index)) 
			{
				if (index != indexBeingCast) 
				{
					//Debug.LogWarning ("Stopping coroutine at index: " + queuedCard);
					if (queuedCard != -1) 
					{
						DisplayInQueueIndicator (queuedCard, false);
					}
					StopCoroutine (QueueCard (queuedCard));
					queuedCard = index;
					queueDone = false;
					//Debug.LogWarning ("Starting coroutine at index: " + queuedCard);
					StartCoroutine (QueueCard (queuedCard));
				}
			}
		}
	}

	protected bool CardAtIndexAvailibleForUse(int index)
	{
		if (!owner.casting) 
		{
			return CardAtIndexNotOnCd (index);
		}
		return false;
	}

	protected bool CardAtIndexNotOnCd(int index)
	{
		if (!hand [index].GetCurrentlyOnGCD())
		{
			if (!deck.GetUniqueCardNamed(hand [index].GetCardName()).GetCurrentlyOnCooldown ())
			{
				return true;
			}
		}
		return false;
	}

	protected virtual IEnumerator QueueCard(int index)
	{
		if (!queueDone) 
		{
			DisplayInQueueIndicator (index, true);
		}
		while (!CardAtIndexAvailibleForUse(index)) 
		{
			yield return null;
		}
		//if(CardAtIndexAvailibleForUse(queuedCard))
		if (!queueDone)
		{
			Debug.Log ("Queue ended! Casting now: " + hand [queuedCard].GetCardName ());
			//StartCoroutine (UseCard_1 (index));
			DisplayInQueueIndicator (queuedCard, false);
			//StartCoroutine(UseCard_1 (queuedCard));
			SafeUseCard_1 (queuedCard);
			queueDone = true;
		} 
		else 
		{
			DisplayInQueueIndicator (index, false);
		}
	}

	protected virtual void DisplayCastingIndicator(int index, bool turnOn){}
	protected virtual void DisplayInQueueIndicator(int index, bool turnOn){}

	protected virtual IEnumerator UseCard_1(int index)
	{
		indexBeingCast = index;
		StartCoroutine(hand [index].Cast (castingBar));
		while (!hand [index].castingFinished) 
		{
			yield return null;
		}
		Debug.Log ("Finished Casting");
		indexBeingCast = -1;
		if (!hand [index].CastingInterrupted)
		{
			deck.Graveyard.AddToGraveyard (hand [index]);
			hand [index] = deck.DrawFromLibrary ();
		}
	}

	protected void SafeUseCard_1(int index)
	{
		if (hand [index].CheckConditions ()) 
		{
			StartCoroutine (UseCard_1 (index));
		}
		else
		{
			Debug.LogWarning ("Target does not meet card's conditions!");
		}
	}

	public void PutHandBackToDeck()
	{
		for (int i = 0; i < 5; i++) 
		{
			PutCardBackToDeck (i);
		}
	}

	protected virtual void PutCardBackToDeck(int index)
	{
		deck.AddToLibrary (hand [index]);
		hand [index] = null;
	}

	// Use this for initialization
	protected virtual void Start () 
	{
		hand = new Card[5];
		this.deck = owner.deck;
		DrawStartingHand ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
