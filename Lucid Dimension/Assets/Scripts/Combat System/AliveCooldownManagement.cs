using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AliveCooldownManagement : MonoBehaviour 
{
    public Alive ParentAlive { get; set; }

    public float gcdTime = 1.5f;
	public float remainingGCD = 0;


	public void TriggerGcdOnDeck()
	{
		StartCoroutine (TriggerGcdOnDeckInsight ());
	}

	private IEnumerator TriggerGcdOnDeckInsight()
	{
		TriggerGcdOnCard (true);
		remainingGCD = gcdTime;
		float speed = 1f;
		while (remainingGCD > 0) 
		{
			yield return null;
			remainingGCD -= speed * Time.deltaTime;
		}
		remainingGCD = 0;
		TriggerGcdOnCard (false);
	}

	private void TriggerGcdOnCard(bool start)
	{
		foreach (Card c in ParentAlive.deck.Library) 
		{
			if (c.GetGcd()) 
			{
				c.SetCurrentlyOnGCD (start);
				//Debug.LogWarning (c.GetCardName() + deck.GetLibrary ().IndexOf (c) + " 's currentlyOnGCD status has been set to: " + start);
			}
		}
		Card[] temp = GetComponent<PlayersHand> ().GetHand();
		foreach (Card c in temp) 
		{
			if (c.GetGcd ()) 
			{
				c.SetCurrentlyOnGCD (start);
			}
		}
	}

	public void TriggerCardCooldownOnDeck(string card)
	{
		StartCoroutine (ParentAlive.deck.GetUniqueCardNamed (card).TriggerCooldown ());
	}

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
