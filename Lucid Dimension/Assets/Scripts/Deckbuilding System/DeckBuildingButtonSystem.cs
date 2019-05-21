using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckBuildingButtonSystem : MonoBehaviour 
{
	public GameObject deckBuilding;
	public Button saveDeckButton;
	public Button copyDecklistToClipboardButton;
	public InputField searchBox;
	public Button doneButton;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void DoneButtonOnClick()
	{
		FileRef.playerRef.deck.ConfirmDeck ();
		FileRef.playerRef.deck.ShuffleLibrary ();
		FileRef.playerRef.GetComponent<PlayersHand> ().DrawStartingHand ();
		deckBuilding.SetActive (false);
        KeyboardController.FullscreenInterfaceOn = false;
	}

	public void DecklistToClipboardOnClick()
	{
		FileRef.playerRef.deck.Decklist.GetDecklistString ().CopyToClipboard ();
	}
}
