using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DeckList : CardPackage 
{
	public List<Card> Core
	{
		get { return cardBox; }
	}

	private string deckName = "Default Deck";
	public string DeckName
	{
		get { return deckName; }
		set { deckName = value; }
	}

	public DeckList(Alive owner) : base(owner)
	{
		
	}

	public float GetAvgResourceCost()
	{
		float summary = 0;
		foreach (Card c in cardBox) 
		{
			summary += c.ResourceCost;
		}
		return (summary / (float)cardBox.Count);
	}

	public float GetAvgCooldown()
	{
		float summary = 0;
		foreach (Card c in cardBox) 
		{
			summary += c.GetCooldown();
		}
		return (summary / (float)cardBox.Count);
	}

	public string GetDecklistString()
	{
		string output = "";
		foreach (Card c in uniqueCards) 
		{
			output += CountCopies(c).ToString() + "x " + c.GetCardName() + "\r\n";
		}
		return output;
	}
}
