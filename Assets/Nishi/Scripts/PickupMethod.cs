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
        if(true)
        {
            Method();
        }
        else
        {
            m_NextMethod.Method();
        }
    }
}
