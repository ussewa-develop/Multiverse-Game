using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Localizator : MonoBehaviour
{
    public static string SplitString(string words)
    {
        string[] temp = words.Split('_');
        string returnWord = "";
        foreach (string word in temp)
        {
            returnWord += word + " ";
        }
        return returnWord.Trim();
    }

    public static string Localize(string word)
    {
        LocalizationManager localizationManager = GameObject.FindGameObjectWithTag("LocalizationManager").GetComponent<LocalizationManager>();
        return localizationManager.GetLocalizedValue(word);
    }
}
