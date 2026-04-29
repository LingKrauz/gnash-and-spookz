using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


[RequireComponent(typeof(Slider))]
public class VolumeController : MonoBehaviour
{
    public Slider slider;
    public AudioMixer mixer;
    [SerializeField]
    private string volumeName;

    [SerializeField]
    private Text volumeLabel;

    // Start is called before the first frame update
    private void Start()
    {

        //slider = GetComponent<Slider>();

        if (PlayerPrefs.HasKey(volumeName + "Mixer"))
        {
            slider.value = PlayerPrefs.GetFloat(volumeName + "Mixer");
        }

        UpdateValueOnChange(slider.value);


        slider.onValueChanged.AddListener(delegate { UpdateValueOnChange(slider.value); });
    }

    public void UpdateValueOnChange(float value)
    {
        if (mixer != null)
        {
            mixer.SetFloat(volumeName, Mathf.Log(value) * 20);
            PlayerPrefs.SetFloat(volumeName + "Mixer", slider.value);
        }

        if (volumeLabel != null)
        {
            volumeLabel.text = Mathf.Round(value * 100.0f).ToString() + "%";
        }
    }

   public void ResetSlider()
    {
        if (PlayerPrefs.HasKey(volumeName + "Mixer"))
        {
            slider.value = PlayerPrefs.GetFloat(volumeName + "Mixer");
        }

    }
}
