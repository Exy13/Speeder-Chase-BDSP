using UnityEngine;
using System.Collections;

public class speeder_wings : MonoBehaviour
{
    private Quaternion[] wings_base;
    private Transform[] wings;

    float rotation_multiplier = 150F;

    void Awake()
    {
        wings = new Transform[2];
        wings[0] = transform.FindChild("Object001");
        wings[1] = transform.FindChild("Object002");
        wings_base = new Quaternion[2];
        wings_base[0] = wings[0].transform.localRotation;
        wings_base[1] = wings[1].transform.localRotation;
    }

    void FixedUpdate()
    {
        if (Input.GetAxis("horizontal") == 0f)
        {
            wings[0].localRotation = Quaternion.Slerp(wings[0].localRotation, wings_base[0], 0.15f);
            wings[1].localRotation = Quaternion.Slerp(wings[1].localRotation, wings_base[1], 0.15f);
        }
        else
        {
            if (Input.GetAxis("horizontal") > 0)
            {
                if (Quaternion.Angle(wings[1].localRotation, wings_base[1]) < 35 && wings[1].localEulerAngles.x <= 1f || wings[1].localEulerAngles.x > 330)
                    wings[1].Rotate(Vector3.right, -Input.GetAxis("horizontal") * Time.fixedDeltaTime * rotation_multiplier, Space.Self);
            }
            else
                if (Quaternion.Angle(wings[0].localRotation, wings_base[0]) < 35 && wings[0].localEulerAngles.x < 35 || wings[0].localEulerAngles.x > 359.5)
                    wings[0].Rotate(Vector3.right, Input.GetAxis("horizontal") * Time.fixedDeltaTime * rotation_multiplier, Space.Self);
        }
    }
}
