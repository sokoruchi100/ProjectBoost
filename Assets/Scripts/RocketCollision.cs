using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketCollision : MonoBehaviour
{
    private const string DAMAGER_TAG = "Damager";
    private const string LANDINGPAD_TAG = "Landingpad";

    private void OnCollisionEnter(Collision collision) {
        switch (collision.gameObject.tag) {
            case DAMAGER_TAG:
                Debug.Log("Oof! Your ship has crashed!");
                ReloadScene();
                break;
            case LANDINGPAD_TAG:
                Debug.Log("Yay! You made it!");
                break;
        }
    }

    private static void ReloadScene() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}