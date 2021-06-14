using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstStart : MonoBehaviour
{
    public GameObject[] Gpus;
    public GameObject FreeGpu;
    public GameObject Tutorial;
    void Start()
    {
        if (!PlayerPrefs.HasKey("FirstStart"))
        {
            Tutorial.SetActive(true); 
        }
    }
    public void GetGPU()
    {
        FreeGpu.SetActive(true);
    }

    public void AddFreeGpu(int id)
    {
        FindObjectOfType<GPUandRIGManager>().BuyGpu(Gpus[id]);
        PlayerPrefs.SetString("FirstStart", "Completed");
    }
}
