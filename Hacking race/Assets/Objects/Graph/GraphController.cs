using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphController : Singleton<GraphController>
{
    [SerializeField] private GraphCreator _creator;

    private Graph _graph;

    private void Start()
    {
        _creator.CreateGraph();
    }

}
