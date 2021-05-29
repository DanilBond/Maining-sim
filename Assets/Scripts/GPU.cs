using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GPU : MonoBehaviour
{
    public GPUData data;
    public GameObject myPrefab;
    [Header("--------------------------")]
    public Sprite img;
    public Tear tear;

    public Text desc;
    public enum Tear
    {
        budgetary,
        middle,
        lux,
        gold,
        diamond
    }


    private void Start()
    {
        if (desc != null)
        {
            desc.text =
                "Производитель: " + data.Name + "\n" +
                "ГП: " + data.GP + "\n" +
                "Энергоотребление: " + data.Power + "W" + "\n" +
                "Доход за клик: " + data.Earning + "$" + "\n" +
                "Доход за миниту: " + data.EarningPerTime + "$" + "\n" +
                "Цена: " + data.Cost + "$";
        }
        transform.Find("Image").gameObject.GetComponent<Image>().sprite = img;

    }

    public void Buy()
    {
        if (FindObjectOfType<PowerSupply>().currentSlots < FindObjectOfType<PowerSupply>().maxSlots)
        {
            MoneyManager MM = FindObjectOfType<MoneyManager>();
            if (MM.GetCurrentMoneyCount() >= data.Cost)
            {
                MM.RemoveMoney(data.Cost);
                FindObjectOfType<GPUandRIGManager>().BuyGpu(this.gameObject);
            }
        }
    }
    
    
}
