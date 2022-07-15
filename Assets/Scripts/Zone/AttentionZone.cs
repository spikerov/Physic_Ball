using UnityEngine;

public class AttentionZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Shape>(out Shape shape))
        {
            shape.OnAttentionZone();
        }
    }
}
