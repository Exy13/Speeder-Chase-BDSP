using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class generated_object : MonoBehaviour
{
    ScoreManager score;

    float speed = 50f;
    const bool move = true;

    void Awake()
    {
        score = GameObject.FindObjectOfType<ScoreManager>();
    }


	void FixedUpdate ()
    {
        if (!move)
            return;

        if (transform.position.z <= -50)
        {
            score.score++;
            Destroy(gameObject);            
        }
        transform.Translate(-Vector3.forward * Time.deltaTime * speed, Space.World);
	}
}
