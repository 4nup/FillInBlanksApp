using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SortMainMenuManager : MonoBehaviour
{
    string gameSceneName = "Game";
    private AsyncOperation levelLoadingOperation;


    private void Start()
    {
        StartCoroutine(LoadLevelSceneAsyncRoutine());
    }


    public void PlayGame()
    {
        AudioSingleton.Instance.PlayNextSound();
        levelLoadingOperation.allowSceneActivation = true;
    }

    public void ExitGame()
    {
        Application.Quit();
    }


    private IEnumerator LoadLevelSceneAsyncRoutine()
    {
        // Load the level scene asynchronously
        levelLoadingOperation = SceneManager.LoadSceneAsync(gameSceneName);
        levelLoadingOperation.allowSceneActivation = false;

        while (!levelLoadingOperation.isDone)
        {
            // Wait for the scene to finish loading
            float progress = Mathf.Clamp01(levelLoadingOperation.progress / 0.9f);
            Debug.Log("Loading progress: " + (progress * 100) + "%");

            if (levelLoadingOperation.progress >= 0.9f)
            {
                // Scene is fully loaded, break out of the loop
                break;
            }

            yield return null;
        }
    }
}
