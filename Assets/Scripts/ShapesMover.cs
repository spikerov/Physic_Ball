using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShapesMover : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private Shape _shape;
    [SerializeField] private Transform _startPosition;

    private float _stepSize = 1f;
    private bool _isAttentionZone = false;

    private void OnEnable()
    {
        ShorteningStepZone.OnAttentionZone += ShapeInAttentionZone;
        _ball.BallInStartPoint += BallInStartPoint;
    }

    private void OnDisable()
    {
        ShorteningStepZone.OnAttentionZone -= ShapeInAttentionZone;
        _ball.BallInStartPoint -= BallInStartPoint;
    }

    private void Start()
    {
        transform.DOMoveY(1, 1);
    }

    private void BallInStartPoint()
    {
        if (_isAttentionZone == true)
        {
            _stepSize += 0.5f;
            _isAttentionZone = false;
        }
        else
        {
            _stepSize += 1f;
        }
        MoveShapes(_stepSize);
    }

    public void ShapeInAttentionZone()
    {
        _isAttentionZone = true;
    }

    private void MoveShapes(float moveSize)
    {
        transform.DOMoveY(moveSize, 1);
    }

    public void ResetMover()
    {
        transform.position = new Vector3(0, 0, 0);
    }
}
