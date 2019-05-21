using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AliveBuffManagement : MonoBehaviour 
{
    public Alive ParentAlive { get; set; }
    public List<Buff> Buffs { get; private set; }
    public List<Buff> Debuffs { get; private set; }

    private UIBuffSystem uiSystem;

	public void AddBuff(Buff b)
	{
		if (b.Positive) 
		{
			AddBuffOrDebuff (b, Buffs, true);
			uiSystem.DisplayBuff (Buffs.Count - 1, b);
		} 
		else 
		{
			Debug.LogWarning ("[coding error]: You can't add a debuff as a buff!");
		}
	}

	public void RemoveBuff(Buff b)
	{
		RemoveBuffOrDebuff (b, Buffs);
	}

	public void RemoveAllBuffs()
	{
		RemoveAllBuffsOrDebuffs (Buffs);
	}

	public void AddDebuff(Buff b)
	{
		if (!b.Positive) 
		{
			AddBuffOrDebuff (b, Debuffs, false);
			uiSystem.DisplayDebuff (Debuffs.Count - 1, b);
		} 
		else 
		{
			Debug.LogWarning ("[coding error]: You can't add a buff as a debuff!");
		}
	}

	public void RemoveDebuff(Buff b)
	{
		RemoveBuffOrDebuff (b, Debuffs);
	}

	public void RemoveAllDebuffs()
	{
		RemoveAllBuffsOrDebuffs (Debuffs);
	}

	private void AddBuffOrDebuff(Buff b, List<Buff> buffOrDebuffList, bool switchBuff)
	{
		if (buffOrDebuffList.Count < 4) 
		{
			if (GetBuffOrDebuffByName (buffOrDebuffList, b.BuffName) == null)
			{
				buffOrDebuffList.Add (b);
				StartCoroutine (BuffCycle (b, buffOrDebuffList, switchBuff));
			}
			else 
			{
				//Refresh already existing debuff/buff
				Buff temp = GetBuffOrDebuffByName (buffOrDebuffList, b.BuffName);
				temp.RemainingDuration = temp.Duration;
			}
		}
	}

	private void RemoveBuffOrDebuff(Buff b, List<Buff> buffOrDebuffList)
	{
		if (buffOrDebuffList.Count > 0) 
		{
			b.RemainingDuration = 0;
			//buffOrDebuffList.Remove (b);
		}
	}

	private void RemoveAllBuffsOrDebuffs(List<Buff> buffOrDebuffList)
	{
		foreach (Buff b in buffOrDebuffList) 
		{
			RemoveBuffOrDebuff (b, buffOrDebuffList);
		}
	}

	private IEnumerator BuffCycle(Buff b, List<Buff> buffOrDebuffList, bool switchBuff)
	{
		b.EffectOn ();
        Debug.Log(b.BuffName + " started.");
        b.RemainingDuration = b.Duration;
		float speed = 1f;
		float tempInterval = b.RemainingDuration;
		while (b.RemainingDuration > 0) 
		{
			yield return null;
			if (Mathf.Round(b.RemainingDuration) == Mathf.Round((tempInterval - b.IteratingEffectInterval))) 
			{
				b.IteratingEffect ();
				tempInterval = b.RemainingDuration;
			}
			b.RemainingDuration -= speed * Time.deltaTime;
		}
		b.RemainingDuration = 0;
		buffOrDebuffList.Remove (b);
		b.EffectOff ();
        Debug.Log(b.BuffName + " ended.");
		MoveIconsOneLeft (switchBuff);
	}

	private void MoveIconsOneLeft(bool TrueForBuffsFalseForDebuffs)
	{
		List<Buff> tempList;
		Buff[] tempArray;
		//GameObject[] tempIcons;
		if (TrueForBuffsFalseForDebuffs) 
		{
			tempList = Buffs;
			//tempIcons = uiSystem.BuffIconsArray;
			tempArray = tempList.ToArray ();
			int n = 0;
			for (int i = 0; i < tempArray.Length; i++) 
			{
				uiSystem.DisplayBuff (i, tempArray [i]);
				n++;
			}
			for (int i = n; i < tempArray.Length; i++) 
			{
				uiSystem.StopDisplayingBuff (i);
			}
		}
		else
		{
			tempList = Debuffs;
			//tempIcons = uiSystem.DebuffIconsArray;
			tempArray = tempList.ToArray ();
			int n = 0;
			for (int i = 0; i < tempArray.Length; i++) 
			{
				uiSystem.DisplayDebuff (i, tempArray [i]);
				n++;
			}
			for (int i = n; i < tempArray.Length; i++) 
			{
				uiSystem.StopDisplayingDebuff (i);
			}
		}
	}

	private Buff GetBuffOrDebuffByName(List<Buff> buffOrDebuffList, string buffname)
	{
		foreach (Buff b in buffOrDebuffList) 
		{
			if (b.BuffName.Equals (buffname)) 
			{
				return b;
			}
		}
		return null;
	}

	// Use this for initialization
	void Start () 
	{
		Buffs = new List<Buff> ();
		Debuffs = new List<Buff> ();
		uiSystem = ParentAlive.namePlate.buffSys;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
