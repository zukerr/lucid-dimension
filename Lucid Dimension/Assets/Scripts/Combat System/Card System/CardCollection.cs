using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CardCollection : CardPackage
{
	public CardCollection(Alive owner) : base(owner)
	{

	}

	public void AddToCollection(Card card)
	{
		AddToBox (card);
		//cardBox.Add(card);
	}

	public void RemoveFromCollection(Card card)
	{
		RemoveFromBox (card);
		//cardBox.Remove(card);
	}

	public void AddMultipleToCollection(Card card, int amount)
	{
		if ((CountCopies(card) + amount) <= 5) 
		{
			AddMultipleToBox (card, amount);
		} 
		else 
		{
			Debug.Log ("You are trying to add more than 5 cards to the collection!");
		}
	}
}
