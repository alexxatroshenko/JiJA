using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootWayRenderer : MonoBehaviour
{
    [SerializeField] private PlayerShooter shooter;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private GameObject gun;

    private bool isDrawing = false;
    private Vector3 targetPosition;
    private Vector3 currentPosition;
    public void DrawWay(Vector3 wayPosition)
    {
        isDrawing = true;
        lineRenderer.positionCount = 2;
        targetPosition = wayPosition;
        currentPosition = gun.transform.position;
    }
    
    void LateUpdate()
    {
        if (isDrawing)
        {
            lineRenderer.SetPosition(0, gun.transform.position);
            lineRenderer.SetPosition(1, targetPosition);
        }
    }

    public void Disable()
    {
        isDrawing = false;
        lineRenderer.positionCount = 0;
    }
}
