using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleMagnet : Tentacle
{
    [SerializeField] private GameObject magnetCenter;
    [SerializeField] private float magnetPower;
    protected override void OnTriggerEnter(Collider other)
    {
        
        ManagePlayerState(other);
    }

    protected override void ManagePlayerState(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            other.gameObject.GetComponent<Jelly>().MoveToTarget(magnetCenter.transform.position, magnetPower);
        }
        
    }
}
