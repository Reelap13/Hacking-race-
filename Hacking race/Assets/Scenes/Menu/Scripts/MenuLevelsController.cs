using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLevelsController : MonoBehaviour
{
    [SerializeField] private Transform[] _pages;

    private Transform _page;
    private int _index;
    private Transform _transform;
    private void Awake()
    {
        _transform = transform;
        _page = _pages[0];
        _index = 0;
        _transform.position = _page.position;
    }

    private void GoToNextPage()
    {
        if (_index < _pages.Length - 1)
        {
            ++_index;
            _page = _pages[_index];
        }
        else return;
        StopAllCoroutines();
        StartCoroutine(MoveToPositionAnimWithoutBlock(_page.position, 2));
    }

    private void GoToPreviousPage()
    {
        if (_index > 0)
        {
            --_index;
            _page = _pages[_index];
        }
        else return;
        StopAllCoroutines();
        StartCoroutine(MoveToPositionAnimWithoutBlock(_page.position, 2));
    }


    private IEnumerator MoveToPositionAnimWithoutBlock(Vector3 finalPosition, float animTime)
    {
        Vector3 startPosition = _transform.position;
        float t = 0;

        float animationDuration = animTime;

        while (t < 1)
        {
            _transform.position = Vector3.Lerp(startPosition, finalPosition, t * t);
            t += Time.deltaTime / animationDuration;
            yield return null;
        }
    }
}
