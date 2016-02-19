using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class IfMethodBlock : AbstractMethodBlock {

    [Tooltip("行先メソッド一覧")]
    public AbstractMethodBlock[] m_NextMethods;
    
    private int value = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void Method()
    {
        gameObject.GetComponent<Image>().color = Color.yellow; //デバッグ用に色を変える
        Debug.Log("行先" + value);
        if (m_NextMethods[value] != null)
        {
            gameObject.GetComponent<Image>().color = Color.white; //デバッグ用に色を変える
            m_NextMethods[value].Method();
        }
        else
        {
            gameObject.GetComponent<Image>().color = Color.white; //デバッグ用に色を変える
            Debug.Log(gameObject.name + "次の処理がありません");
        }
    }

    //プルダウンから選択されている項目を引き出す
    public void OnValueChanged(int result)
    {
        value = result;
    }
}
