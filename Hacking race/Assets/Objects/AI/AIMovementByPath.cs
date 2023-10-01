using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovementByPath : MonoBehaviour
{
    [field: SerializeField]
    public Vertex[] Vertices { get; private set; }
    [SerializeField] private float _speed;

    public Transform Transform { get; private set; }
    public Rigidbody2D Rigidbody { get; private set; }
    private int _index;
    private void Start()
    {
        Transform = GetComponent<Transform>();
        Rigidbody = GetComponent<Rigidbody2D>();
        _index = 0;
        if (Vertices.Length == 0)
        {
            Debug.Log("Unit was spawned without way!");
            return;
        }
        Transform.position = Vertices[0].Transform.position;
    }

    private void FixedUpdate()
    {
        Vector3 distance = Calculator.GetDistanceBetweenTwoObjects(Transform, Vertices[_index % Vertices.Length].Transform);
        if (distance == Vector3.zero)
        {
            ++_index;
            distance = Calculator.GetDistanceBetweenTwoObjects(Transform, Vertices[_index % Vertices.Length].Transform);
        }
        Vector3 move = distance.normalized * _speed * Time.fixedDeltaTime;

        if (distance.magnitude < move.magnitude)
        {
            ++_index;
            Vector3 direction = Calculator.GetDirectionalVectorFromOneToOtherObject(
                Transform, Vertices[_index % Vertices.Length].Transform);
            Rigidbody.MovePosition(Transform.position + distance + direction * (move - distance).magnitude);
        }
        else
        {
            Rigidbody.MovePosition(Transform.position + move);
        }
    }
}
