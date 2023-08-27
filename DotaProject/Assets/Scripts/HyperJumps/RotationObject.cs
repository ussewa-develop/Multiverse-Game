using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationObject : MonoBehaviour
{
    [SerializeField] float speed = -0.001f;

    void LateUpdate()
    {
        gameObject.transform.Rotate(new Vector3(0, speed, 0));
    }
}
