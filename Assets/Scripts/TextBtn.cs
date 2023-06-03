using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBtn : MonoBehaviour
{
    private string initText;
    private int sno;
    private int thisIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        initText = this.transform.GetChild(0).GetComponent<TMP_Text>().text;
        thisIndex = GetIndex(this.gameObject, this.transform.parent.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int GetIndex(GameObject child, GameObject parent)
    {
        Transform parentTransform = parent.transform;
        for (int i = 0; i < parentTransform.childCount; i++)
        {
            if (parentTransform.GetChild(i).gameObject == child)
            {
                return i;
            }
        }
        return -1;
    }

    public void OnClick()
    {
        if(this.transform.GetChild(0).GetComponent<TMP_Text>().text == initText)
        {
            for(int i = 0; i < GlobalVariables.blanks.Length; i++)
            {
                if(GlobalVariables.blanks[i] == null)
                {
                    this.transform.GetChild(0).GetComponent<TMP_Text>().text = null;
                    GlobalVariables.blanks[i] = initText;
                    GlobalVariables.blankIndex.Add(thisIndex);
                    sno = i;
                    break;
                }
            }
        }

        else
        {
            this.transform.GetChild(0).GetComponent<TMP_Text>().text = initText;
            GlobalVariables.blanks[sno] = null;
            GlobalVariables.blankIndex.Remove(thisIndex);
        }
    }
}
