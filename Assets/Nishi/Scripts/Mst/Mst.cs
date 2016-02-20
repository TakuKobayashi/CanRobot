using UnityEngine;
using System;
using System.Collections.Generic;

public class Mst
{
	static Mst mst = null;

	public static Mst Instance  { get { return mst; } }

	// fields
	public List<MstSituation> situations;
}
