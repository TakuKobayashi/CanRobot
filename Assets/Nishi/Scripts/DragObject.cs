using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class DragObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static RectTransform obj;
    public Vector3 m_position;

    public void Start()
    {
        m_position = obj.localPosition;
    }

    public void OnBeginDrag(PointerEventData e)
    {
        obj = GetComponent<RectTransform>();
        obj.SetAsFirstSibling();
    }
    public void OnDrag(PointerEventData e)
    {
        obj.SetAsLastSibling();
        obj.position = e.position;
    }
    public void OnEndDrag(PointerEventData e)
    {
        obj.SetAsLastSibling();
        GameController.Instance.PutBlock(m_position);
        //if(m_isDead) Destroy(gameObject);
        

    }

}
