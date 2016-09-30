using UnityEngine;
using System.Collections;
using System;

public class MusicZone : IComparable<MusicZone> {
	public int type;
	public int size;
	public string name;
	public int start;
	public int length;

	public MusicZone(string newName, int newSize, int newType){
		name = newName;
		size = newSize;
		type = newType;
	}

	//This method is required by the IComparable
	//interface. 
	public int CompareTo(MusicZone other)
	{
		if(other == null)
		{
			return 1;
		}
		
		//Return the difference in power.
		return type - other.type;
	}
}
