using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVariables
{
    public static string?[] blanks = new string?[4];
    public static List<int> blankIndex = new List<int>();
    public static List<string> question = new List<string>();
    public static bool endsOnFullStop = false;
    public static bool submittedOnce = false;

    public static void Clean()
    {
        blankIndex.Clear();
        question.Clear();
        endsOnFullStop = false;
        submittedOnce = false;
    }
}
