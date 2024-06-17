using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float maxZoom = -10f;
    private float minZoom = -20f;
    private float zoomSpeed = 1f;
    private float speed = 5f;
    private Camera _camera;

    private void Start()
    {
        _camera = GetComponent<Camera>();
    }

    private void Zoom()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            if (Input.mouseScrollDelta.y > 0 && _camera.transform.position.z == maxZoom)
            {
                return;
            }
            else if (Input.mouseScrollDelta.y < 0 && _camera.transform.position.z == minZoom)
            {
                return;
            }
            _camera.transform.position -= new Vector3(0,0,-Input.mouseScrollDelta.y * zoomSpeed);
        }
    }

    private void ControllCamera()
    {
        if(Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            float inputX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            float inputY = Input.GetAxis("Vertical") * Time.deltaTime * speed;
            _camera.transform.position += new Vector3(inputX, inputY);
        }
    }

    private void LateUpdate()
    {
        Zoom();
        ControllCamera();
    }
}
