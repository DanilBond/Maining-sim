using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public GameObject shopPanel;
    public GameObject objectPanel;
    public GameObject settingsPanel;
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
