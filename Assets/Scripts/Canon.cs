using UnityEngine;
using System.Collections;

public class Canon : MonoBehaviour
{
    public GameObject laser;

    float delay = 0.5f;
    float last = -42;

	void Start ()
    {
        if (!laser)
            Destroy(gameObject);
	}

	void Update ()
    {
        if (Time.time > delay + last)
        {
            last = Time.time;
            GameObject.Instantiate(laser, transform.position + transform.forward, transform.rotation);
        }
	}
}
