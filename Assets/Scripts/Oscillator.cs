using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour {
    private Vector3 startingPosition;
    [SerializeField] private Vector3 directionVector;
    [SerializeField][Range(0, 1)] private float distance;

    private void Start() {
        startingPosition = transform.position;
    }

    private void Update() {
        Vector3 offset = directionVector * distance;
        transform.position = startingPosition + offset;
    }
}
