using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vertex StartElement;
    [SerializeField] private float speed = 1;
    [SerializeField] private float distanceLocker = 0.2f;

    private Transform _transform;
    private Rigidbody2D _rigidbody;
    private Vector3 _keyboardDirection;
    private GraphicalMovementParameters _parameters;
    private ElementOfGraph _activeElement;
    private bool _isLockedMovement;
    private void Awake()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody2D>();
        _transform.position = StartElement.transform.position;
        _parameters = new GraphicalMovementParameters(StartElement, StartElement);
        SetActiveElement();
        _isLockedMovement = false;
    }

    private void Update()
    {
        _keyboardDirection.x = Input.GetAxisRaw("Horizontal");
        _keyboardDirection.y = Input.GetAxisRaw("Vertical");

        //Debug.Log(Calculator.GetAngleOfRotationToDirectionVector(_keyboardDirection.normalized));
        if (_keyboardDirection.magnitude > 0 && !_isLockedMovement)
        {
            _parameters = _parameters.Element.GetParameters(_keyboardDirection.normalized, _parameters);
            SetActiveElement();
        }
    }

    private void FixedUpdate()
    {
        //Debug.Log(_parameters.Element.name);
        Vector3 distance = (_parameters.Aim.Transform.position - _transform.position);
        Vector3 move = distance.normalized * speed * Time.fixedDeltaTime;
        //Debug.Log(distance.magnitude);
        if (distance.magnitude <= distanceLocker)
            _isLockedMovement = true;
        
        if (move.magnitude > distance.magnitude || distance == Vector3.zero)
        {
            //Debug.Log(_parameters.Aim.gameObject.name);
            move = distance;
            _parameters = _parameters.Aim.GetParameters(Vector3.zero, _parameters);
            SetActiveElement();
            _isLockedMovement = false;
        }
        _rigidbody.MovePosition(_transform.position + move);

    }

    public void Teleport(Vertex vertex)
    {
        _parameters = new GraphicalMovementParameters(vertex, vertex);
        _transform.position = vertex.transform.position;
    }

    private void SetActiveElement() => SetActiveElement(_parameters.Element);
    private void SetActiveElement(ElementOfGraph element)
    {
        if (_activeElement == element)
            return;

        if (_activeElement != null) _activeElement.Exit();

        _activeElement = element;
        _activeElement.Enter();
    }

    public bool IsMoving()
    {
        Vector3 distance = (_parameters.Aim.Transform.position - _transform.position);
        return distance != Vector3.zero;
    }

    public Vector3 GetDirection()
    {
        return (_parameters.Aim.Transform.position - _transform.position).normalized;
    }

    public Transform Transform { get { return _transform; } }

}
