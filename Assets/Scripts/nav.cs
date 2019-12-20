using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class nav : MonoBehaviour
{
    private LineRenderer m_LineRenderer;
    private NavMeshAgent m_Nav;
    public Transform m_Target;

    // Use this for initialization
    void Start()
    {
        m_LineRenderer = GetComponent<LineRenderer>();
        m_Nav = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        m_Nav.SetDestination(m_Target.position);
        Vector3[] path = m_Nav.path.corners;
        //为了使线段提高
        for (int i = 0; i < path.Length; i++)
        {
            path[i] = path[i] + new Vector3(0, 1, 0);
        }
        //m_LineRenderer.SetVertexCount(path.Length);
        //m_LineRenderer.positionCount = path.Length;
        for (int i = 0; i < path.Length; i++)
        {
            m_LineRenderer.SetPosition(i, path[i]);
        }
    }
}

