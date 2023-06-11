using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugController : MonoBehaviour
{
    private const string DEBUG_TAG = "Debug";
    public static bool isGodmodeOn = false;
    private void Awake() {
        GameObject[] debugControllers = GameObject.FindGameObjectsWithTag(DEBUG_TAG);
        if (debugControllers.Length > 1) {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update() {
        //Load Next Scene
        if (Input.GetKeyDown(KeyCode.L)) {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            if (nextSceneIndex == SceneManager.sceneCountInBuildSettings) {
                nextSceneIndex = 0;
            }
            SceneManager.LoadScene(nextSceneIndex);
        }

        //Toggle NoClip
        if (Input.GetKeyDown(KeyCode.C)) {
            bool noClipOn = RocketCollision.Instance.GetComponent<BoxCollider>().enabled;
            RocketCollision.Instance.GetComponent<BoxCollider>().enabled = !noClipOn;
        }

        //Toggle Godmode
        if (Input.GetKeyDown(KeyCode.G)) {
            isGodmodeOn = !isGodmodeOn;
        }
    }
}
