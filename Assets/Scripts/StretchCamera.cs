using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StretchCamera : MonoBehaviour
{

    Camera cam;
    public float height = 1f;
    public float width = 1f;



    void Start()
    {
        cam = GetComponent<Camera>();
    }


    void Update()
    {
        //stretch view//
        cam.ResetProjectionMatrix();
        var m = cam.projectionMatrix;

        m.m11 *= height;
        m.m00 *= width;
        cam.projectionMatrix = m;
    }
}
