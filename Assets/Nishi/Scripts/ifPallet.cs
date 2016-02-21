using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class ifPallet : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public RectTransform obj;
    private Vector3 m_position;

    public GameObject m_MethodPrefab;
    public GameObject m_DummyPrefab;

    public void Start()
    {
        obj = GetComponent<RectTransform>();
        m_position = obj.position;
    }

    public void OnBeginDrag(PointerEventData e)
    {
        m_position = obj.position;
        obj.SetAsFirstSibling();
    }
    public void OnDrag(PointerEventData e)
    {

        obj.SetAsLastSibling();
        obj.position = e.position;
    }
    public void OnEndDrag(PointerEventData e)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
        if (hit.collider == null)
        {
            obj.position = m_position;
            return;
        }
        if (hit.collider.tag == "dummy")
        {
            AbstractMethodBlock past = hit.collider.gameObject.GetComponent<DummyMethod>().m_PastMethod;

            GameObject go = (GameObject)Instantiate(m_MethodPrefab, hit.collider.gameObject.transform.localPosition, Quaternion.identity);
            go.transform.SetParent(GameObject.Find("Container").transform, false);
            past.SetNext(go.GetComponent<AbstractMethodBlock>());
            Destroy(hit.collider.gameObject);

            GameObject dummy = (GameObject)Instantiate(m_DummyPrefab, hit.collider.gameObject.transform.localPosition + new Vector3(100, -65, 0), Quaternion.identity);
            dummy.transform.SetParent(GameObject.Find("Container").transform, false);
            dummy.GetComponent<DummyMethod>().m_PastMethod = go.GetComponent<AbstractMethodBlock>();

            GameObject dummy2 = (GameObject)Instantiate(m_DummyPrefab, hit.collider.gameObject.transform.localPosition + new Vector3(-110, -65, 0), Quaternion.identity);
            dummy2.transform.SetParent(GameObject.Find("Container").transform, false);
            dummy2.GetComponent<DummyMethod>().m_PastMethod = go.GetComponent<AbstractMethodBlock>();
        }
        obj.position = m_position;
    }

}

