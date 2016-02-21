using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartButton : MonoBehaviour {

    Button m_Button;

	// Use this for initialization
	void Start ()
    {
        m_Button = GetComponent<Button>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ButtonNonActive()
    {
        m_Button.interactable = false;
    }

    public void ButtonActive()
    {
        m_Button.interactable = true;
    }
}
