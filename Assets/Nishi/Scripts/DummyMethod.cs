using UnityEngine;
using System.Collections;
using System;

public class DummyMethod : AbstractMethodBlock
{
    public AbstractMethodBlock m_PastMethod;

    public override void Method()
    {
        Debug.Log("処理の終了");
    }
}
