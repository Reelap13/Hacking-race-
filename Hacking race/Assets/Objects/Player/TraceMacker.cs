using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class TraceMacker : MonoBehaviour
{
    [SerializeField] private PlayerMovement _player;
    [SerializeField] private float _timeBetweenTraces;
    [SerializeField] private GameObject _tracePref;

    public Transform Transform => _player.Transform;
    private float _timeAfterTrace;

    private void Awake()
    {
        _timeAfterTrace = 0;
    }

    private void Update()
    {
        _timeAfterTrace += Time.deltaTime;
        if (_player.IsMoving() && _timeAfterTrace >= _timeBetweenTraces)
        {
            MakeTrace();
            _timeAfterTrace = 0;
        }
    }

    private void MakeTrace()
    {
        GameObject trace = Instantiate(_tracePref) as GameObject;
        trace.transform.position = Transform.position;

        float angle = Calculator.GetAngleOfRotationToDirectionVector(
            _player.GetDirection()) - 90; //90 - угол наклона спрайта
        Vector3 rotation = trace.transform.rotation.eulerAngles;
        trace.transform.rotation = Quaternion.Euler(rotation + new Vector3(0, 0, angle));
    }

}
