using UnityEngine;
using CanRobot;
using System.Collections;
using System;

public class DummyMethod : AbstractMethodBlock
{
    public AbstractMethodBlock m_PastMethod;

    public override void Method()
    {
        SceneManager.GameOverLoad();
        Debug.Log("処理の終了");
        
    }
}
