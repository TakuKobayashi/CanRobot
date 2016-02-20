using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DropDestroy : MonoBehaviour, IDropHandler
{

    public void OnDrop(PointerEventData e)
    {
        Destroy(e.pointerDrag);
    }
}
