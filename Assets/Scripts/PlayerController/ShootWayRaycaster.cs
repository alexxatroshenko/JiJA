using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootWayRaycaster : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float maxDistance;
    [SerializeField] private GameObject gun;
    [SerializeField] private FloatingJoystick joystick;

    public RaycastHit Raycast()
    {
        Vector3 direction = new Vector3(joystick.Direction.x, 0f, joystick.Direction.y);
        RaycastHit hit;
        Physics.Raycast(gun.transform.position, direction, out hit, maxDistance, layerMask);
        return hit;
    }
}
