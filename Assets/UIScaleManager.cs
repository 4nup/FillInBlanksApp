using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScaleManager : MonoBehaviour
{



    // Start is called before the first frame update

    float height;
    float width;

    void Start()
    {
        height = Screen.height;
        width = Screen.width;

        ModifyUIScale();
    }

    void ModifyUIScale()
    {
        //rec height = 1080
        //rec width = 1920
        float heightRatio = height / 1080.0f;
        float widthRatio = width / 1920.0f;

        float effectiveRatio = Mathf.Min(heightRatio, widthRatio);

        GetComponent<RectTransform>().localScale = Vector3.one * effectiveRatio;
    }
}
