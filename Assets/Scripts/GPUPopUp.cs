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
    }
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        GpuPopUp.SetActive(true);
        switch (type)
        {
            case Type.shop:
                FindObjectOfType<Shop>().ShopImg.sprite = GetComponent<GPU>().data.sprite;
                FindObjectOfType<Shop>().ShopTxt.text = GetComponent<GPU>().desc.text;
                FindObjectOfType<Shop>().ShopBtn.onClick.RemoveAllListeners();
                FindObjectOfType<Shop>().ShopBtn.onClick.AddListener(GetComponent<GPU>().Buy);
                break;
            case Type.objects:
                GetComponent<GPUObject>().UpdateValues(GetComponent<GPUObject>().damage);
                FindObjectOfType<Shop>().ObjectsImg.sprite = GetComponent<GPUObject>().data.sprite;
                FindObjectOfType<Shop>().ObjectsTxt.text = GetComponent<GPUObject>().data.Desc;
                FindObjectOfType<Shop>().ObjectsBtnSell.onClick.RemoveAllListeners();
                FindObjectOfType<Shop>().ObjectsBtnSell.onClick.AddListener(GetComponent<GPUObject>().Sell);
                FindObjectOfType<Shop>().ObjectsBtnWork.onClick.RemoveAllListeners();
                FindObjectOfType<Shop>().ObjectsBtnWork.onClick.AddListener(GetComponent<GPUObject>().Work);
                if(GetComponent<GPUObject>().damage <= 99f)
                {
                    FindObjectOfType<Shop>().ObjectsBtnWork.interactable = false;
                }
                else
                {
                    FindObjectOfType<Shop>().ObjectsBtnWork.interactable = true;
                }
                break;
            case Type.repair:

                break;
        }
    }
}
