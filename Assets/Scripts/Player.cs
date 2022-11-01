using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float playerGrowCoeff = 1.1f;
    public void Grow()
    {
        transform.localScale = transform.localScale * playerGrowCoeff;
    }
}
