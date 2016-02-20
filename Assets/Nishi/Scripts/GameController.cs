using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : SingletonBehaviour<GameController>
{
    // 選択可能なブロックのリスト
    [SerializeField]
    List<Situation> mstSituations;
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
    public void PutBlock(AbstractMethodBlock block)
    {
        //現在の状態
        var currentSituation = mstSituations.Find((s) => s.id == block.situation.id);
        //選択できるブロックの　リスト初期化
        selectablBlocks.Clear();

        //
        foreach (int situationId in currentSituation.nextSituationIds)
        {
            //次のメソッドを取得するオブジェクト
            GameObject go = Util.InstantiateTo(parentObj, blockPrefab);
            Vector3 pos = currentSelectBlock.transform.localPosition;

            //次のメソッドの位置に移動
            go.transform.localPosition = pos + addTransformVector;

            //次をメソッド探す
            var nextSituation = mstSituations.Find((s) => s.id == situationId);

            //次のメソッド起動            
            AbstractMethodBlock amb = go.GetComponent<AbstractMethodBlock>();
            amb.Initialize(nextSituation);
            amb.CurrentState = AbstractMethodBlock.State.Candidate;
            selectablBlocks.Add(amb);
        }

        currentSelectBlock = block;
        currentSelectBlock.CurrentState = AbstractMethodBlock.State.Selecting;
    }
}
