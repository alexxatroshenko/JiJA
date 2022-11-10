using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private FloatingJoystick joystick;
    [SerializeField] private GameObject tentacle;
    [SerializeField] private GameObject gun;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
   
    public void Pull(Vector3 direction)
    {
        transform.rotation = Quaternion.Euler(0f, (Mathf.Atan2(direction.x, direction.z) * 180) / Mathf.PI, 0f);
        animator.SetTrigger("Pull");
    }
}
