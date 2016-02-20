using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public struct Situation{
	public int id;
	public string story;
	public List<int> nextSituationIds;
	public List<string> branchLabel;
}
