using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckDisplay : MonoBehaviour 
{
	public Alive player;
	public Text counterText;


	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		counterText.text = player.deck.LibraryCount ().ToString();
	}
}
