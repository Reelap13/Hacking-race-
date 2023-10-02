using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraceDeleting : MonoBehaviour
{
    [SerializeField] private Edge _edge;
    [SerializeField] private Collider2D _collider;
    private void Awake()
    {
        _edge.OnTurningOn.AddListener(TurnOn);
        _edge.OnTurningOff.AddListener(TurnOff);
    }
    public void TurnOn() => _collider.enabled = false;
    public void TurnOff() => _collider.enabled = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Tag tag = TagsMethod.ParseStringToTag(collision.tag);
        if (Tag.TRACE == tag)
            Destroy(collision.gameObject);
    }
}
