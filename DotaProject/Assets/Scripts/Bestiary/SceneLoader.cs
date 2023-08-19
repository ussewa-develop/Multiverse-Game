using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    //загрузка сцены по выбранному имени
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
