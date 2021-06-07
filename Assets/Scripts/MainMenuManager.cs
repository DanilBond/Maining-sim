using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public GameObject shopPanel;
    public GameObject objectPanel;
    public GameObject settingsPanel;
    public Image[] imgs;
    public Color ActiveColor;

    public void CloseAll()
    {
        shopPanel.SetActive(false);
        objectPanel.SetActive(false);
        settingsPanel.SetActive(false);
        foreach (Image i in imgs)
        {
            i.color = Color.white;
        }
    }

    public void ActiveImage(Image img)
    {
        img.color = ActiveColor;
    }
    public void ShopOpenPanel()
    {
        shopPanel.SetActive(true);
    }
    public void ObjectListOpenPanel()
    {
        objectPanel.SetActive(true);
    }
  
    public void SettingsPanel()
    {
        if(settingsPanel.activeSelf == true)
        {
            settingsPanel.SetActive(false);
        }
        else
        {
            settingsPanel.SetActive(true);
        }
    }
    public void ShopClosePanel()
    {
        shopPanel.SetActive(false);
    }
    public void ObjectListClosePanel()
    {
        objectPanel.SetActive(false);
    }
    public void NewGame()
    {

    }
    public void LoadGame()
    {

    }
    public void Exit()
    {
        Application.Quit();
    }
}
