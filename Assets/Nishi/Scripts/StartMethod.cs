using UnityEngine;
using System.Collections;
using System;

public class StartMethod : AbstractMethodBlock {

    public override void Method()
    {
        m_NextMethod.Method();
    }
}
