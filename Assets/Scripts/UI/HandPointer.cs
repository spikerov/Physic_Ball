using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HandPointer : MonoBehaviour
{
    [SerializeField] private Image _hand;
    [SerializeField] private float _handFinishPoint = -1;

    private Tween _moveHandPointer;
    private float _moveHandDuration = 3;

    private void Start()
    {
        gameObject.SetActive(true);
        _moveHandPointer = _hand.transform.DOMoveX(_handFinishPoint, _moveHandDuration).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    }

    public void CloseHandPointer()
    {
        _moveHandPointer.Kill();
        gameObject.SetActive(false);
    }
}
