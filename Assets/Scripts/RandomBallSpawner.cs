using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBallSpawner : MonoBehaviour
{
    [SerializeField] private List<Shape> _circle;
    [SerializeField] private List<Shape> _square;

    private float[] _spawnPointsX = {-2f, -1.5f, -1f, -0.5f, 0f, 0.5f, 1f, 1.5f, 2f};
    private float _spawnPointYFirsLine = -3f;
    private float _spawnPointSecondLine = -3.5f;
    private float _pointX;
    private float _difficultyLine;
    private int _countShapeInLine;
    private Vector3 _spawnPosition;


    private void Start()
    {
        
        
    }

    private void Update()
    {
        _spawnPosition = new Vector3(_pointX, _spawnPointYFirsLine, 0);
        _difficultyLine = transform.position.y;
    }

    public void SpawnShapes()
    {
        if (_difficultyLine < 20)
        {
            _countShapeInLine = Random.Range(0, 2);

            if (_countShapeInLine == 1)
            {
                _pointX = _spawnPointsX[Random.Range(0, _spawnPointsX.Length)];
                Instantiate(_circle[0], _spawnPosition, Quaternion.identity);
            }
        }
        else if (_difficultyLine > 20 && _difficultyLine < 40)
        {
            _countShapeInLine = Random.Range(0, 3);
        }
        else if (_difficultyLine > 40 && _difficultyLine < 60)
        {
            _countShapeInLine = Random.Range(1, 3);
        }
        else if (_difficultyLine > 60)
        {
            _countShapeInLine = Random.Range(2, 4);
        }
    }
}
