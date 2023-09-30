using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphCreator : MonoBehaviour
{
    [SerializeField] private Vertex[] vertices;
    [SerializeField] private GameObject _edgePref;

    private Transform _transform;
    private void Awake()
    {
        _transform = transform;
    }
    public Graph CreateGraph()
    {
        Graph graph = new Graph();
        int id = 0;
        foreach (Vertex vertex in vertices) 
        { 
            //Debug.Log(vertex.gameObject.name);
            graph.AddVertex(vertex); 
            if (vertex.AdjacentVertices == null) { Debug.Log(vertex.gameObject.name); }
            foreach (Vertex adjacentVertex in vertex.AdjacentVertices)
            {
                if (!graph.GetEdgeByVertexes(vertex, adjacentVertex))
                {
                    Edge edge = CreateEdge(vertex, adjacentVertex);
                    edge.name = $"Edge {id++}";
                    graph.AddEdge(edge);
                    vertex.AddEdge(edge);
                    adjacentVertex.AddEdge(edge);
                }
            }
        }

        return graph;
    }

    private Edge CreateEdge(Vertex first, Vertex second)
    {
        GameObject edgeObject = Instantiate(_edgePref) as GameObject;
        edgeObject.transform.parent = _transform;
        edgeObject.transform.position = Calculator.GetPositionBetweenTwoObjects(first.Transform, second.Transform);

        float angle = Calculator.GetAngleOfRotationToDirectionVector(
            Calculator.GetDirectionalVectorFromOneToOtherObject(first.Transform, second.Transform)) - 90; //90 - угол наклона спрайта
        Vector3 rotation = edgeObject.transform.rotation.eulerAngles;
        edgeObject.transform.rotation = Quaternion.Euler(rotation + new Vector3(0, 0, angle));

        Vector3 size = edgeObject.GetComponent<SpriteRenderer>().bounds.size;
        Vector3 distance = Calculator.GetDistanceBetweenTwoObjects(first.Transform, second.Transform);
        Vector3 scale = edgeObject.transform.localScale;
        scale.y = distance.magnitude / size.magnitude;
        edgeObject.transform.localScale = scale;

        Edge edge = edgeObject.GetComponent<Edge>();
        edge.SetPreset(first, second);

        return edge;
    }
}
