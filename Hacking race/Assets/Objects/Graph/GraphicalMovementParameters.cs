using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicalMovementParameters
{
    public Vertex Aim { get; private set; }
    public ElementOfGraph Element { get; private set; }
    public GraphicalMovementParameters(Vertex vertex, ElementOfGraph element)
    {
        Element = element;
        Aim = vertex;
    }
    public Vector3 GetDirection(Vector3 position)
    {
        return (Aim.Transform.position - position).normalized;
    }
}
