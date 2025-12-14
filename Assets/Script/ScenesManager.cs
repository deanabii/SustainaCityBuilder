using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{

    // public void LoadToScene(string sceneName)
    // {
    //     GameManager gm = FindObjectOfType<GameManager>();

    //     if (gm != null) {
    //         gm.SaveGame();
    //     }

    //     SceneManager.LoadScene(sceneName);
    // }

    // public void QuitGame()
    // {
    //     GameManager gm = FindObjectOfType<GameManager>();

    //     if (gm != null) {
    //         gm.SaveGame();
    //     }

    //     Application.Quit();
    //     Debug.Log("Game Saved and Quitting!");
    // }
    public void LoadToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
