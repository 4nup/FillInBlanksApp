using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMenuClicked()
    {
        SceneManager.LoadScene("MainMenu");
        AudioSingleton.Instance.PlayNextSound();
    }

    public void ButtonClicked()
    {
        AudioSingleton.Instance.PlayNextSound();
    }
}
