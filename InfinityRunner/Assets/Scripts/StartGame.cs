using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string levelToLoad;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameSceneLoader();
        }
    }

    public void GameSceneLoader()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
