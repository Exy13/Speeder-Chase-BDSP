using UnityEngine;
using System.Collections;

public class pos_sync : MonoBehaviour
{
    public Transform target;
    Vector3 offset;

    void Awake()
    {
        offset = target.transform.position - transform.position;
    }

    void Update()
    {
        if (transform)
        {
            transform.position = target.transform.position - offset;    
        }
        
    }
}
