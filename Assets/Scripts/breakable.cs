using UnityEngine;
using System.Collections;

public class breakable : MonoBehaviour
{
    public GameObject[] death_effect;
    public GameObject[] wreck_model;
    public float health = 150f;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            health -= 50f;
            if (health <= 0)
            {
                Pop("Death", death_effect);
                Pop("Wreak", wreck_model);
                Destroy(gameObject);
            }
        }
    }

    void Pop(string name, GameObject[] model)
    {
        Transform t = transform.FindChild(name);
        foreach(GameObject g in model)
            (GameObject.Instantiate(g, t ? t.position : transform.position,
                                       t ? t.rotation : Quaternion.identity
                                   ) as GameObject).transform.SetParent(transform.parent);
    }
}
