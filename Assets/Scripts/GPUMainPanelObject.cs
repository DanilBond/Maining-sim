using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPUMainPanelObject : MonoBehaviour
{
    public GPUData data;
    public float Damage;
    public float Temperature;
    public string tear;
    [SerializeField] Text damageTxt;


    private void Update()
    {
       
    }

    public void UpdateValues()
    {
        damageTxt.text = Damage.ToString("0") + "%";
        if (Damage < 35f) { damageTxt.color = Color.red; }
        if (Damage >= 35f && Damage <= 60f) { damageTxt.color = Color.yellow; }
        if (Damage > 60f) { damageTxt.color = Color.green; }
        GetComponent<Image>().sprite = data.sprite;
        
    }
}
