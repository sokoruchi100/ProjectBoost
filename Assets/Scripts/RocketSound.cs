using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSound : MonoBehaviour
{
    [SerializeField] private Movement movement;
    [SerializeField] private RocketCollision rocketCollision;
    [SerializeField] private AudioClip crashClip;
    [SerializeField] private AudioClip landClip;
    private AudioSource audioSource;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start() {
        movement.OnThrust += Movement_OnThrust;
        movement.OnStopThrust += Movement_OnStopThrust;
        rocketCollision.OnCrash += RocketCollision_OnCrash;
        rocketCollision.OnLand += RocketCollision_OnLand;
        movement.OnRotateLeft += Movement_OnRotateLeft;
        movement.OnStopRotateLeft += Movement_OnStopRotateLeft;
        movement.OnRotateRight += Movement_OnRotateRight;
        movement.OnStopRotateRight += Movement_OnStopRotateRight;
    }

    private void Movement_OnStopRotateRight(object sender, System.EventArgs e) {
        if (audioSource.isPlaying) {
            audioSource.Stop();
        }
    }

    private void Movement_OnRotateRight(object sender, System.EventArgs e) {
        if (!audioSource.isPlaying) {
            audioSource.Play();
        }
    }

    private void Movement_OnStopRotateLeft(object sender, System.EventArgs e) {
        if (audioSource.isPlaying) {
            audioSource.Stop();
        }
    }

    private void Movement_OnRotateLeft(object sender, System.EventArgs e) {
        if (!audioSource.isPlaying) {
            audioSource.Play();
        }
    }

    private void RocketCollision_OnLand(object sender, System.EventArgs e) {
        if (audioSource.isPlaying) {
            audioSource.Stop();
        }
        audioSource.PlayOneShot(landClip);
    }

    private void RocketCollision_OnCrash(object sender, System.EventArgs e) {
        if (audioSource.isPlaying) {
            audioSource.Stop();
        }
        audioSource.PlayOneShot(crashClip);
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
