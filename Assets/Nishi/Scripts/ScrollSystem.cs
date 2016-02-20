using UnityEngine;
using System.Collections;

public class ScrollSystem : MonoBehaviour {

    RectTransform rect;

    Vector3 nowMousePosition;
    Vector3 nextMousePosition;

    // Use this for initialization
    void Start ()
    {
        rect = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        nowMousePosition = Vector3.zero;
        nextMousePosition = Vector3.zero;
        if(Input.GetMouseButtonDown(0))
        {
            nowMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButtonUp(0))
        {
            nextMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            nowMousePosition.z = 0;
            nextMousePosition.z = 0;
            rect.position += nowMousePosition + nextMousePosition;
        }
        
	}
}
