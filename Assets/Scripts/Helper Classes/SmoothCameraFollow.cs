using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject _target;

    private Vector3 _offset;
    [SerializeField]
    private float _lerpRate;

    internal bool _gameOver = false;

    private void Start()
    {
        // distance between camera and the player that we need to keep
        _offset = _target.transform.position - transform.position;
    }

    private void Update()
    {
        if(!_gameOver)
        {
            SmoothFollow();
        }
    }

    private void SmoothFollow()
    {
        Vector3 pos = transform.position;
        Vector3 targetPos = _target.transform.position - _offset;
        pos = Vector3.Lerp(pos, targetPos, _lerpRate * Time.deltaTime);
        transform.position = pos;
    }

}
