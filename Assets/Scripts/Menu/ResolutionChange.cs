using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResolutionChange : MonoBehaviour
{
    private TMP_Dropdown resoldrop;

    // Start is called before the first frame update
    void Start()
    {
        resoldrop = this.GetComponent<TMP_Dropdown>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeresolution()
    {
        if(resoldrop.value == 0)
        {
            Screen.SetResolution(1366, 768,true);
        }
        else if (resoldrop.value == 1)
        {
            Screen.SetResolution(1600, 900, true);
        }
        else if (resoldrop.value == 2)
        {
            Screen.SetResolution(1920,1080, true);
        }
        else if (resoldrop.value == 3)
        {
            Screen.SetResolution(1920, 1200, true);
        }
        else if (resoldrop.value == 4)
        {
            Screen.SetResolution(2560, 1440, true);
        }
        else if (resoldrop.value == 5)
        {
            Screen.SetResolution(2560, 1600, true);
        }

    }
}
