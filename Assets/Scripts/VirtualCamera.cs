using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VirtualCamera : MonoBehaviour
{
    private const string CAMERA_TAG = "VirtualCamera";
    private void Awake() {
        GameObject[] cameras = GameObject.FindGameObjectsWithTag(CAMERA_TAG);
        if (cameras.Length > 1) {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start() {
        SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;
    }

    private void SceneManager_activeSceneChanged(Scene arg0, Scene arg1) {
        GetComponent<CinemachineVirtualCamera>().LookAt = RocketCollision.Instance.transform;
    }
}
