using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offSet;
    void Start()
    {

    }


    void LateUpdate() // normal updatelerden sonra calisir 
    {
        CameraMovement();
    }
    void CameraMovement()
    {
        if (target != null)
        {
            transform.position = target.position + offSet;
        }
    }
}
