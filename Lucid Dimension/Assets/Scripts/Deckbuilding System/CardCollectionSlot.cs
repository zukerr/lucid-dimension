using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardCollectionSlot : MonoBehaviour 
{
	public Image cardImage;
	public Image cardTypeIndicator;
	public Text levelIndicator;
	public Text countInCollection;
	public Image cardDescriptionBackground;
	public Text cardDescriptionText;
    public Card CurrentCard { get; set; }
    public CardCollectionController ParentController { get; set; }

    // Use this for initialization
    void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void CollectionOnClick()
	{
		if (CurrentCard != null) 
		{
			if (FileRef.playerRef == null) 
			{
				Debug.LogWarning ("playerRef is null");
			}
			if (FileRef.playerRef.deck.Decklist.AddingToLibraryPossible (CurrentCard)) 
			{
				FileRef.playerRef.deck.Decklist.AddToLibrary (CurrentCard);
				FileRef.playerRef.cardCollection.RemoveFromCollection (CurrentCard);
				ParentController.UpdateController ();

				FileRef.offensiveDeckPartControllerRef.UpdateController ();
				FileRef.deffensiveDeckPartControllerRef.UpdateController ();
				FileRef.supportiveDeckPartControllerRef.UpdateController ();

				FileRef.deckInfoRef.UpdateDeckInfo ();
			}
		}
	}

	public void DeckOnClick()
	{
		if (CurrentCard != null) 
		{
			FileRef.playerRef.cardCollection.AddToCollection (CurrentCard);
			FileRef.playerRef.deck.Decklist.RemoveFromLibrary (CurrentCard);
			ParentController.UpdateController ();

			FileRef.collectionControllerRef.UpdateController ();

			FileRef.deckInfoRef.UpdateDeckInfo ();
		}
	}
}
