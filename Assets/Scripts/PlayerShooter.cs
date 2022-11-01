using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerShooter : MonoBehaviour, IPointerUpHandler
{
    [SerializeField] private FloatingJoystick joystick;
    [SerializeField] private GameObject tentacle;
    [SerializeField] private GameObject gun;
    [SerializeField] private float pullSpeed = 10f;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Pull();
        }
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Pull();
    }



    private void Pull()
    {
        
        Vector3 direction = new Vector3(joystick.Direction.x, 0f, joystick.Direction.y);
        transform.rotation = Quaternion.Euler(0f, (Mathf.Atan2(joystick.Direction.x, joystick.Direction.y) * 180) / Mathf.PI, 0f);
        animator.SetTrigger("Pull");
        
    }
}
