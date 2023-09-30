using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour
{
    public Vertex First { get; private set; }
    public Vertex Second { get; private set; }

    public void SetPreset(Vertex first, Vertex second)
    {
        First = first;
        Second = second;
    }

    public bool IsSameVertex(Vertex first, Vertex second)
    {
        return First == first && Second == second ||
            First == second && Second == first;
    }

}
