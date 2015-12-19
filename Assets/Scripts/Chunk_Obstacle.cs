using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chunk_Obstacle : Chunk_Place
{
    [HideInInspector]
    public bool[] pillar_placed;
    [HideInInspector]
    public bool[] pipes_placed;
    [HideInInspector]
    public Chunk_Obstacle last;

    public GameObject pillar_model;
    public GameObject pipe_model;

    void Awake()
    {
        pillar_placed = new bool[4] { false, false, false, false};
        pipes_placed = new bool[5] { false, false, false, false, false };
    }

    void Start()
    {
        if (last)
        {
            Transform[] pillars = FindChilds(transform, "Pillar");
            UseSlot(transform, pillars, 0.1f, last.pillar_placed, pillar_placed, pillar_model);

            Transform[] pipes = FindChilds(transform, "Pipes");
            UseSlot(transform, pipes, 0.15f, last.pipes_placed, pipes_placed, pipe_model);
        }
    }
}
