﻿using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class MoveMethodBlock : AbstractMethodBlock {

    public AbstractMethodBlock DebugNextBlock = null;
    [TooltipAttribute("進みたい方向に1を入力")]
    public Vector3 m_Move;
    [TooltipAttribute("進む力")]
    public float m_MovePower = 100;

	// Use this for initialization
	void Start () {
        m_NextMethod = DebugNextBlock;
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    //プレイヤーを検索し移動を開始（ディレイ0.5f秒）
    public override void Method()
    {
        Image player = GameObject.FindGameObjectWithTag("Player").GetComponent<Image>();
        if (m_NextMethod != null)
        {
            LeanTween.move(player.rectTransform, player.rectTransform.localPosition + (m_MovePower * m_Move), 1f)
                .setDelay(0.5f)       
                .setOnComplete(() => {m_NextMethod.Method(); });
                    Debug.Log(gameObject.name+"次の処理に移行");
        }
        else
        {

            LeanTween.move(player.rectTransform, player.rectTransform.localPosition + (m_MovePower * m_Move), 1f)
                .setDelay(0.5f);
            Debug.Log(gameObject.name+"次の処理がありません");
        }
    }

    public void DebugMethodStart()
    {
        this.Method();
    }
}
