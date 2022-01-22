using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    [HideInInspector] public Vector3 direction = Vector3.zero;

    void Update()
    {
        if (direction != Vector3.zero)
        {
            transform.position += direction * Time.deltaTime * speed;
        }
    }
}
