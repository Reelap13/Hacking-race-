using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vertex StartElement;
    [SerializeField] private float speed;

    private Transform _transform;
    private Rigidbody2D _rigidbody;
    private Vector3 _keyboardDirection;
    private GraphicalMovementParameters _parameters;
    private void Awake()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody2D>();
        _transform.position = StartElement.transform.position;
        _parameters = new GraphicalMovementParameters(StartElement, StartElement);
    }

    private void Update()
    {
        _keyboardDirection.x = Input.GetAxisRaw("Horizontal");
        _keyboardDirection.y = Input.GetAxisRaw("Vertical");

        //Debug.Log(Calculator.GetAngleOfRotationToDirectionVector(_keyboardDirection.normalized));
        if (_keyboardDirection.magnitude > 0)
            _parameters = _parameters.Element.GetParameters(_keyboardDirection.normalized, _parameters);
    }

    private void FixedUpdate()
    {
        //Debug.Log(_parameters.Element.name);
        Vector3 direction = (_parameters.Aim.Transform.position - _transform.position);
        Vector3 move = direction.normalized * speed * Time.fixedDeltaTime;
        if (move.magnitude > direction.magnitude || direction == Vector3.zero)
        {
            //Debug.Log(_parameters.Aim.gameObject.name);
            move = direction;
            _parameters = _parameters.Aim.GetParameters(Vector3.zero, _parameters);
        }
        _rigidbody.MovePosition(_transform.position + move);

    }

}
