using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Slider = UnityEngine.UI.Slider;
using TMPro;
public class VolumePercentage : MonoBehaviour
{

    [SerializeField] Slider Volumebar;
    [SerializeField] TextMeshProUGUI Volumepercent;
    float perc;
    int realperc;
    // Start is called before the first frame update
    void Start()
    {
        Volumepercent = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        perc = Volumebar.value * 100;
        realperc = (int)perc;
        Volumepercent.text = realperc+"%";
    }
}
