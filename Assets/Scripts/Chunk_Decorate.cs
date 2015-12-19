using UnityEngine;
using System.Collections;

public class Chunk_Decorate : Chunk_Place
{
    public GameObject Light;
    public GameObject Plate;
    public bool even;

    void Start()
    {
        if(even)
        {
            Transform t = transform.FindChild("Light");
            t = (GameObject.Instantiate(Light, t.position, t.rotation) as GameObject).transform;
            t.SetParent(transform);

            Transform[] plates = FindChilds(transform, "Plates");
            UseSlot(transform, plates, 0.2f, null, null, Plate);

        }
    }
}
