using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ForMethodBlock : AbstractMethodBlock {

    public AbstractMethodBlock DebugNextBlock = null;
    [TooltipAttribute("戻るオブジェクト")]
    public AbstractMethodBlock m_LoopMethod = null;
    [TooltipAttribute("ループ回数")]
    public int m_LoopMaxCount = 0;

    private int m_LoopCount = 0;
	// Use this for initialization
	void Start () {
        m_NextMethod = DebugNextBlock;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void Method()
    {
        gameObject.GetComponent<Image>().color = Color.yellow; //デバッグ用に色を変える
        m_LoopCount++;
        if (m_LoopMaxCount >= m_LoopCount)
        {
            Debug.Log(gameObject.name + "ループ中");
            if (m_LoopMethod != null) m_LoopMethod.Method();
        }
        else
        {
            gameObject.GetComponent<Image>().color = Color.white; //デバッグ用に色を変える
            Debug.Log(gameObject.name + "ループ終了");
            if (m_NextMethod != null) m_NextMethod.Method();
        }
    }
}
