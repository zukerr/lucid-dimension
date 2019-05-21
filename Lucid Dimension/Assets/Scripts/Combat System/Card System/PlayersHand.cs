using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayersHand : Hand 
{
	public FileRef fileRef;

	public Image icon1;
	public Image icon2;
	public Image icon3;
	public Image icon4;
	public Image icon5;

	private Image[] icons;

	public Image cdicon1;
	public Image cdicon2;
	public Image cdicon3;
	public Image cdicon4;
	public Image cdicon5;

	private Image[] cdicons;

	protected override void DrawStartingCard(int ind)
	{
		base.DrawStartingCard (ind);
		if (fileRef.publicSpriteRef == null)
		{
			Debug.Log ("FileRef.spriteRef is null!!!");
		}
		if (fileRef.publicSpriteRef.GetCardSpriteByName (hand [ind].GetCardName ()) == null)
		{
			Debug.Log ("Problem with finding sprite by string.");
		}
		if (icons [ind] == null)
		{
			Debug.Log ("sprite in icon number i in an array is null");
		}
		icons[ind].sprite = fileRef.publicSpriteRef.GetCardSpriteByName (hand [ind].GetCardName ());
	}

	protected override IEnumerator UseCard_1(int index)
	{
		//queuedCard = -1;
		indexBeingCast = index;
		DisplayCastingIndicator (index, true);
		StartCoroutine(hand [index].Cast (castingBar));
		DisplayGCDandCD ();
		while (!hand [index].castingFinished) 
		{
			yield return null;
		}
		Debug.Log ("Finished Casting");
		DisplayCastingIndicator (index, false);
		indexBeingCast = -1;

		if (!hand [index].CastingInterrupted) 
		{
			deck.Graveyard.AddToGraveyard (hand [index]);
			hand [index] = deck.DrawFromLibrary ();
			DisplayGCDandCD ();
			icons[index].sprite = FileRef.spriteRef.GetCardSpriteByName (hand [index].GetCardName ());
		}
	}

	private void DisplayGCDandCD()
	{
		for (int i = 0; i < 5; i++) 
		{
			StartCoroutine (DisplayGCDOnSingleIcon (i, cdicons [i]));
			StartCoroutine (DisplayCDOnSingleIcon (i, cdicons [i]));
		}
	}

	private IEnumerator DisplayGCDOnSingleIcon(int index, Image cdimg)
	{
		if (hand [index].GetCurrentlyOnGCD ())
		{
			cdimg.fillAmount = 1f;
			while (hand [index].GetCurrentlyOnGCD ()) 
			{
				yield return null;
				cdimg.fillAmount = (owner.CooldownManagement.remainingGCD / owner.CooldownManagement.gcdTime);
			}
			cdimg.fillAmount = 0f;
		}
		else 
		{
			//Debug.LogError (hand [index].GetCardName() + deck.GetLibrary().IndexOf(hand[index]) + " is not currently on gcd");
		}
	}

	private IEnumerator DisplayCDOnSingleIcon(int index, Image cdimg)
	{
		if (deck.GetUniqueCardNamed(hand [index].GetCardName()).GetCurrentlyOnCooldown ())
		{
			while (hand [index].GetCurrentlyOnGCD ()) 
			{
				yield return null;
			}
			while (deck.GetUniqueCardNamed(hand [index].GetCardName()).GetCurrentlyOnCooldown ()) 
			{
				yield return null;
				cdimg.fillAmount = (deck.GetUniqueCardNamed(hand [index].GetCardName()).GetRemainingCooldown() / deck.GetUniqueCardNamed(hand [index].GetCardName()).GetCooldown());
			}
			cdimg.fillAmount = 0f;
		}
	}

	protected override void DisplayCastingIndicator(int index, bool turnOn)
	{
		//Debug.LogError (index);
		icons [index].gameObject.transform.GetChild (1).GetComponent<Image> ().sprite = FileRef.spriteRef.castingIndicator;
		icons [index].gameObject.transform.GetChild (1).gameObject.SetActive (turnOn);
	}

	protected override void DisplayInQueueIndicator(int index, bool turnOn)
	{
		if (turnOn) 
		{
			icons [index].gameObject.transform.GetChild (1).GetComponent<Image> ().sprite = FileRef.spriteRef.inQueueIndicator;	
			icons [index].gameObject.transform.GetChild (1).gameObject.SetActive (turnOn);
		}
		else
		{
			if (icons [index].gameObject.transform.GetChild (1).GetComponent<Image> ().sprite == FileRef.spriteRef.inQueueIndicator) 
			{
				icons [index].gameObject.transform.GetChild (1).gameObject.SetActive (turnOn);
			}
		}
	}

	protected override void PutCardBackToDeck (int index)
	{
		base.PutCardBackToDeck (index);
		icons [index].sprite = null;
	}

	// Use this for initialization
	protected override void Start () 
	{
		icons = new Image[5];
		icons [0] = icon1;
		icons [1] = icon2;
		icons [2] = icon3;
		icons [3] = icon4;
		icons [4] = icon5;
		cdicons = new Image[5];
		cdicons [0] = cdicon1;
		cdicons [1] = cdicon2;
		cdicons [2] = cdicon3;
		cdicons [3] = cdicon4;
		cdicons [4] = cdicon5;
		base.Start ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
