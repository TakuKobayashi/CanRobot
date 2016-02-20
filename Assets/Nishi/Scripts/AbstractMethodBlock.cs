using UnityEngine;
using System.Collections;

public abstract class AbstractMethodBlock : MonoBehaviour {
	public enum State{
		Past,
		Selecting,
		Candidate,
		None,
	}

	public MstSituation situation;
	public State CurrentState;

	public void Initialize(MstSituation situation){
		this.situation = situation;
	}

    //次のメソッドブロック
    public AbstractMethodBlock m_NextMethod;

    //固有の処理を書く
    public abstract void Method();
    public virtual void SetNext(AbstractMethodBlock abs)
    {
        m_NextMethod = abs;
    }

}
