using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OutputManager : MonoBehaviour
{
    [SerializeField] TMP_Text question;
    [SerializeField] GameObject answers;
    [SerializeField] GameObject ansText;
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject retryPanel;

    private List<string> ans = new List<string>();
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        BlankCount();
        Sort();

        question.text += GlobalVariables.question[0];
        for (int i = 1; i < GlobalVariables.blankIndex.Count + 1; i++)
        {
            question.text += " " + "____________" + " " + GlobalVariables.question[i];
        }

        if (GlobalVariables.endsOnFullStop)
        {
            question.text += ".";
        }

        for(int i = 0; i < GlobalVariables.blankIndex.Count; i++)
        {
            Instantiate(ansText, answers.transform);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BlankCount()
    {
        for(int i = 0; i < 4; i++)
        {
            if(GlobalVariables.blankIndex != null)
            {
                count++;
            }
        }
    }

    void Sort()
    {
        string[] arr = GlobalVariables.blanks;
        List<int> lis = GlobalVariables.blankIndex;
        Debug.Log("lis: " + lis.Count);
        Debug.Log("arr: "+ arr.Length);

        // Create a dictionary to store the mapping of integers to strings
        Dictionary<int, string> dictionary = new Dictionary<int, string>();

        // Populate the dictionary
        for (int i = 0; i < lis.Count; i++)
        {
            dictionary.Add(lis[i], arr[i]);
        }

        // Sort the list in ascending order
        lis.Sort();

        // Create a new array to store the sorted strings
        string[] sortedArr = new string[lis.Count];

        // Populate the sorted array based on the sorted list
        for (int i = 0; i < lis.Count; i++)
        {
            sortedArr[i] = dictionary[lis[i]];
        }

        // Print the sorted array
        foreach (string str in sortedArr)
        {
            ans.Add(str);
        }
    }

    public void CheckAnswer()
    {
        int x = 0;
        for (int i = 0; i < GlobalVariables.blankIndex.Count; i++)
        {
            string tmpString = answers.transform.GetChild(i).GetChild(0).GetChild(2).GetComponent<TMP_Text>().text.ToString();
            if (tmpString.Substring(0, tmpString.Length - 1) == (ans[i].ToString()))
            {
                x++;
                Debug.Log("TRUE");
            }
            //else if ( tmpString.Substring(0, tmpString.Length - 2) == (ans[i].ToString()) && tmpString[tmpString.Length - 1] == '.')
            //{

            //}
            Debug.Log(answers.transform.GetChild(i).GetChild(0).GetChild(2).GetComponent<TMP_Text>().text.ToString());
            Debug.Log(ans[i]);
            Debug.Log(answers.transform.GetChild(i).GetChild(0).GetChild(2).GetComponent<TMP_Text>().text.ToString().Length);
            Debug.Log(ans[i].Length);
            //else { x = 0; }
        }
        if(x == GlobalVariables.blankIndex.Count)
        {
            winPanel.SetActive(false);
            retryPanel.SetActive(false);
            winPanel.SetActive(true);
        }
        else{ 
            retryPanel.SetActive(false);
            winPanel.SetActive(false);
            retryPanel.SetActive(true);
        }
    }
}
