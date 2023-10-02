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

    public void SetPreset()
    {
        AdjacentEdges.Clear();
    }

    public override GraphicalMovementParameters GetParameters(Vector3 direction, GraphicalMovementParameters parameters)
    {
        //Debug.Log("in vertex point");
        if (direction == Vector3.zero)
            return new GraphicalMovementParameters(this, this);

        Edge edge = GetEdge(direction);
        if (edge == null)
            return new GraphicalMovementParameters(this, this);

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
            //Debug.Log(angle + " " + edgeAngle + " " + directionAngle + " " + minAngle + " " + edge.name);
        }
        return minAngle >= 55 ? null : selectedEdge;
    }

    public void AddEdge(Edge edge)
    {
        if (AdjacentEdges.Contains(edge)) return;
        AdjacentEdges.AddLast(edge);
    }
    public void RemoveEdge(Edge edge)
    {
        AdjacentEdges.Remove(edge);
    }
    public Vertex GetRandomAdjacentVertex()
    {
        int n = (int)UnityEngine.Random.Range(0, AdjacentEdges.Count) % AdjacentEdges.Count;
        foreach (Edge edge in AdjacentEdges )
        {
            if (n == 0)
                return edge.GetOtherVertex(this);
            --n;
        }
        return null;
    }
}
