using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class CardPackage 
{
	protected List<Card> cardBox;

	protected List<Card> uniqueCards;
	public List<Card> UniqueCards
	{
		get { return uniqueCards; }
	}

	protected Alive owner;
	public Alive Owner
	{
		get { return owner; }
	}

	public CardPackage(Alive owner)
	{
		this.owner = owner;
		cardBox = new List<Card> ();
	}

	public void SetupUniqueCards()
	{
		uniqueCards = GlobalUniqueCardsInList (cardBox);
	}

	public int CountCopies(Card card)
	{
		return GlobalCountCopiesInList (cardBox, card);
	}

	public void AddToBox(Card card)
	{
		cardBox.Add (card);
		SetupUniqueCards ();
	}

	public void RemoveFromBox(Card card)
	{
		cardBox.Remove (card);
		SetupUniqueCards ();
	}

	protected void AddMultipleToBox(Card card, int amount)
	{
		for (int i = 0; i < amount; i++)
		{
			cardBox.Add (card);
		}
		SetupUniqueCards ();
	}

	public void AddToLibrary(Card card)
	{
		if (AddingToLibraryPossible (card)) 
		{
			AddToBox (card);
		}
	}

	public bool AddingToLibraryPossible(Card card)
	{
		if (CountCopies(card) < 5) 
		{
			return true;
		}
		else 
		{
			Debug.Log ("There are already 5 copies of this card in the deck!");
			return false;
		}
	}

	public void AddMultipleToLibrary(Card card, int amount)
	{
		if ((CountCopies(card) + amount) <= 5) 
		{
			AddMultipleToBox (card, amount);
		} 
		else 
		{
			Debug.Log ("Can't add more than 5 copies to the library!");
		}
	}

	public void RemoveFromLibrary(Card card)
	{
		RemoveFromBox (card);
	}

	public static List<Card> GlobalUniqueCardsInList(List<Card> inputList)
	{
		/*
		List<Card> temp = new List<Card> ();
		temp.AddRange(inputList);
		return temp.Distinct().ToList();
		*/

		List<Card> distinctCards = inputList.GroupBy(p => p.GetCardName()).Select(g => g.First()).ToList();

		return distinctCards;
	}

	public static int GlobalCountCopiesInList(List<Card> inputList, Card card)
	{
		int counter = 0;
		foreach (Card c in inputList) 
		{
			if (card.Equals (c)) 
			{
				counter++;
			}
		}
		return counter;
	}
}
