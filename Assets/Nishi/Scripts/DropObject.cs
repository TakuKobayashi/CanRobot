using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropObject : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData e)
    {
        e.position = transform.position;
    }
}
