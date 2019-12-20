using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    //public GameObject m_CubePrefab;
    public List<GameObject> m_ListCubePrefab;
    public Transform m_Parent;

    public void CreateCube()
    {
        for (float x = 0; x < 5; x+=1.08f)
        {
            for (float z = 0; z < 5; z+=1.08f)
            {
                //Instantiate(m_CubePrefab, new Vector3(x, 0, z), Quaternion.identity);
                for (int y = 0; y < 5; y++)
                {
                    Instantiate(m_ListCubePrefab[Random.Range(0, m_ListCubePrefab.Count)], new Vector3(x, y, z), Quaternion.identity, m_Parent);
                }
            }
        }
    }

    // Use this for initialization
    void Start()
    {
        CreateCube();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
