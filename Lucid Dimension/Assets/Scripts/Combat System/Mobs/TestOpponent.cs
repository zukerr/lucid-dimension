using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestOpponent : Alive {

	// Use this for initialization
	public override void Start () 
	{
		base.Start ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void SetupDeck ()
	{
		deck.AddMultipleToLibrary (new Fireball (deck), 5);
		deck.AddMultipleToLibrary (new Bolide (deck), 5);
		deck.AddMultipleToLibrary (new Combustion (deck), 5);
		deck.AddMultipleToLibrary (new WallOfFire (deck), 5);
		deck.AddMultipleToLibrary (new Desintegration (deck), 5);
		deck.AddMultipleToLibrary (new Detonate (deck), 5);
		deck.AddMultipleToLibrary (new Flamestrike (deck), 5);
		deck.AddMultipleToLibrary (new Firebolt (deck), 5);
		deck.AddMultipleToLibrary (new Eruption (deck), 5);
		deck.AddMultipleToLibrary (new Ignite (deck), 5);
	}
}
