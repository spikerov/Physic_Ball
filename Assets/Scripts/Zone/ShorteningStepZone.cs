using System;
using UnityEngine;

public class ShorteningStepZone : MonoBehaviour
{
    public static Action OnAttentionZone;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Shape>(out Shape shape))
        {
            OnAttentionZone?.Invoke();
        }
    }
}
