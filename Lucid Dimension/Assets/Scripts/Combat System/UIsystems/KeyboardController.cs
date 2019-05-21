using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : MonoBehaviour {

	public Hand playerHand;
	public PlayerTabtarget tabTarget;
	public GameObject deckBuildingUI;
    public static bool FullscreenInterfaceOn { get; set; }

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
        WorldGameplayUpdateKeyboard();
		if (Input.GetKeyDown (KeyCode.P)) 
		{
			playerHand.PutHandBackToDeck ();
			deckBuildingUI.SetActive (true);
            FullscreenInterfaceOn = true;
		}
	}

    private void WorldGameplayUpdateKeyboard()
    {
        if(!FullscreenInterfaceOn)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                playerHand.UseCard(0);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                playerHand.UseCard(1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                playerHand.UseCard(2);
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                playerHand.UseCard(3);
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                playerHand.UseCard(4);
            }
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                tabTarget.TabTarget();
            }
        }
    }
}
