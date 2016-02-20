using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class MstSituation{
	public int id;
	public string message;
	public List<MstChoice> choices;
}

public class MstChoice{
	public int id;
	public int situation_id;
	public int next_situation_id;
	public string label;

	public MstSituation NextSituation{
		get{
			return Mst.Instance.situations.Find ((s) => s.id == next_situation_id);
		}
	}
}