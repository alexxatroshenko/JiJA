using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour
{
    
    private IEnumerator MoveToTargetCoroutine(Vector3 target, float speed)
    {
        while (Vector3.Distance(transform.position, target) > float.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            yield return null;
        }

    }
    public void MoveToTarget(Vector3 target, float speed)
    {
        StartCoroutine(MoveToTargetCoroutine(target, speed));
    }

}
