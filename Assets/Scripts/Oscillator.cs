using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour {
    private Vector3 startingPosition;
    [SerializeField] private Vector3 directionVector;
    [SerializeField] [Range(0, 1)] private float distance;
    [SerializeField] private float period;
    private const float TAU = Mathf.PI * 2;

    private void Start() {
        startingPosition = transform.position;
    }

    private void Update() {
        if (period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / period;

        float sinValue = Mathf.Sin(cycles * TAU);

        distance = (sinValue + 1) / 2;

        Vector3 offset = directionVector * distance;
        transform.position = startingPosition + offset;
    }
}
