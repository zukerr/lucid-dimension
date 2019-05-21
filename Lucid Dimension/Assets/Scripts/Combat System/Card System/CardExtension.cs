using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType
{
	offensive,
	deffensive,
	supportive
};

public class CardExtension 
{
    public Card ParentCard { get; private set; }
    public int LevelRequirement { get; set; }

    private CardType _cardType = CardType.offensive;
	public CardType _CardType
	{
		get { return _cardType; }
		set{ _cardType = value; }
	}
    public string Description { get; set; }

    public CardExtension(Card parentCard)
	{
		this.ParentCard = parentCard;
	}
}
