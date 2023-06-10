using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public event EventHandler OnThrust;
    public event EventHandler OnStopThrust;

    private Rigidbody rigidbody;
    [SerializeField] private float thrustForce;
    [SerializeField] private float rotationSpeed;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust() {
        if (Input.GetKey(KeyCode.Space)) {
            rigidbody.AddRelativeForce(Vector3.up * Time.deltaTime * thrustForce);
            OnThrust?.Invoke(this, EventArgs.Empty);
        }

        if (Input.GetKeyUp(KeyCode.Space)) {
            OnStopThrust?.Invoke(this, EventArgs.Empty);
        }
    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A)) {
            ApplyRotation(Vector3.forward);
        } else if (Input.GetKey(KeyCode.D)) {
            ApplyRotation(Vector3.back);
        }
    }

    private void ApplyRotation(Vector3 direction) {
        rigidbody.freezeRotation = true;
        transform.Rotate(direction * Time.deltaTime * rotationSpeed);
        rigidbody.freezeRotation = false;
    }
}
