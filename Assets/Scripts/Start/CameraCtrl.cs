using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 3f;
    public Vector3 offset;
    public GameObject backgroundObject;

    private float cameraHalfWidth;
    private float cameraHalfHeight;

    void Start()
    {
        backgroundObject = GameObject.FindGameObjectWithTag("Background");

        float cameraHeight = Camera.main.orthographicSize * 2f;
        float cameraWidth = cameraHeight * Camera.main.aspect;
        cameraHalfWidth = cameraWidth / 2f;
        cameraHalfHeight = cameraHeight / 2f;
    }

    private void LateUpdate()
    {
        if (target != null && backgroundObject != null)
        {
            float minX = backgroundObject.GetComponent<Renderer>().bounds.min.x + cameraHalfWidth;
            float maxX = backgroundObject.GetComponent<Renderer>().bounds.max.x - cameraHalfWidth;
            float minY = backgroundObject.GetComponent<Renderer>().bounds.min.y + cameraHalfHeight;
            float maxY = backgroundObject.GetComponent<Renderer>().bounds.max.y - cameraHalfHeight;

            float desiredX = target.position.x + offset.x;
            float clampedX = Mathf.Clamp(desiredX, minX, maxX);
            float desiredY = target.position.y + offset.y;
            float clampedY = Mathf.Clamp(desiredY, minY, maxY);
            Vector3 desiredPosition = new Vector3(clampedX, clampedY, transform.position.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
    }
}
