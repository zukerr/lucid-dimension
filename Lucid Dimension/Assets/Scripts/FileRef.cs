using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileRef : MonoBehaviour {

	public SpriteRef publicSpriteRef;
	public Player publicPlayerRef;
	public CardCollectionController publicCollectionControllerRef;
	public CardCollectionController publicOffensiveDeckPartControllerRef;
	public CardCollectionController publicDeffensiveDeckPartControllerRef;
	public CardCollectionController publicSupportiveDeckPartControllerRef;
	public DeckInfo publicDeckInfoRef;
    public Camera publicCameraRef;

	public static SpriteRef spriteRef;
	public static Player playerRef;
	public static CardCollectionController collectionControllerRef;
	public static CardCollectionController offensiveDeckPartControllerRef;
	public static CardCollectionController deffensiveDeckPartControllerRef;
	public static CardCollectionController supportiveDeckPartControllerRef;
	public static DeckInfo deckInfoRef;
    public static Camera cameraRef;

	// Use this for initialization
	void Awake () 
	{
		spriteRef = publicSpriteRef;
		playerRef = publicPlayerRef;
		collectionControllerRef = publicCollectionControllerRef;
		offensiveDeckPartControllerRef = publicOffensiveDeckPartControllerRef;
		deffensiveDeckPartControllerRef = publicDeffensiveDeckPartControllerRef;
		supportiveDeckPartControllerRef = publicSupportiveDeckPartControllerRef;
		deckInfoRef = publicDeckInfoRef;
        cameraRef = publicCameraRef;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
