using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class DeckInfo : MonoBehaviour {

	public Player player;
	public InputField deckNameText;
	public Image offensePercentage;
	public Image deffensePercentage;
	public Image SupportPercentage;
	public Text avgResourceCostText;
	public Text avgCooldownText;
	public Text cardsWithDebuffsText;
	public Text cardsWithBuffsText;


	// Use this for initialization
	void Start () 
	{
		StartCoroutine (MakeSureCollectionSetupComplete ());
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	private IEnumerator MakeSureCollectionSetupComplete()
	{
		while (!player.CollectionSetupComplete) 
		{
			yield return null;
		}
		deckNameText.text = player.deck.Decklist.DeckName;
		SetupPercentages ();
		avgResourceCostText.text = player.deck.Decklist.GetAvgResourceCost ().ToString ("F");
		avgCooldownText.text = player.deck.Decklist.GetAvgCooldown().ToString ("F");
	}

	private void SetupPercentages()
	{
		int temp = player.deck.Decklist.Core.Count;
		if (temp != 0) 
		{
			offensePercentage.fillAmount = player.deck.GetListOfCardsOfTypeInDecklist (CardType.offensive).Count / temp;
			deffensePercentage.fillAmount = player.deck.GetListOfCardsOfTypeInDecklist (CardType.deffensive).Count / temp;
			SupportPercentage.fillAmount = player.deck.GetListOfCardsOfTypeInDecklist (CardType.supportive).Count / temp;
		} 
		else 
		{
			offensePercentage.fillAmount = 0;
			deffensePercentage.fillAmount = 0;
			SupportPercentage.fillAmount = 0;
		}
	}

	public void UpdateDeckInfo()
	{
		StartCoroutine (MakeSureCollectionSetupComplete ());
	}

    public void DecknameOnEndEdit()
    {
        player.deck.Decklist.DeckName = deckNameText.text;
    }
}
