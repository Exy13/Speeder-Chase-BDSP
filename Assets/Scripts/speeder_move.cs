using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class speeder_move : MonoBehaviour
{
    float rotation_multiplier = 50F;
    float speed_multiplier = 15F;

    Quaternion base_rotation;

    

    

    Vector3 force;

    void Awake()
    {
        base_rotation = transform.rotation;
        force = Vector3.zero;
    }

    void Update()
    {
        if (Input.GetAxis("horizontal") == 0f)
            transform.rotation = Quaternion.Slerp(transform.rotation, base_rotation, 0.05f);
        else if (Quaternion.Angle(base_rotation, transform.rotation) < 20)
                transform.Rotate(Vector3.up, Input.GetAxis("horizontal") * Time.fixedDeltaTime * rotation_multiplier);

        if (Input.GetAxis("vertical") == 0f)
            transform.rotation = Quaternion.Slerp(transform.rotation, base_rotation, 0.05f);
        else if (Quaternion.Angle(base_rotation, transform.rotation) < 20)
            transform.Rotate(Vector3.left, Input.GetAxis("vertical") * Time.fixedDeltaTime * rotation_multiplier);

        Vector3 input = new Vector3(Input.GetAxis("horizontal"), Input.GetAxis("vertical"), 0f) / 4f;
        force += input;
        Vector3 move = force * Time.fixedDeltaTime * speed_multiplier;
        Vector3 next = transform.position + move;

        if (next.y < -11 || next.y > 9)
            move.y = 0;
        if (next.x < -20 || next.x > 20)
            move.x = 0;

        transform.Translate(move, Space.World);
        force = Vector3.Lerp(Vector3.zero, force, 0.9f);
    }

    

    
}
