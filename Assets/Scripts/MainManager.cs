using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainManager : MonoBehaviour
{
    [SerializeField] GameObject[] questions;
    [SerializeField] GameObject nextButton;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject mainMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GlobalVariable.ansCount == 8)
        {
            nextButton.SetActive(true);
        }
    }

    public void Next()
    {
        nextButton.SetActive(false);
        GlobalVariable.ansCount = 0;

        if (questions[0].activeInHierarchy)
        {
            questions[0].SetActive(false);
            questions[1].SetActive(true);
            AudioSingleton.Instance.PlayNextSound();
        }

        else if (questions[2].activeInHierarchy)
        {
            panel.SetActive(true);
            mainMenu.SetActive(false);
            AudioSingleton.Instance.PlayWinSound();
        }

        
        else if (questions[1].activeInHierarchy)
        {
            questions[1].SetActive(false);
            questions[2].SetActive(true);
            AudioSingleton.Instance.PlayNextSound();
        }
    }

    public void MainMenu()
    {
        AudioSingleton.Instance.PlayNextSound();
        SceneManager.LoadScene("MainMenu");
    }
}
