using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldGen : MonoBehaviour
{
    float gen_distance = 550f;
    Transform last_block;
    public GameObject chunk;
    int gen;

    bool even;

	void Awake()
    {
        last_block = transform;
	}

    void Start()
    {
        SpawnChunk();
    }

	void FixedUpdate ()
    {
        if (!last_block)
            last_block = transform;

        if (last_block.transform.position.z < gen_distance)
            SpawnChunk();
	}

    void SpawnChunk()
    {
        gen++;
        even = !even;
        Vector3 pos = last_block.position + new Vector3(0f, 0f, 24f);
        GameObject o = GameObject.Instantiate(chunk, pos, Quaternion.identity) as GameObject;
        o.GetComponent<Chunk_Decorate>().even = even;
        o.GetComponent<Chunk_Obstacle>().last = last_block.GetComponent<Chunk_Obstacle>();
        o.name = "chunk_" + gen;
        last_block = o.transform;
    }



    /*
    Transform SpawnGround()
    {
        Transform last = transform;
        Vector3 origin = transform.position;
        origin.x -= (width / 2f) * 24.7f;
        origin.z = last_block.position.z + 24.7f;
        

        for (int i = 0; i < width; i++)
        {
            origin.y = base_height;
            GameObject o = GameObject.Instantiate(ground_model, origin, Quaternion.identity) as GameObject;
            last = o.transform;
            origin.y = height_roof;
            GameObject.Instantiate(roof_model, origin, Quaternion.identity);
            origin.x += 24.7f;
        }

        return last;
    }
    
    void SpawnWall()
    {
        Vector3 origin = transform.position;
        origin.y = base_height - 0.5f;
        origin.z = last_block.position.z + 24.7f;
        

        for (int i = 0; i < height; i++)
        {
            origin.x =  - (width / 2f) * 24.7f;
            GameObject.Instantiate(wall_model, origin, Quaternion.identity);
            origin.x = (width / 2f) * 24.7f;
            origin.z += 25.4f;
            GameObject.Instantiate(wall_model, origin, Quaternion.Euler(0,180,0));
            origin.z -= 25.4f;
            origin.y += 24.7f;
        }
    }

    void SpawnObstacles(List<Block> placed)
    {
        if (Random.Range(0, 3) == 1)
        {
            Vector3 pillar_pos;
            do
            {
                float x = Random.Range(-(corridor.x / 2f), corridor.x / 2f);
                float z = Random.Range(-11f, 11f);
                pillar_pos = new Vector3(x, -0.5f, z);
                pillar_pos += last_block.position;
            } while (TouchBlock(pillar_pos, placed));

            GameObject.Instantiate(obstacles[0], pillar_pos, Quaternion.identity);
            placed.Add(new Block(pillar_pos, new Vector3(1, 9, 1)));

            int place = Random.Range(0, 9);
            List<int> used = new List<int>();
            for (int y = 2; place > 0; y += 2)
            {
                if (Random.Range(0, 2) == 1 && !used.Contains(y))
                {
                    place--;
                    Vector3 pipe_pos = pillar_pos;
                    pipe_pos.x += 3;
                    pipe_pos.y += y;
                    GameObject.Instantiate(obstacles[1], pipe_pos, Quaternion.identity);
                    used.Add(y);
                }

                if (y >= 15)
                    y = 1;
            }
            

            pillar_pos.x += 30;
            GameObject.Instantiate(obstacles[0], pillar_pos, Quaternion.identity);
            placed.Add(new Block(pillar_pos, new Vector3(1, 9, 1)));
        }

        if (Random.Range(0, 3) == 1)
        {
            Vector3 box_pos;
            do
            {
                float x = Random.Range(-(corridor.x / 2f), corridor.x / 2f);
                float z = Random.Range(-11f, 11f);
                box_pos = new Vector3(x, -0.5f, z);
                box_pos += last_block.position;
            } while (TouchBlock(box_pos, placed));

            GameObject.Instantiate(obstacles[2], box_pos, Quaternion.identity);
            placed.Add(new Block(box_pos, new Vector3(1, 9, 1)));
        }
    }

    void SpawnProps(List<Block> placed)
    {
        if (Random.Range(0, 4) == 1)
        {
            Vector3 lamp_pos;
            do
            {
                float x = Random.Range(-5f, 5f);
                float z = Random.Range(-11f, 11f);
                lamp_pos = new Vector3(x, 0f, z);
                lamp_pos += last_block.position;
                lamp_pos.y = height_roof;
            } while (TouchBlock(lamp_pos, placed));

            GameObject.Instantiate(props[0], lamp_pos, Quaternion.identity);
            placed.Add(new Block(lamp_pos, new Vector3(1f, 0.5f, 1f)));
        }
    }

    bool TouchBlock(Vector3 elt, List<Block> placed)
    {
        foreach (Block b in placed)
        {
            if (elt.x > b.x && elt.x < b.x + b.w)
                if (elt.z > b.z && elt.z < b.z + b.l)
                    return true;
        }
        return false;
    }
     * */
}
