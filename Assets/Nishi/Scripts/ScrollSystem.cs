using UnityEngine;
using System.Collections;

public class ScrollSystem : MonoBehaviour {

    RectTransform rect;

    Vector3 oldMousePosition;
    Vector3 nowMousePosition;

    // Use this for initialization
    void Start ()
    {
        rect = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetMouseButtonDown(1))
        {
            oldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButton(1))
        {
            nowMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            nowMousePosition.z = 0;
            oldMousePosition.z = 0;
            rect.position += (nowMousePosition + oldMousePosition) / 10;
            oldMousePosition = nowMousePosition;
        }
        
	}
}
