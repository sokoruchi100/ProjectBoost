using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSound : MonoBehaviour
{
    [SerializeField] private Movement movement;
    private AudioSource audioSource;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start() {
        movement.OnThrust += Movement_OnThrust;
        movement.OnStopThrust += Movement_OnStopThrust;
    }

    private void Movement_OnStopThrust(object sender, System.EventArgs e) {
        if (audioSource.isPlaying) {
            audioSource.Stop();
        }
    }

    private void Movement_OnThrust(object sender, System.EventArgs e) {
        if (!audioSource.isPlaying) {
            audioSource.Play();
        }
    }
}
