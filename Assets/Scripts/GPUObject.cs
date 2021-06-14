﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPUObject : MonoBehaviour
{
    public Text damageTxt;
    public Image img;
    public Sprite Sprite;
    public GPUData data;
    public Image statusImg;
    public float damage;
    public Text NameText;
    private void Start()
    {
        img.sprite = data.sprite;
        NameText.text = "Видеокарта " + data.GP;
    }
    public void UpdateValues(float Damage)
    {
        damageTxt.text = Damage.ToString("0") + "%";
        if (damage >= 99f)
        {
            damage = 100f;
            statusImg.gameObject.SetActive(false);
        }
        else
        {
            statusImg.gameObject.SetActive(true);
        }
        
        if (Damage < 35f) { damageTxt.color = Color.red; }
        if (Damage >= 35f && Damage <= 60f) { damageTxt.color = Color.yellow; }
        if (Damage > 60f) { damageTxt.color = Color.green; }
        damage = Damage;
        img.sprite = data.sprite;
        
    }
    public void Sell()
    {
        Destroy(gameObject);
        FindObjectOfType<MoneyManager>().AddMoney((int)(data.Cost * damage / 100));
        Debug.Log((int)(data.Cost * damage / 100));
        GetComponent<GPUPopUp>().GpuPopUp.SetActive(false);
        FindObjectOfType<GPUandRIGManager>().AllGpuObjects.Remove(gameObject);

        if (FindObjectOfType<GPUandRIGManager>().AllGpuObjects.Count <= 0)
        {
            FindObjectOfType<MainMenuManager>().noneText.SetActive(true);
        }
        else
        {
            FindObjectOfType<MainMenuManager>().noneText.SetActive(false);
        }
    }
    public void Work()
    {
        Destroy(gameObject);
       // FindObjectOfType<MoneyManager>().AddMoney(data.Cost);
        GetComponent<GPUPopUp>().GpuPopUp.SetActive(false);
        FindObjectOfType<GPUandRIGManager>().AllGpuObjects.Remove(gameObject);
        FindObjectOfType<GPUandRIGManager>().BuyGpu(data.myPrefab);

        if (FindObjectOfType<GPUandRIGManager>().AllGpuObjects.Count <= 0)
        {
            FindObjectOfType<MainMenuManager>().noneText.SetActive(true);
        }
        else
        {
            FindObjectOfType<MainMenuManager>().noneText.SetActive(false);
        }
    }
}
