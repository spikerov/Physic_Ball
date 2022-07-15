using UnityEngine;

public class ParticleScore : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleScore;

    public void PlayParticle(Vector2 position)
    {
        transform.position = position;
        _particleScore.Play();
    }
}
