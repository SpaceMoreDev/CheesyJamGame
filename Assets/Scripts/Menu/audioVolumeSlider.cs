using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Slider = UnityEngine.UI.Slider;

public class audioVolumeSlider : MonoBehaviour
{
    public Slider volumeSlider;

    private void Start()
    {
        volumeSlider = GetComponent<Slider>();
        volumeSlider.value = PlayerPrefs.GetFloat("volume");
    }
    public void changeVolume()
    {
        PlayerPrefs.SetFloat("volume",volumeSlider.value);
        PlayerPrefs.Save();
    }

    private void Update()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("volume");
    }
}
