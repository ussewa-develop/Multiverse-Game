using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Скрипт для локализации в любой точке кода
public class Localizator : MonoBehaviour
{
    public static string SplitString(string words) //метод для сплита строки по "_"
    {
        string[] temp = words.Split('_');
        string returnWord = "";
        foreach (string word in temp)
        {
            returnWord += word + " ";
        }
        return returnWord.Trim();
    }

    public static string Localize(string word) //метод для локализации
    {
        LocalizationManager localizationManager = GameObject.FindGameObjectWithTag("LocalizationManager").GetComponent<LocalizationManager>();
        return localizationManager.GetLocalizedValue(word);
    }
}
