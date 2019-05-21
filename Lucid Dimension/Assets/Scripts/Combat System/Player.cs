using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Alive 
{
	public CharacterClass characterClass;
	public UnitFrame targetFrame;
	public CardCollection cardCollection;

	private bool collectionSetupComplete = false;
	public bool CollectionSetupComplete
	{
		get { return collectionSetupComplete; }
	}

	// Use this for initialization
	public override void Start () 
	{
		base.Start ();
		characterClass = new Mage ();
		SetupCollection ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void SetupDeck ()
	{
		deck.Decklist.AddMultipleToLibrary (new Fireball (deck), 5);

		deck.Decklist.AddMultipleToLibrary (new Bolide (deck), 5);
		deck.Decklist.AddMultipleToLibrary (new Combustion (deck), 5);
		deck.Decklist.AddMultipleToLibrary (new WallOfFire (deck), 5);
		deck.Decklist.AddMultipleToLibrary (new Desintegration (deck), 5);
		deck.Decklist.AddMultipleToLibrary (new Detonate (deck), 5);
		deck.Decklist.AddMultipleToLibrary (new Flamestrike (deck), 5);
		deck.Decklist.AddMultipleToLibrary (new Firebolt (deck), 5);
		deck.Decklist.AddMultipleToLibrary (new Eruption (deck), 5);
		deck.Decklist.AddMultipleToLibrary (new Ignite (deck), 5);

		deck.ConfirmDeck ();
		deck.ShuffleLibrary ();
	}

	public override void SetTarget (Alive newTarget)
	{
		if (target != null) 
		{
			target.namePlate.selectImage.SetActive (false);
		}
		base.SetTarget (newTarget);
		targetFrame.SetOwner (target);
		targetFrame.gameObject.SetActive (true);
		target.namePlate.selectImage.SetActive (true);
	}

	public override void ClearTarget ()
	{
		base.ClearTarget ();
		targetFrame.gameObject.SetActive (false);
		target.namePlate.selectImage.SetActive (false);
		targetFrame.SetOwner (null);
	}

	private void SetupCollection()
	{
		this.cardCollection = new CardCollection (this);
		cardCollection.AddMultipleToCollection (new Fireball (deck), 5);
		cardCollection.AddMultipleToCollection (new Bolide (deck), 5);
		cardCollection.AddMultipleToCollection (new Combustion (deck), 5);
		cardCollection.AddMultipleToCollection (new WallOfFire (deck), 5);
		cardCollection.AddMultipleToCollection (new Desintegration (deck), 5);
		cardCollection.AddMultipleToCollection (new Detonate (deck), 5);
		cardCollection.AddMultipleToCollection (new Flamestrike (deck), 5);
		cardCollection.AddMultipleToCollection (new Firebolt (deck), 5);
		cardCollection.AddMultipleToCollection (new Eruption (deck), 5);
		cardCollection.AddMultipleToCollection (new Ignite (deck), 5);
		//Debug.LogWarning ("collection setup complete!");
		collectionSetupComplete = true;
	}
}
