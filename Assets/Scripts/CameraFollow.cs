using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Transform player1;

    public float smoothSpeed = 5f;

    public float minZoom = 5f;
    public float maxZoom = 12f;

    public float minDistance = 2f;
    public float maxDistance = 10f;

    Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        if (player == null || player1 == null)
            return;

        Vector3 middle = (player.position + player1.position) / 2f;

        Vector3 targetPos = new Vector3(middle.x, middle.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothSpeed * Time.deltaTime);

        float distance = Vector2.Distance(player.position, player1.position);

        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        float t = (distance - minDistance) / (maxDistance - minDistance);
        float targetZoom = Mathf.Lerp(minZoom, maxZoom, t);

        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * smoothSpeed);
    }
}