using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    public Vector3 move;

	void Update () 
    {
        transform.position += move * Time.deltaTime;
	}
}
