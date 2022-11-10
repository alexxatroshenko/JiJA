using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FloatingJoystick : Joystick
{
    public bool pointerDown { get; private set; }
    protected override void Start()
    {
        base.Start();
        background.gameObject.SetActive(false);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
        background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
        background.gameObject.SetActive(true);
        base.OnPointerDown(eventData);
        
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        pointerDown = false;
        Vector3 direction = new Vector3(Direction.x, 0f, Direction.y);
        background.gameObject.SetActive(false);
        shootWayRenderer.Disable();
        base.OnPointerUp(eventData);
        if(direction.z > 0f)
            FindObjectOfType<PlayerShooter>().Pull(direction);
    }
}