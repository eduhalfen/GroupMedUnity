using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flutuando : MonoBehaviour
{
    public float wiggleAmount = 0.1f; // Amount of wiggle
    public float wiggleSpeed = 10f; // Speed of wiggle
    public Vector3 wiggleDirection = Vector3.one; // Direction of wiggle

    private Vector3 initialPosition;



    void Start()
    {
        // Store the initial position of the object
        initialPosition = transform.localPosition;
    }

    void Update()
    {
        // Calculate new position
        float wiggleX = Mathf.Sin(Time.time * wiggleSpeed) * wiggleAmount * wiggleDirection.x;
        float wiggleY = Mathf.Sin(Time.time * wiggleSpeed) * wiggleAmount * wiggleDirection.y;
        float wiggleZ = Mathf.Sin(Time.time * wiggleSpeed) * wiggleAmount * wiggleDirection.z;

        // Apply new position
        transform.localPosition = initialPosition + new Vector3(wiggleX, wiggleY, wiggleZ);
    }
}
