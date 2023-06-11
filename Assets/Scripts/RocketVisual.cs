using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketVisual : MonoBehaviour
{
    [SerializeField]
    private Movement movement;
    [SerializeField]
    private ParticleSystem rocketJet;
    [SerializeField]
    private ParticleSystem rotator1;
    [SerializeField]
    private ParticleSystem rotator2;
    [SerializeField]
    private ParticleSystem rotator3;
    [SerializeField]
    private ParticleSystem rotator4;

    private void Start() {
        movement.OnThrust += Movement_OnThrust;
        movement.OnStopThrust += Movement_OnStopThrust;
        movement.OnRotateLeft += Movement_OnRotateLeft;
        movement.OnStopRotateLeft += Movement_OnStopRotateLeft;
        movement.OnRotateRight += Movement_OnRotateRight;
        movement.OnStopRotateRight += Movement_OnStopRotateRight;
    }

    private void Movement_OnStopRotateRight(object sender, System.EventArgs e) {
        rotator1.Stop();
        rotator3.Stop();
    }

    private void Movement_OnRotateRight(object sender, System.EventArgs e) {
        if (!rotator1.isPlaying) {
            rotator1.Play();
        }
        if (!rotator3.isPlaying) {
            rotator3.Play();
        }
    }

    private void Movement_OnStopRotateLeft(object sender, System.EventArgs e) {
        rotator2.Stop();
        rotator4.Stop();
    }

    private void Movement_OnRotateLeft(object sender, System.EventArgs e) {
        if (!rotator2.isPlaying) {
            rotator2.Play();
        }
        if (!rotator4.isPlaying) {
            rotator4.Play();
        }
    }

    private void Movement_OnStopThrust(object sender, System.EventArgs e) {
        rocketJet.Stop();
    }

    private void Movement_OnThrust(object sender, System.EventArgs e) {
        if (!rocketJet.isPlaying) {
            rocketJet.Play();
        }
    }
}
