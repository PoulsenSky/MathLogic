using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuManagement : MonoBehaviour
{

    private void Update()
    {

    }
    public void ChangeScene(string Scenes)
    {
        SceneManager.LoadScene(Scenes);
    }
}
