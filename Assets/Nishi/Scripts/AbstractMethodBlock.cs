using UnityEngine;
using System.Collections;

public abstract class AbstractMethodBlock : MonoBehaviour {

    //次のメソッドブロック
    protected AbstractMethodBlock m_NextMethod;

    //固有の処理を書く
    public abstract void Method();

}
