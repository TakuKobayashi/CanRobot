using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : SingletonBehaviour<GameController> {
	[SerializeField] List<Situation> mstSituations;
	[SerializeField] Prefab blockPrefab;
	[SerializeField] Vector3 addTransformVector;
	[SerializeField] GameObject parentObj;

	AbstractMethodBlock currentSelectBlock;
	List<AbstractMethodBlock> selectablBlocks;

	public void PutBlock(AbstractMethodBlock block){
		var currentSituation = mstSituations.Find ((s) => s.id == block.situation.id);
		selectablBlocks.Clear ();
		foreach (int situationId in currentSituation.nextSituationIds) {
			GameObject go = Util.InstantiateTo (parentObj, blockPrefab);
			Vector3 pos = currentSelectBlock.transform.localPosition;
			go.transform.localPosition = pos + addTransformVector;

			var nextSituation = mstSituations.Find ((s) => s.id == situationId);
			AbstractMethodBlock amb = go.GetComponent<AbstractMethodBlock>();
			amb.Initialize (nextSituation);
			amb.CurrentState = AbstractMethodBlock.State.Candidate;
			selectablBlocks.Add (amb);
		}
		currentSelectBlock = block;
		currentSelectBlock.CurrentState = AbstractMethodBlock.State.Selecting;
	}
}
