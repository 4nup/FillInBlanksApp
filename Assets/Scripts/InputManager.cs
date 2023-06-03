using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputManager : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] GameObject textBtns;
    [SerializeField] GameObject textBtnPrefab;

    private List<string> words = new List<string>();
    private List<int> blankBtnList = new List<int>();
        

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnProceed()
    {
        GlobalVariables.Clean();
        string inputString = inputField.text.Trim();
        if (inputString[inputString.Length-1] == '.')
        {
            GlobalVariables.endsOnFullStop = true;
        }
        string[] substrings = inputString.Split(new[] { ' ', ',', '.', '!', '?'}, System.StringSplitOptions.RemoveEmptyEntries);

        words.Clear();
        for(int i = 0; i < 4; i++)
        {
            GlobalVariables.blanks[i] = null;
        }
        DestroyAllChildren();
        words.AddRange(substrings);

        foreach(string word in words)
        {
            
            
            GameObject obj = Instantiate(textBtnPrefab);
            obj.transform.SetParent(textBtns.transform);
            obj.transform.GetChild(0).GetComponent<TMP_Text>().text = word;
        }
    }


    void DestroyAllChildren()
    {
        int childCount = textBtns.transform.childCount;

        for (int i = childCount - 1; i >= 0; i--)
        {
            Transform child = textBtns.transform.GetChild(i);
            Destroy(child.gameObject);
        }
    }

    public void OnSubmit()
    {

        QuestionMaker();
        GlobalVariables.submittedOnce = true;
        foreach (string str in GlobalVariables.blanks)
        {
            Debug.Log(str);
        }
        foreach (string str in GlobalVariables.question)
        {
            Debug.Log(str);
        }
        foreach (int i in GlobalVariables.blankIndex)
        {
            Debug.Log(i);
        }
    }

    void QuestionMaker()
    {
        string[] btnText = new string[textBtns.transform.childCount];
        for (int i = 0; i < textBtns.transform.childCount; i++)
        {
            btnText[i] = textBtns.transform.GetChild(i).GetChild(0).GetComponent<TMP_Text>().text;
            if (textBtns.transform.GetChild(i).GetChild(0).GetComponent<TMP_Text>().text ==  null)
            {
                blankBtnList.Add(i);
            }
        }
        string[] stringer = JoinStrings(btnText, blankBtnList);
        foreach(string str in stringer)
        {
            GlobalVariables.question.Add(str);
        }
    }

    string[] JoinStrings(string[] strings, List<int> indexes)
    {
        string[] result = new string[indexes.Count + 1];

        result[0] = string.Join(" ", strings, 0, indexes[0]);

        for (int i = 0; i < indexes.Count - 1; i++)
        {
            result[i + 1] = string.Join(" ", strings, indexes[i] + 1, indexes[i + 1] - indexes[i] - 1);
        }

        result[result.Length - 1] = string.Join(" ", strings, indexes[indexes.Count - 1] + 1, strings.Length - indexes[indexes.Count - 1] - 1);

        return result;
    }
}
