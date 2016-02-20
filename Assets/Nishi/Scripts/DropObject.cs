using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropObject : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData e)
    {
        DragObject.obj.position = transform.position;
    }
}
