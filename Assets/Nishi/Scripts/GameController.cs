using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class GameController : SingletonBehaviour<GameController>
{
    // 選択可能なブロックのリスト
    [SerializeField]
    List<MstSituation> mstSituations;
    [SerializeField]
    Prefab blockPrefab;
    [SerializeField]
    Vector3 addTransformVector;
    [SerializeField]
    GameObject parentObj;

    // 現在のブロック
    AbstractMethodBlock currentSelectBlock;
    List<AbstractMethodBlock> selectablBlocks;

    /// <summary>
    /// ブロックを置く
    /// </summary>
    /// <param name="block"></param>
	public void PutBlock(Vector3 pointUpPos){
		var block = hitBlock (pointUpPos);
		if (block == null) return;

        //選択できるブロックの　リスト初期化
        selectablBlocks.Clear();

        //
		foreach (MstChoice choice in block.situation.choices)
        {
            //次のメソッドを取得するオブジェクト
            GameObject go = Util.InstantiateTo(parentObj, blockPrefab);
            Vector3 pos = currentSelectBlock.transform.localPosition;

            //次のメソッドの位置に移動
            go.transform.localPosition = pos + addTransformVector;

            //次をメソッド探す
			//var nextSituation = choice.NextSituation;
			var nextSituation = mstSituations.Find ((s) => s.id == choice.next_situation_id);


            //次のメソッド起動
            AbstractMethodBlock amb = go.GetComponent<AbstractMethodBlock>();
            amb.Initialize(nextSituation);
            amb.CurrentState = AbstractMethodBlock.State.Candidate;
            selectablBlocks.Add(amb);
        }

        currentSelectBlock = block;
		foreach(var b in selectablBlocks){
			if (b == block) {
				currentSelectBlock.CurrentState = AbstractMethodBlock.State.Selecting;
			} else {
				currentSelectBlock.CurrentState = AbstractMethodBlock.State.None;
			}
		}
    }

	public AbstractMethodBlock hitBlock(Vector3 pointUpPos){
		return selectablBlocks.Find ((a) => {
			Vector3 pos = a.transform.localPosition;
			Vector3 wh = a.GetComponent<Collider>().bounds.size;
			return (pos.x - wh.x / 2 <= pointUpPos.x) &&
				(pos.x + wh.x / 2 <= pointUpPos.x) &&
				(pos.y - wh.y / 2 <= pointUpPos.y) &&
				(pos.y + wh.y / 2 <= pointUpPos.y) &&
				(pos.z - wh.z / 2 <= pointUpPos.z) &&
				(pos.z + wh.z / 2 <= pointUpPos.z);
		});
	}
}
