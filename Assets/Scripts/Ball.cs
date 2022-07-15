using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    [SerializeField] private float _tapForce = 6;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private ChoiceBallDirection _mousePosition;
    [SerializeField] private TrajectoryRenderer _trajectoryRenderer;
    [SerializeField] private AudioSource _collisionSound;
    
    private int _points;
    private bool _ballOnStart = true;
    private Rigidbody2D _rigidbody;
    private Vector3 _worldMousePosition;

    public int Points => _points;

    public UnityAction BallInStartPoint;
    public UnityAction<int> ChangedPoint;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _worldMousePosition = _mousePosition.WorldMousePosition;

        if (transform.position == _startPoint.position)
            _ballOnStart = true;
        else
            _ballOnStart = false;

        if (Input.touchCount > 0)
            _rigidbody.simulated = true;

        if (Input.GetMouseButtonDown(0))
            ActiveBall();

        if (_ballOnStart == true)
            BallTrajectory();
    }

    public void RestartBall()
    {
        transform.position = _startPoint.position;
        _rigidbody.simulated = false;
        _rigidbody.velocity = Vector2.zero;
        BallInStartPoint?.Invoke();
    }

    public void ResetPoint()
    {
        _points = 0;
    }

    public void ActiveBall()
    {
        _rigidbody.AddForce(_worldMousePosition * _tapForce, ForceMode2D.Force);
        _rigidbody.simulated = true;
    }

    public void AddPoint()
    {
        _points++;
        ChangedPoint?.Invoke(_points);
    }

    public void PlayHitSound()
    {
        _collisionSound.Play();
    }

    private void BallTrajectory()
    {
        Vector2 direction = _worldMousePosition * _tapForce;
        _trajectoryRenderer.ShowTrajectory(_startPoint.position, _worldMousePosition);
    }
}
