using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketCollision : MonoBehaviour {
    public static RocketCollision Instance { get; private set; }

    public event EventHandler OnCrash;
    public event EventHandler OnLand;

    private const string RELOAD_SCENE_FUNCTION = "ReloadScene";
    private const string LOAD_NEXT_SCENE_FUNCTION = "LoadNextScene";
    private const string DAMAGER_TAG = "Damager";
    private const string LANDINGPAD_TAG = "Landingpad";

    [SerializeField]
    private float loadTime;

    private Movement movement;

    private int currentSceneIndex;
    private bool isTransitioning = false;

    private void Awake() {
        Instance = this;
        movement = GetComponent<Movement>();
    }

    private void Start() {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnCollisionEnter(Collision collision) {
        if (isTransitioning || DebugController.isGodmodeOn) { return; }

        switch (collision.gameObject.tag) {
            case DAMAGER_TAG:
                    StartCrashSequence();
                    OnCrash?.Invoke(this, EventArgs.Empty);
                break;
            case LANDINGPAD_TAG:
                    StartLoadSequence();
                    OnLand?.Invoke(this, EventArgs.Empty);
                break;
        }
    }

    private void StartCrashSequence() {
        isTransitioning = true;
        movement.enabled = false;
        Invoke(RELOAD_SCENE_FUNCTION, loadTime);
    }

    private void StartLoadSequence() {
        isTransitioning = true;
        movement.enabled = false;
        Invoke(LOAD_NEXT_SCENE_FUNCTION, loadTime);
        
    }

    private void ReloadScene() {
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void LoadNextScene() {
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings) {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}