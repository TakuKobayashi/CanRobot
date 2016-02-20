using UnityEngine;
using System.Collections;

public class DustCheck : MonoBehaviour
{
    public bool[] m_Table;
    public int test;

    public void Awake()
    {
        m_Table[0] = test > 0;
    }
}
