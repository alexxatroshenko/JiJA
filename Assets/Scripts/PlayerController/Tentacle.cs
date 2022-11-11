using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Player player;
    [SerializeField] private float SpeededTentacleAnim = 2f;
    [SerializeField] private float UnspeededTentacleAnim = 0.8f;
    [SerializeField] private float tentacleSpeed; //for debugging purposes

    private void Start()
    {
        CheckBoosters();
    }

    private void CheckBoosters()
    {
        if (DataManager.isSpeeded)
        {
            tentacleSpeed = SpeededTentacleAnim;
            playerAnimator.SetFloat("AnimSpeed", SpeededTentacleAnim);
        }
        else
        {
            tentacleSpeed = UnspeededTentacleAnim;
            playerAnimator.SetFloat("AnimSpeed", UnspeededTentacleAnim);
        }
        if (DataManager.isMagneted)
        {
            FindObjectOfType<TentacleMagnet>().GetComponent<CapsuleCollider>().enabled = true;
        }
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        ManagePlayerState(other);

        playerAnimator.SetTrigger("StopPull");


    }

    protected virtual void ManagePlayerState(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            Destroy(other.gameObject);
            player.Grow();
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            player.Decrease();
        }
    }


}
