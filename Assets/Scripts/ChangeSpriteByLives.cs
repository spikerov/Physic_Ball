using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ChangeSpriteByLives : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Shape _shape;
    [SerializeField] private Sprite _spriteLives1;
    [SerializeField] private Sprite _spriteLives2;
    [SerializeField] private Sprite _spriteLives3;
    [SerializeField] private Sprite _spriteLives4;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        switch (_shape.CountLives)
        {
            case 1:
                _spriteRenderer.sprite = _spriteLives1;
                break;
            case 2:
                _spriteRenderer.sprite = _spriteLives2;
                break;
            case 3:
                _spriteRenderer.sprite = _spriteLives3;
                break;
            case 4:
                _spriteRenderer.sprite = _spriteLives4;
                break;
            default:
                break;
        }
    }
}
