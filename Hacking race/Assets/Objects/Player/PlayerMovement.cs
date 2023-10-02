using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    [SerializeField] private float distanceLocker = 0.2f;

    private Transform _transform;
    private Rigidbody2D _rigidbody;
    private Vector3 _keyboardDirection;
    private GraphicalMovementParameters _parameters;
    private ElementOfGraph _activeElement;
    private Vertex _startVertex;
    private bool _isLockedMovement;
    private bool _isGame;
    private void Awake()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody2D>();
        _isLockedMovement = false;
        _isGame = false;
    }
    public void SetPreset(Vertex startVertex)
    {
        _startVertex = startVertex;
        _transform.position = startVertex.transform.position;
        _parameters = new GraphicalMovementParameters(startVertex, startVertex);
    }
    public void ActivatePlayer()
    {
        _transform.position = _startVertex.transform.position;
        _parameters = new GraphicalMovementParameters(_startVertex, _startVertex);
        SetActiveElement();
        _isLockedMovement = false;
        _isGame = true;
    }

    public void DisactivatePlayer()
    {
        _parameters = null;
        _isLockedMovement = false;
        _isGame = false;
    }

    private void Update()
    {
        if (!_isGame || !_parameters?.Element)
            return;
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
        if (!_isGame)
            return;
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
        if (_parameters == null) return false;
        Vector3 distance = (_parameters.Aim.Transform.position - _transform.position);
        return distance != Vector3.zero;
    }

    public Vector3 GetDirection()
    {
        return (_parameters.Aim.Transform.position - _transform.position).normalized;
    }

    public Transform Transform { get { return _transform; } }

}
