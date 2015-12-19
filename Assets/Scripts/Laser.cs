using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour
{
    float speed_modifier = 70f;
    public GameObject death_effect;

	void Start ()
    {
        if (!death_effect)
            Destroy(gameObject);
	}
	
	void Update ()
    {
        Vector3 direction = transform.forward * speed_modifier * Time.fixedDeltaTime;
        Ray r = new Ray(transform.position, direction.normalized);
        RaycastHit hit;

        if(Physics.Raycast(r, out hit, 2f))
            transform.position = hit.point - Vector3.forward * 0.5f;
        else
            transform.position += direction;
                
	}

    void OnTriggerEnter(Collider other)
    {
        GameObject.Instantiate(death_effect, transform.position, transform.rotation);
        Destroy(transform.parent.gameObject);
    }
}
