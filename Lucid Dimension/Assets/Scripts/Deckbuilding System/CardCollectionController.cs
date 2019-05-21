using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CardCollectionController : MonoBehaviour 
{
	private CardPackage collection;
	public Player player;

	public Scrollbar scrollbar;
	private float scrollbarLastStep;

	public GameObject cardSlotsGameobject;
	private CardCollectionSlot[] cardSlotsArray;

	public bool collectionTrueDeckFalse = true;
	public CardType relevantIfBoolFalse;
	private List<Card> partOfDeck;

	private int slotsCount;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine (MakeSureCollectionSetupComplete ());
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void UpdateController()
	{
		int tempStep = Mathf.RoundToInt(scrollbar.value * ((float)scrollbar.numberOfSteps - 1f));
		SetupCardPool ();
		SetupCardSlots (0);
		SetupScrollbar ();

		scrollbar.value = 0f;
		for (int i = 0; i < tempStep; i++) 
		{
			scrollbar.value += (1f / (scrollbar.numberOfSteps - 1f));
		}

		//scrollbar.value = scrollbarLastStep;
		//ScrollCardSlots();

		//StartCoroutine (MakeSureCollectionSetupComplete ());
	}

	private void SetupCardSlotsReferences()
	{
		cardSlotsArray = new CardCollectionSlot[slotsCount];
		for (int i = 0; i < slotsCount; i++) 
		{
			cardSlotsArray [i] = cardSlotsGameobject.transform.GetChild (i).GetComponent<CardCollectionSlot>();
			cardSlotsArray [i].ParentController = this;
		}
		SetupCardSlots (0);
	}

	private void SetupCardSlots(int startingStep)
	{
		for (int i = 0; i < slotsCount; i++) 
		{
			Card temp = GetTempCard (i, startingStep);
			if (temp != null) 
			{
				cardSlotsArray [i].CurrentCard = temp;
				cardSlotsArray [i].cardImage.sprite = FileRef.spriteRef.GetCardSpriteByName (temp.GetCardName ());
				cardSlotsArray [i].countInCollection.text = "x" + GetCardCountString (temp);
				if (collectionTrueDeckFalse) 
				{
					cardSlotsArray [i].cardTypeIndicator.sprite = FileRef.spriteRef.GetCardTypeIndicator (temp.Extension._CardType);
					cardSlotsArray [i].levelIndicator.text = temp.Extension.LevelRequirement.ToString () + "lvl";
					cardSlotsArray [i].cardDescriptionBackground.sprite = FileRef.spriteRef.cardDescriptionBackground;
					cardSlotsArray [i].cardDescriptionText.text = temp.Extension.Description;
				}
			}
			else 
			{
				cardSlotsArray [i].CurrentCard = null;
				cardSlotsArray [i].cardImage.sprite = null;
				cardSlotsArray [i].countInCollection.text = "";
				if (collectionTrueDeckFalse) 
				{
					cardSlotsArray [i].cardTypeIndicator.sprite = null;
					cardSlotsArray [i].levelIndicator.text = "";
					cardSlotsArray [i].cardDescriptionBackground.sprite = null;
					cardSlotsArray [i].cardDescriptionText.text = "";
				}
			}
		}
	}

	private void SetupScrollbar()
	{
		int temp;
		if (collectionTrueDeckFalse) 
		{
			temp = collection.UniqueCards.Count;
		} 
		else 
		{
			temp = CardPackage.GlobalUniqueCardsInList (partOfDeck).Count;
		}
		if (temp > slotsCount) 
		{
			scrollbar.gameObject.SetActive (true);
			scrollbar.numberOfSteps = (temp - (slotsCount - 1));
			scrollbarLastStep = scrollbar.value;
		}
		else 
		{
			scrollbar.gameObject.SetActive (false);
			scrollbar.numberOfSteps = 1;
			scrollbarLastStep = 0;
		}
	}

	public void ScrollCardSlots()
	{
		Debug.Log ("Value changed." + scrollbar.value);
		if (scrollbar.value != scrollbarLastStep) 
		{
			int step = Mathf.RoundToInt (scrollbar.value * (scrollbar.numberOfSteps - 1));
			SetupCardSlots (step);
			scrollbarLastStep = scrollbar.value;
		}
	}

	private IEnumerator MakeSureCollectionSetupComplete()
	{
		while (!player.CollectionSetupComplete) 
		{
			yield return null;
		}
		SetupCardPool ();
		SetupCardSlotsReferences ();
		SetupScrollbar ();
	}

	private void SetupCardPool()
	{
		if (collectionTrueDeckFalse) 
		{
			collection = player.cardCollection;
			slotsCount = 8;
		} 
		else 
		{
			partOfDeck = player.deck.GetListOfCardsOfTypeInDecklist (relevantIfBoolFalse);
			slotsCount = 12;
		}
	}

	private Card GetTempCard(int iterator, int startingStep)
	{
		if (collectionTrueDeckFalse) 
		{
			if ((iterator + startingStep) < collection.UniqueCards.Count)
			{
				return collection.UniqueCards.ElementAt (iterator + startingStep);
			}
			else 
			{
				return null;
			}
		}
		else
		{
			//Debug.Log (CardPackage.GlobalUniqueCardsInList (partOfDeck).Count);
			if ((iterator + startingStep) < CardPackage.GlobalUniqueCardsInList (partOfDeck).Count)
			{
				return CardPackage.GlobalUniqueCardsInList (partOfDeck).ElementAt (iterator + startingStep);
			}
			else 
			{
				return null;
			}
		}
	}

	private string GetCardCountString(Card card)
	{
		if (collectionTrueDeckFalse) 
		{
			return collection.CountCopies (card).ToString();
		}
		else
		{
			return CardPackage.GlobalCountCopiesInList (partOfDeck, card).ToString ();
		}
	}

	public void ScrollWithMouse()
	{
		//scrollbar.value += Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime;
		//Debug.Log(Input.GetAxis("Mouse ScrollWheel"));
		if (Input.GetAxis ("Mouse ScrollWheel") > 0) 
		{
			scrollbar.value += (1f / (scrollbar.numberOfSteps - 1f));
		}
		else 
		{
			scrollbar.value -= (1f / (scrollbar.numberOfSteps - 1f));
		}
	}
		
}
