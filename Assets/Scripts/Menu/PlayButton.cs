using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.SetInt("width", 1920);
        PlayerPrefs.SetInt("height", 1080);
       Screen.SetResolution(PlayerPrefs.GetInt("width"), PlayerPrefs.GetInt("width"),true);
        Debug.Log($"{Screen.width} + {Screen.height}");
    }
    public void OpenGame()
    {
        SceneManager.LoadScene(1);
    }
}
