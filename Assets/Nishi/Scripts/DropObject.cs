using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropUI : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData e)
    {
        DragObject.obj.position = transform.position;
    }
}
