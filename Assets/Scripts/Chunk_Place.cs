using UnityEngine;
using System.Collections;

public class Chunk_Place : MonoBehaviour
{
    protected static Transform[] FindChilds(Transform tr, string name)
    {
        Transform t = tr.FindChild(name);
        Transform[] list = new Transform[t.childCount];
        for (int i = 0; i < t.childCount; i++)
            list[i] = t.GetChild(i);

        return list;
    }

    protected static void UseSlot(Transform tr, Transform[] slots, float chance, bool[] forbidden, bool[] forbidden_self, GameObject model)
    {
        int max = 0;
        if(forbidden != null)
            max = forbidden.Length - 1;
        int placed = 0;

        for (int i = 0; i < slots.Length; i++)
        {
            if (Random.Range(0f, 1f) < chance && ((forbidden == null) || !forbidden[i]))
            {
                placed++;
                if(forbidden_self != null)
                    forbidden_self[i] = true;
                Vector3 modifier = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
                Transform to = (GameObject.Instantiate(model, slots[i].position + modifier, slots[i].rotation) as GameObject).transform;
                to.SetParent(tr);

                if (forbidden != null && placed >= max)
                    break;
            }
        }
    }
}
