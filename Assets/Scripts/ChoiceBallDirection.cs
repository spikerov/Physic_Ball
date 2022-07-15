using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceBallDirection : MonoBehaviour
{
    [SerializeField] private Ball _ball;

    private Vector3 _worldMousePosition;

    public Vector3 WorldMousePosition => _worldMousePosition;

    private void Update()
    {
        _worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {
        //    _pointDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    Vector3 mouseinWorld = _pointDirection;
        //    _ball.ActiveBall(_pointDirection);
        
    }
}
