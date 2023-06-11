using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketParticles : MonoBehaviour
{
    [SerializeField] 
    private ParticleSystem explosionParticles;
    [SerializeField]
    private ParticleSystem successParticles;
    [SerializeField]
    private RocketCollision rocketCollision;

    private void Start() {
        rocketCollision.OnCrash += RocketCollision_OnCrash;
        rocketCollision.OnLand += RocketCollision_OnLand;
    }

    private void RocketCollision_OnLand(object sender, System.EventArgs e) {
        successParticles.Play();
    }

    private void RocketCollision_OnCrash(object sender, System.EventArgs e) {
        explosionParticles.Play();
    }


}
