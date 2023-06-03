using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPage : MonoBehaviour
{
    [SerializeField] Button AnswerBtn;

    // Start is called before the first frame update
    void OnEnable()
    {
        if (GlobalVariables.submittedOnce)
        {
            AnswerBtn.interactable = true;
        }
        else
        {
            AnswerBtn.interactable = false;
        }
    }

}
