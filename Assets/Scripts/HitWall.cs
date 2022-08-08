using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class HitWall : MonoBehaviour
{
    [SerializeField] private Image _frameImage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ball>(out Ball ball))
        {
            _frameImage.DOColor(Color.red, 0.1f).SetLoops(2, LoopType.Yoyo);
            ball.PlayHitSound();
            _frameImage.color = Color.black;
        }
    }
}
