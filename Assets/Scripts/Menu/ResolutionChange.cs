using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResolutionChange : MonoBehaviour
{
    private TMP_Dropdown resoldrop;
    [SerializeField] private TMP_Dropdown screenmode;
    bool fullscreenmode;

    // Start is called before the first frame update
    void Start()
    {
        resoldrop = this.GetComponent<TMP_Dropdown>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (screenmode.value == 0)
        {
            fullscreenmode = true;
        }
        else if (screenmode.value == 1)
        {
            fullscreenmode = false;
        }
        Screen.SetResolution(PlayerPrefs.GetInt("width"), PlayerPrefs.GetInt("height"), fullscreenmode);
    }

    public void changeresolution()
    {
        if(screenmode.value == 0)
        {
            if (resoldrop.value == 0)
            {
                Screen.SetResolution(1366, 768,fullscreenmode);
                PlayerPrefs.SetInt("width", 1366);
                PlayerPrefs.SetInt("height", 768);
            }
            else if (resoldrop.value == 1)
            {
                Screen.SetResolution(1600, 900,fullscreenmode);
                PlayerPrefs.SetInt("width", 1600);
                PlayerPrefs.SetInt("height", 900);
            }
            else if (resoldrop.value == 2)
            {
                Screen.SetResolution(1920, 1080,fullscreenmode);
                PlayerPrefs.SetInt("width", 1920);
                PlayerPrefs.SetInt("height", 1080);
            }
            else if (resoldrop.value == 3)
            {
                Screen.SetResolution(1920, 1200,fullscreenmode);
                PlayerPrefs.SetInt("width", 1920);
                PlayerPrefs.SetInt("height", 1200);
            }
            else if (resoldrop.value == 4)
            {
                Screen.SetResolution(2560, 1440,fullscreenmode);
                PlayerPrefs.SetInt("width", 2560);
                PlayerPrefs.SetInt("height", 1440);
            }
            else if (resoldrop.value == 5)
            {
                Screen.SetResolution(2560, 1600,fullscreenmode);
                PlayerPrefs.SetInt("width", 2560);
                PlayerPrefs.SetInt("height", 1600);
            }
        }
        else if (screenmode.value == 1)
        {
            if (resoldrop.value == 0)
            {
                Screen.SetResolution(1366, 768, fullscreenmode);
                PlayerPrefs.SetInt("width", 1366);
                PlayerPrefs.SetInt("height", 768);
            }
            else if (resoldrop.value == 1)
            {
                Screen.SetResolution(1600, 900, fullscreenmode);
                PlayerPrefs.SetInt("width", 1600);
                PlayerPrefs.SetInt("height", 900);
            }
            else if (resoldrop.value == 2)
            {
                Screen.SetResolution(1920, 1080, fullscreenmode);
                PlayerPrefs.SetInt("width", 1920);
                PlayerPrefs.SetInt("height", 1080);
            }
            else if (resoldrop.value == 3)
            {
                Screen.SetResolution(1920, 1200, fullscreenmode);
                PlayerPrefs.SetInt("width", 1920);
                PlayerPrefs.SetInt("height", 1200);
            }
            else if (resoldrop.value == 4)
            {
                Screen.SetResolution(2560, 1440, fullscreenmode);
                PlayerPrefs.SetInt("width", 2560);
                PlayerPrefs.SetInt("height", 1440);
            }
            else if (resoldrop.value == 5)
            {
                Screen.SetResolution(2560, 1600, fullscreenmode);
                PlayerPrefs.SetInt("width", 2560);
                PlayerPrefs.SetInt("height", 1600);
            }
        }
        Debug.Log("penis");

    }
}
