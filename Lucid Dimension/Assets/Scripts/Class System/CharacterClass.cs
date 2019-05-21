using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceType
{
	Mana,
	Adrenaline,
	Concentration
};

public abstract class CharacterClass 
{
	protected ResourceType resourceType;

	public ResourceType GetResourceType()
	{
		return resourceType;
	}

	public abstract void SetResourceType ();

	public CharacterClass()
	{
		SetResourceType ();
	}

}
