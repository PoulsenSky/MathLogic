using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public string sceneChange;
    public float delayInSeconds = 2f;

    private void Start()
    {
        Invoke("LoadSceneWithDelay", delayInSeconds);
    }

    private void LoadSceneWithDelay()
    {
        SceneManager.LoadScene(sceneChange);
    }

    void Update() {
        if(delayInSeconds >= 2f) {
            if(Input.GetKeyDown(KeyCode.RightArrow)) {
                Debug.Log("Proceed to next scene");
                SceneManager.LoadScene(sceneChange);
            }
        }
    }
}
