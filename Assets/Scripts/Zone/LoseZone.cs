using UnityEngine;

public class LoseZone : MonoBehaviour
{
    [SerializeField] private ManagerPanels _managerPanels;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Shape>(out Shape shape))
        {
            Time.timeScale = 0;
            _managerPanels.OpenGameOverPanel();
        }
    }
}
