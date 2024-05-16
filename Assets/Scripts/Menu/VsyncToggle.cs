using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VsyncToggle : MonoBehaviour
{
    private Toggle tog;
    // Start is called before the first frame update
    void Start()
    {
        tog = GetComponent<Toggle>();
        QualitySettings.vSyncCount = PlayerPrefs.GetInt("vsync");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void activatevsync()
    {
        if(tog.isOn)
        {
            QualitySettings.vSyncCount = 1;
            PlayerPrefs.SetInt("vsync", 1);
        }
        else if (!tog.isOn) 
        {
            QualitySettings.vSyncCount = 0;
            PlayerPrefs.SetInt("vsync", 0);
        }
    }
}
