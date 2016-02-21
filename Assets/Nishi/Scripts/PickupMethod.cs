using UnityEngine;
using CanRobot.Methods;
using System.Collections;
using System;

public class PickupMethod : AbstractMethodBlock {

    private Animator m_animator;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void Method()
    {
        m_animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        AnimatorStateInfo animInfo = m_animator.GetCurrentAnimatorStateInfo(0);
        if (!animInfo.IsName("PickUp"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().PickUp();
        }

        if (animInfo.normalizedTime < 1.0f)
        {
            m_NextMethod.Method();
            
        }
        else
        {
            this.Method();
        }
    }

    //private IEnumerable Animation()
    //{

    //    yield return null; // ステートの反映に1フレームいる。解せぬ
    //    yield return new WaitForAnimation(animator, 0);
    //}
}
