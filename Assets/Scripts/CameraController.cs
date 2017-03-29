using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5f;

    private Vector3 followOffset;

    private void Start()
    {
        followOffset = transform.position - target.position;
    }

    private void Update()
    {
        Vector3 targetCamPos = target.position + followOffset;

        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);


    }
}
