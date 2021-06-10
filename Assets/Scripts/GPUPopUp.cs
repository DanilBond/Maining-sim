using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GPUPopUp : MonoBehaviour, IPointerClickHandler
{
    public GameObject GpuPopUp;
    public enum Type
    {
        shop,
        objects,
        repair
    }
    public Type type;
    private void Start()
    {
        switch (type)
        {
            case Type.shop:
                GpuPopUp = FindObjectOfType<Shop>().ShopPopUp;
                break;
            case Type.objects:
                GpuPopUp = FindObjectOfType<Shop>().ObjectsPopUp;
                break;
            case Type.repair:
                GpuPopUp = FindObjectOfType<Shop>().RepairPopUp;
                break;
        }
        StartCoroutine(checkIE());
    }
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
       
        switch (type)
        {
            case Type.shop:
                GpuPopUp.SetActive(true);
                FindObjectOfType<Shop>().ShopImg.sprite = GetComponent<GPU>().data.sprite;
                FindObjectOfType<Shop>().ShopTxt.text = GetComponent<GPU>().desc.text;
                FindObjectOfType<Shop>().ShopName.text = GetComponent<GPU>().name.text;
                FindObjectOfType<Shop>().ShopBtn.onClick.RemoveAllListeners();
                FindObjectOfType<Shop>().ShopBtn.onClick.AddListener(GetComponent<GPU>().Buy);
                break;
            //case Type.objects:
            //    GetComponent<GPUObject>().UpdateValues(GetComponent<GPUObject>().damage);
            //    FindObjectOfType<Shop>().ObjectsImg.sprite = GetComponent<GPUObject>().data.sprite;
            //    FindObjectOfType<Shop>().ObjectsTxt.text = GetComponent<GPUObject>().data.Desc;
            //    FindObjectOfType<Shop>().ObjectsBtnSell.onClick.RemoveAllListeners();
            //    FindObjectOfType<Shop>().ObjectsBtnSell.onClick.AddListener(GetComponent<GPUObject>().Sell);
            //    FindObjectOfType<Shop>().ObjectsBtnWork.onClick.RemoveAllListeners();
            //    FindObjectOfType<Shop>().ObjectsBtnWork.onClick.AddListener(GetComponent<GPUObject>().Work);
            //    if(GetComponent<GPUObject>().damage <= 99f)
            //    {
            //        FindObjectOfType<Shop>().ObjectsBtnWork.interactable = false;
            //    }
            //    else
            //    {
            //        FindObjectOfType<Shop>().ObjectsBtnWork.interactable = true;
            //    }
            //    break;
            //case Type.repair:

            //    break;
        }
    }
    public GPUObject GPUObj;

    public void ObjectInspect(GPUObject GpuObj)
    {
        GpuPopUp.SetActive(true);
        GPUObj = GpuObj;
    }

    IEnumerator checkIE()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.4f);
            if (GpuPopUp.activeSelf == true)
            {
                if (GPUObj != null)
                {
                    GPUObj.UpdateValues(GPUObj.damage);
                    if (GPUObj.damage < 35f) { FindObjectOfType<Shop>().ObjectsDamage.color = Color.red; }
                    if (GPUObj.damage >= 35f && GPUObj.damage <= 60f) { FindObjectOfType<Shop>().ObjectsDamage.color = Color.yellow; }
                    if (GPUObj.damage > 60f) { FindObjectOfType<Shop>().ObjectsDamage.color = Color.green; }
                    FindObjectOfType<Shop>().ObjectsImg.sprite = GPUObj.data.sprite;
                    FindObjectOfType<Shop>().ObjectsTxt.text = GPUObj.data.Desc;
                    FindObjectOfType<Shop>().ObjectsDamage.text = GPUObj.damage.ToString("0") + "%";
                    FindObjectOfType<Shop>().ObjectsName.text = "Видеокарта " + GPUObj.data.Name;
                    FindObjectOfType<Shop>().ObjectsBtnSell.onClick.RemoveAllListeners();
                    FindObjectOfType<Shop>().ObjectsBtnSell.onClick.AddListener(GPUObj.Sell);
                    FindObjectOfType<Shop>().ObjectsBtnWork.onClick.RemoveAllListeners();
                    FindObjectOfType<Shop>().ObjectsBtnWork.onClick.AddListener(GPUObj.Work);
                    if (GPUObj.damage <= 99f)
                    {
                        FindObjectOfType<Shop>().ObjectsBtnWork.interactable = false;
                    }
                    else
                    {
                        FindObjectOfType<Shop>().ObjectsBtnWork.interactable = true;
                    }
                }
            }
            else
            {
                GPUObj = null;
            }
        }
    }
}
