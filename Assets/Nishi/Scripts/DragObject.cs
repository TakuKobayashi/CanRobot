using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class DragObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static RectTransform obj;

    public void OnBeginDrag(PointerEventData e)
    {
        obj = GetComponent<RectTransform>();
        obj.SetAsFirstSibling();
    }
    public void OnDrag(PointerEventData e)
    {
        obj.position = e.position;
    }
    public void OnEndDrag(PointerEventData e)
    {
        obj.SetAsLastSibling();
    }
}
