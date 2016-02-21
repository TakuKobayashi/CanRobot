using UnityEngine;
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
        if (animInfo.normalizedTime < 1.0f)
        {
            this.Method();
        }
        else
        {
            m_NextMethod.Method();
        }
    }
}
