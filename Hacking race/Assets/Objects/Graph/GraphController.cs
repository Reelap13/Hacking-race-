using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphController : Singleton<GraphController>
{
    [SerializeField] private GraphCreator _creator;
    [field: SerializeField]
    public Vertex StartVertex { get; private set; }

    private Graph _graph;

    public void CreateGraph()
    {
        _graph = _creator.CreateGraph();
    }

    public void DeleteGraph()
    {
        foreach (var edge in _graph.GetEdges())
        {
            Destroy(edge.gameObject);
        }
    }

}
