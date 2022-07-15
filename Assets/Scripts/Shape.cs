using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody2D))]
public class Shape : MonoBehaviour
{
    [SerializeField] private Shapes _shapes;

    private Ball _ball;
    private ParticleScore _particleScore;
    private Rigidbody2D _rigidbody;
    private Tween rotateSquare;
    private Tween shakeShape;
    private int _countLives;
    private float _destroyTime = 0.1f; 
    private float _rotationDuration = 3;

    private const string _typeSquare = "Square";

    public int CountLives => _countLives;

    private void Start()
    {
        _ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>();
        _particleScore = GameObject.FindGameObjectWithTag("ParticleScore").GetComponent<ParticleScore>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _countLives = _shapes.CountLives;

        if (_shapes.Type == _typeSquare)
        {
            if (gameObject != null)
            {
                rotateSquare = _rigidbody.DORotate(90, _rotationDuration).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ball>(out Ball ball))
        {
            _ball.PlayHitSound();
            ApplyDamage();
        }
    }
    public void OnAttentionZone()
    {
        shakeShape = transform.DOShakePosition(0.5f, new Vector3(0.01f, 0.01f, 0), 20, 50, false, false).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    }

    private void ApplyDamage()
    {
        _countLives--;

        if (_countLives <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        _particleScore.PlayParticle(transform.position);
        shakeShape.Kill();
        rotateSquare.Kill();
        _ball.AddPoint();
        Destroy(gameObject, _destroyTime);
    }
}
