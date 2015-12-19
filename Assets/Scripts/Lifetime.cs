using UnityEngine;
using System.Collections;

public class Lifetime : MonoBehaviour
{
    public float lifetime = 1f;
    float death;

    void Start()
    {
        death = Time.time + lifetime;
    }

	void FixedUpdate ()
    {
        if (Time.time > death)
            Destroy(gameObject);
	}
}
