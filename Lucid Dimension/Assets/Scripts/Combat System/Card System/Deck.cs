using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Deck : CardPackage
{
	public List<Card> Library
	{
		get { return cardBox; }
	}
    public DeckGraveyard Graveyard { get; private set; }

    public int LibraryCount()
	{
		return cardBox.Count ();
	}
    public DeckList Decklist { get; private set; }

    public Deck(Alive owner) : base(owner)
	{
		Graveyard = new DeckGraveyard (this);
		Decklist = new DeckList (owner);
	}

	public void ConfirmDeck()
	{
		if (Decklist.Core.Count < 50) 
		{
			Debug.LogError ("There are less than 50 cards in the decklist!");
		}
		cardBox = new List<Card> (Decklist.Core);
		Decklist.SetupUniqueCards ();
		SetupUniqueCards ();
	}

	public Card GetUniqueCardNamed(string n)
	{
		foreach (Card c in Decklist.UniqueCards) 
		{
			if (c.GetCardName ().Equals (n)) 
			{
				return c;
			}
		}
		return null;
	}
		
	public List<Card> GetListOfCardsNamed(string name)
	{
		List<Card> temp = new List<Card> ();
		foreach (Card c in cardBox) 
		{
			if (c.GetCardName ().Equals (name)) 
			{
				temp.Add (c);
			}
		}
		return temp;
	}

	public List<Card> GetListOfCardsOfTypeInDecklist(CardType t)
	{
		List<Card> temp = new List<Card> ();
		foreach (Card c in Decklist.Core) 
		{
			if (c.Extension._CardType == t) 
			{
				temp.Add (c);
			}
		}
		return temp;
	}

	public Card DrawFromLibrary()
	{
		if (cardBox.Count > 0)
		{
			Card card = cardBox.Last ();
			cardBox.RemoveAt (cardBox.Count - 1);

			//Reload library: if lib.count == 0, then put graveyard in reverse order back to library 
			Graveyard.ReloadLibrary();

			return card;
		}
		else 
		{
			Debug.Log ("There are no more cards in the library!");
			return null;
		}
	}

	public void ShuffleLibrary()
	{
		cardBox.Shuffle ();
	}
}
