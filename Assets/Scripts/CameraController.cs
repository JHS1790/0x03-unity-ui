using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    ///<summary>Player</summary>
    public Transform player;
    ///<summary>Camera Speed</summary>
    public float smoothSpeed = 0.025f;
    ///<summary>Camera Offset</summary>
    public Vector3 offset;
    ///do tha move
    void FixedUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(player);
    }
}
