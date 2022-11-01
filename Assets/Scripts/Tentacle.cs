using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Player player;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.gameObject.CompareTag("Collectable"))
        {
            Destroy(other.gameObject);
            player.Grow();
        }
        playerAnimator.SetTrigger("StopPull");
        
    }
}
