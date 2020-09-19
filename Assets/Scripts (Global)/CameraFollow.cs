using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private float smoothTime = .3f;
    public Vector3 offset;
    private Vector3 velocity;

    public float minX;
    public float maxX;


    private void FixedUpdate ()
    {
        Vector3 targetPos = new Vector3(Mathf.Clamp(target.position.x, minX, maxX), 0, 0) + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }


}
