using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertex : ElementOfGraph
{
    [field: SerializeField]
    public Vertex[] AdjacentVertices { get; private set; } = { };
    public LinkedList<Edge> AdjacentEdges { get; private set; } = new LinkedList<Edge>();
    public Transform Transform { get; private set; }

    private void Awake()
    {
        Transform = GetComponent<Transform>();
    }


    public override GraphicalMovementParameters GetParameters(Vector3 direction, GraphicalMovementParameters parameters)
    {
        //Debug.Log("in vertex point");
        if (direction == Vector3.zero)
            return new GraphicalMovementParameters(this, this);

        Edge edge = GetEdge(direction);
        Vertex aim = edge.GetOtherVertex(this);
        ElementOfGraph element = edge;
        return new GraphicalMovementParameters(aim, element);
    }
    public Edge GetEdge(Vector3 direction)
    {
        Edge selectedEdge = AdjacentEdges.First.Value;
        float minAngle = 360;
        float directionAngle = Calculator.GetAngleOfRotationToDirectionVector(direction);
        foreach (Edge edge in AdjacentEdges)
        {
            float edgeAngle = Calculator.GetAngleOfRotationToDirectionVector(
                Calculator.GetDirectionalVectorFromOneToOtherObject(Transform, edge.Transform));
            float angle = Calculator.CalculateAngle(directionAngle, edgeAngle);
            if (angle < minAngle)
            {
                minAngle = angle;
                selectedEdge = edge;
            }
            Debug.Log(angle + " " + edgeAngle + " " + directionAngle + " " + minAngle + " " + edge.name);
        }
        return selectedEdge;
    }


    public void AddEdge(Edge edge) => AdjacentEdges.AddLast(edge);
}
