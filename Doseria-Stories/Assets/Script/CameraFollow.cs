using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject angelu2D;
    public Vector3 offset;

    void Awake()
    {
        offset = angelu2D.transform.position - transform.position;
    }

    void FixedUpdate()
    {
        transform.position = angelu2D.transform.position - offset;
    }
}
