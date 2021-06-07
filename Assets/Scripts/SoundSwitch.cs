using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSwitch : MonoBehaviour
{
    public GameObject onImg;
    public GameObject offImg;

    public bool isOn;
    public void SetState()
    {
        isOn = !isOn;
        if (isOn)
        {
            onImg.SetActive(true);
            offImg.SetActive(false);
        }
        else{
            onImg.SetActive(false);
            offImg.SetActive(true);
        }
    }
}
