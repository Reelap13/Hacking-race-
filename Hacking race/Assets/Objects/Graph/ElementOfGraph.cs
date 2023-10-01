using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class ElementOfGraph : MonoBehaviour
{
    public UnityEvent OnEnter = new UnityEvent();
    public UnityEvent OnExit = new UnityEvent();
    public abstract GraphicalMovementParameters GetParameters(Vector3 direction, GraphicalMovementParameters parameters);

    public void Enter() => OnEnter.Invoke();
    public void Exit() => OnExit.Invoke();
}
