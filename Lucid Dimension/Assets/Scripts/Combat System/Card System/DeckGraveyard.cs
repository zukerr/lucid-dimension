using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DeckGraveyard
{
    public Deck ParentDeck { get; set; }

    private List<Card> graveyard;

	public DeckGraveyard(Deck parentDeck)
	{
		this.ParentDeck = parentDeck;
		graveyard = new List<Card> ();
	}

	public void AddToGraveyard(Card c)
	{
		graveyard.Add (c);
	}

	public void ReloadLibrary()
	{
		if (ParentDeck.LibraryCount () == 0) 
		{
			graveyard.Reverse ();
			ParentDeck.Library.AddRange (graveyard);
		}
	}
}
