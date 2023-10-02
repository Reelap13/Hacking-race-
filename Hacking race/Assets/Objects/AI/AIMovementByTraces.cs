using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovementByTraces : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _followingSpeed;
    [SerializeField] private Vertex _startVertex;
    private Trace _trace;
    private Vertex _previousVertex;
    private Vertex _currentVertex;
    public Transform Transform { get; private set; }
    public Rigidbody2D Rigidbody { get; private set; }
    
    private void Awake()
    {
        Transform = GetComponent<Transform>();
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _previousVertex = _startVertex;
        _currentVertex = _startVertex;
        Transform.position = _startVertex.Transform.position;
    }


    private void FixedUpdate()
    {
        if (_trace)
            MoveByTrace();
        else if (_currentVertex)
            MoveByVertex();
    }

    private void MoveByVertex()
    {
        Vector3 distance = Calculator.GetDistanceBetweenTwoObjects(Transform, _currentVertex.Transform);
        if (distance == Vector3.zero)
        {
            SetVertex();
            MoveByVertex();
            return;
        }
        Vector3 move = distance.normalized * _speed * Time.fixedDeltaTime;

        if (distance.magnitude < move.magnitude)
        {
            SetVertex();
            Vector3 direction = Calculator.GetDirectionalVectorFromOneToOtherObject(
                Transform, _currentVertex.Transform);
            Rigidbody.MovePosition(Transform.position + distance + direction * (move - distance).magnitude);
        }
        else
        {
            Rigidbody.MovePosition(Transform.position + move);
        }
    }

    private void MoveByTrace()
    {
        if (_trace == null)
            return;

        Vector3 distance = Calculator.GetDistanceBetweenTwoObjects(Transform, _trace.Transform);
        /*if (distance == Vector3.zero)
        {
            SetTrace();
            MoveByTrace();
            return;
        }*/
        Vector3 move = distance.normalized * _speed * Time.fixedDeltaTime;

        if (distance.magnitude < move.magnitude || distance == Vector3.zero)
        {
            SetTrace();
            Vector3 direction = Vector3.zero;
            if (!_trace)
                direction = Calculator.GetDirectionalVectorFromOneToOtherObject(
                Transform, _trace.Transform);
            Rigidbody.MovePosition(Transform.position + distance + direction * (move - distance).magnitude);
        }
        else Rigidbody.MovePosition(Transform.position + move);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Tag tag = TagsMethod.ParseStringToTag(collision.tag);

        if (Tag.VERTEX == tag && _trace)
            SetVertex(collision.GetComponent<Vertex>());
        if (Tag.TRACE == tag)
            SetTrace(collision.GetComponent<Trace>());

    }
    private void SetTrace() => SetTrace(_trace?.Next);
    public void SetTrace(Trace trace)
    {
        if (trace)
            return;
        if (!_trace)
            _trace = trace;
        else
            _trace = _trace.GetLiveTime() > trace.GetLiveTime() ? trace : _trace;
    }
    private void SetVertex()
    {
        Vertex TryToGetOtherRandomVertex(int n){
            Vertex v = _currentVertex.GetRandomAdjacentVertex();
            return v == _previousVertex && n > 0 ? TryToGetOtherRandomVertex(n - 1) : v;
        }
        SetVertex(TryToGetOtherRandomVertex(2));
    }
    private void SetVertex(Vertex vertex)
    {
        _previousVertex = _currentVertex;
        _currentVertex = vertex;
    }
}
