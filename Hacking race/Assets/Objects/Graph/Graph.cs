using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph
{
    private LinkedList<Vertex> vertices = new LinkedList<Vertex>();
    private LinkedList<Edge> edges = new LinkedList<Edge>();

    public void AddVertex(Vertex vertex) => vertices.AddLast(vertex);
    public void AddEdge(Edge edge) => edges.AddLast(edge);

    public Edge GetEdgeByVertexes(Vertex first, Vertex second)
    {
        foreach (Edge edge in edges)
            if (edge.IsSameVertex(first, second)) return edge;
        return null;
    }
}
