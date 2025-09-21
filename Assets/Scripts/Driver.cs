using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 200f; // 300 is course default
    [SerializeField] float moveSpeed = 7f; // 20 is course default. 

    void Update()
    {
        float steerAmount = (Input.GetAxis("Horizontal") * steerSpeed) * Time.deltaTime;
        float speedAmount = (Input.GetAxis("Vertical") * moveSpeed) * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, speedAmount, 0); 
    }

    void FixedUpdate()
    {   
        // Don't need yet (if ever in this project)
        //transform.Translate(1, 0, 0); 
    }
}
