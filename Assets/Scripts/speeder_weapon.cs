using UnityEngine;
using System.Collections;

public class speeder_weapon : MonoBehaviour
{
    public GameObject laser_effect;
    public float divergence = 3f;

    private Transform[] canons;
    private bool canon_side;

    private float laser_delay = 0.1f;
    private float next_laser;

    void Awake()
    {
        canons = new Transform[2];
        canons[0] = transform.FindChild("Lasor0");
        canons[1] = transform.FindChild("Lasor1");
        canon_side = false;
        next_laser = -42f;
    }

    void FixedUpdate()
    {
        if (Input.GetAxis("Trigger") < 0 && Time.time > next_laser)
        {
            Shoot();
            next_laser = Time.time + laser_delay;
        }
    }

    void Shoot()
    {
            Vector3 modifier = new Vector3(Random.Range(-1f, 1f),
                                           Random.Range(-1f, 1f),
                                           Random.Range(-1f, 1f));
            int id = canon_side ? 1 : 0;
            GameObject.Instantiate(laser_effect, canons[id].position, Quaternion.RotateTowards(canons[id].rotation,
                                                                         Quaternion.FromToRotation(canons[id].forward, modifier), Random.Range(0f, divergence)));
            canon_side = !canon_side;
    }
}
