using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class speeder_damage : MonoBehaviour
{
    float life = 500f;
    public RectTransform life_bar;
    public GameObject explosion;
    public GameObject explosion_small;
    public GameObject smoke;

    private Transform left_overheat;
    bool exploded;

    void Awake()
    {
        exploded = false;
        left_overheat = transform.FindChild("OverheatL");
    }

    void OnTriggerEnter(Collider other)
    {
        life -= 100;
        life_bar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, life);

        (Instantiate(explosion, other.ClosestPointOnBounds(transform.position), transform.rotation) as GameObject).transform.SetParent(other.transform);

        if (life < 150 && !exploded)
        {
            (Instantiate(explosion_small, left_overheat.position, transform.rotation) as GameObject).transform.SetParent(other.transform);
            (Instantiate(smoke, left_overheat.position, transform.rotation) as GameObject).transform.SetParent(left_overheat);
            exploded = true;
        }

        if (life < 0)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
