using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class DragObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static RectTransform obj;
    public bool m_isDead = true;

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
        if(m_isDead) Destroy(gameObject);
    }

}
