using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : Singleton<CameraController>
{
    [SerializeField] private float _speedOfFollowing;
    [SerializeField] private Transform _aimOfFollowing;
    [field: SerializeField] public float _distanceFromAim { get; private set; }

    private Transform _tr;
    void Awake()
    {
        _tr = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 newCameraPosition = new Vector3(_aimOfFollowing.position.x, _aimOfFollowing.position.y, _distanceFromAim);
        _tr.position = Vector3.Lerp(_tr.position, newCameraPosition, _speedOfFollowing * Time.deltaTime);
    }
}
