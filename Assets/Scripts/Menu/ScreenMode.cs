using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScreenMode : MonoBehaviour
{
    private TMP_Dropdown screenmode;
    // Start is called before the first frame update
    void Start()
    {
        screenmode = this.GetComponent<TMP_Dropdown>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changescreenmode()
    {
        if(screenmode.value == 0) 
        {
            Screen.fullScreen = true;
        }
        else if(screenmode.value == 1) 
        {
            Screen.fullScreen = false;
        }
       
    }
}
