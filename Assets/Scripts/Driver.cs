using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 200f; 
    [SerializeField] float moveSpeed = 20f;   // default speed
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;

    private Coroutine speedRoutine; // keeps track if we’re already in a timed effect

    void Update()
    {
        float steerAmount = (Input.GetAxis("Horizontal") * steerSpeed) * Time.deltaTime;
        float speedAmount = (Input.GetAxis("Vertical") * moveSpeed) * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, speedAmount, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Environment"))
        {
            Debug.Log("Slowed!");
            ApplyTemporarySpeed(slowSpeed, 1f); // 1 second slow
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boost"))
        {
            Debug.Log("Boost activated!");
            ApplyTemporarySpeed(boostSpeed, 5f); // 5 second boost
        }
    }

    private void ApplyTemporarySpeed(float newSpeed, float duration)
    {
        // cancel any existing effect so they don’t stack weirdly
        /*
        Helper method that applies a new temporary speed effect.
        If there’s already a coroutine running (speedRoutine != null), stop it first so effects don’t overlap.
        Reset moveSpeed back to the default before starting the new one.
        Start a coroutine (TemporarySpeedRoutine) that will set the speed, wait, then reset it.
        */
        
        if (speedRoutine != null)
        {
            StopCoroutine(speedRoutine);
            moveSpeed = 5f; // reset to default before starting a new effect
        }

        speedRoutine = StartCoroutine(TemporarySpeedRoutine(newSpeed, duration));
    }

    private IEnumerator TemporarySpeedRoutine(float newSpeed, float duration)
    {
        float originalSpeed = moveSpeed;  // store default
        moveSpeed = newSpeed;
        yield return new WaitForSeconds(duration);
        moveSpeed = originalSpeed;  // revert back
        speedRoutine = null;
    }
}
