using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Edge : ElementOfGraph
{
    public UnityEvent OnTurningOn = new UnityEvent();
    public UnityEvent OnTurningOff = new UnityEvent();
    public Vertex First { get; private set; }
    public Vertex Second { get; private set; }
    public Transform Transform { get; private set; }
    public SpriteRenderer Renderer { get; private set; }

    private void Awake()
    {
        Transform = GetComponent<Transform>();
        Renderer = GetComponent<SpriteRenderer>();
    }
    public void SetPreset(Vertex first, Vertex second)
    {
        First = first;
        Second = second;
        TurnOn();
    }


    public override GraphicalMovementParameters GetParameters(Vector3 direction, GraphicalMovementParameters parameters)
    {
        if (direction == Vector3.forward)
            return new GraphicalMovementParameters(parameters.Aim, this);

        Vertex aim = GetAim(direction);
        if (aim == null)
            return new GraphicalMovementParameters(parameters.Aim, this);
        //Debug.Log(aim);
        ElementOfGraph element = this;
        return new GraphicalMovementParameters(aim, element);
    }
    public Vertex GetAim(Vector3 direction)
    {
        Vector3 edgeDirection = Calculator.GetDirectionalVectorFromOneToOtherObject(First.Transform, Second.Transform);
        float firstAngle = Calculator.GetAngleOfRotationToDirectionVector(edgeDirection * -1);
        float secondAngle = Calculator.GetAngleOfRotationToDirectionVector(edgeDirection);
        float angle = Calculator.GetAngleOfRotationToDirectionVector(direction);
        //Debug.Log(firstAngle + " " + secondAngle + " " + angle + " " + MathF.Abs(firstAngle - angle) + " " + MathF.Abs(secondAngle - angle)  + " " + (MathF.Abs(firstAngle - angle) <= MathF.Abs(secondAngle - angle)));
        float fa = Calculator.CalculateAngle(firstAngle, angle);
        float sa = Calculator.CalculateAngle(secondAngle, angle);
        return  Mathf.Min(fa, sa) >= 55 ? null : fa < sa ? First : Second;
    }

    public bool IsSameVertex(Vertex first, Vertex second)
    {
        return First == first && Second == second ||
            First == second && Second == first;
    }
    public Vertex GetOtherVertex(Vertex vertex)
    {
        return First == vertex ? Second : First;
    }

    public void TurnOff()
    {
        Color color = Renderer.color;
        color.a = 1/5f;
        Renderer.color = color;
        First.RemoveEdge(this);
        Second.RemoveEdge(this);
        OnTurningOff.Invoke();
    }

    public void TurnOn()
    {
        Color color = Renderer.color;
        color.a = 1f;
        Renderer.color = color;
        First.AddEdge(this);
        Second.AddEdge(this);
        OnTurningOn.Invoke();
    }
}
