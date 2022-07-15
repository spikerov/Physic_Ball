using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TrajectoryRenderer : MonoBehaviour
{
    [SerializeField] private int _numberOfPoints;
    [SerializeField] private GameObject _pointPrefab;

    public GameObject[] Points;

    private LineRenderer _lineRenderer;
    private float _time;

    private void Start()
    {
        Points = new GameObject[_numberOfPoints];
        _lineRenderer = GetComponent<LineRenderer>();
        for (int i = 0; i < _numberOfPoints; i++)
        {
            Points[i] = Instantiate(_pointPrefab, transform.position, Quaternion.identity);
        }
    }

    //private void Update()
    //{
    //    _time = (Points.Length - 1) * 0.1f;

    //    for (int i = 0; i < Points.Length; i++)
    //    {
    //        Points[i].transform.position = ShowTrajectory();
    //    }
    //}

    //private void ShowTrajectory(Transform position, Vector2 direction, float force)
    //{
    //    Vector2 currentPointPosition = (Vector2)transform.position + (direction.normalized * force * _time) + 0.5f * Physics2D.gravity * (_time * _time);
    //}

    public void ShowTrajectory(Vector2 startPoint, Vector2 direction)
    {
        Vector3[] points = new Vector3[10];
        _lineRenderer.positionCount = points.Length;
        for (int i = 0; i < points.Length; i++)
        {
            float time = i * 0.1f;
            points[i] = startPoint + direction * time + 0.2f * Physics2D.gravity * time * time;

            if (points[i].y < 2)
            {
                _lineRenderer.positionCount = i;
                break;
            }
        }

        _lineRenderer.SetPositions(points);
    }
}
