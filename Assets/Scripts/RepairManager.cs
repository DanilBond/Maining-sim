using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairManager : MonoBehaviour
{
    MoneyManager MM;
    GPUandRIGManager GARM;
    EnergyManager EM;

    public float delay = 1f;
    private void Start()
    {
        MM = FindObjectOfType<MoneyManager>();
        GARM = FindObjectOfType<GPUandRIGManager>();
        EM = FindObjectOfType<EnergyManager>();
        StartCoroutine(RepairIE());
    }

    IEnumerator RepairIE()
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            foreach (GameObject i in GARM.AllGpuObjects)
            {
                if(i.GetComponent<GPUObject>().damage <= 99f)
                {
                    i.GetComponent<GPUObject>().damage += 1f;
                    i.GetComponent<GPUObject>().UpdateValues(i.GetComponent<GPUObject>().damage);
                }
            }
        }
    }
    public void Repair()
    {
        int numOfGetsRepairGPUs = 0;
        foreach (GameObject i in GARM.AllGpu)
        {
            if(i.GetComponent<GPUMainPanelObject>().Damage <= 35f)
            {
                StopCoroutine("DeleteItems");
                StartCoroutine(DeleteItems(i));
                GameObject Gpu = Instantiate(GARM.GPUObjectPrefab, GARM.objectsContent.transform);
                Gpu.GetComponent<GPUObject>().data = i.GetComponent<GPUMainPanelObject>().data;
                Gpu.GetComponent<GPUObject>().UpdateValues(i.GetComponent<GPUMainPanelObject>().Damage);
                FindObjectOfType<AudioManager>().PlayAudio(1);
                GARM.AllGpuObjects.Add(Gpu);
                numOfGetsRepairGPUs++;
            }
        }
        FindObjectOfType<PowerSupply>().currentSlots -= numOfGetsRepairGPUs;
        FindObjectOfType<PowerSupply>().UpdateValues();
        if (FindObjectOfType<GPUandRIGManager>().AllGpuObjects.Count <= 0)
        {
            FindObjectOfType<MainMenuManager>().noneText.SetActive(true);
        }
        else
        {
            FindObjectOfType<MainMenuManager>().noneText.SetActive(false);
        }
    }

    IEnumerator DeleteItems(GameObject i)
    {
        yield return new WaitForSeconds(0.01f);
        switch (i.GetComponent<GPUMainPanelObject>().data.GP)
        {
            case "GTX 1040TI":
                GARM.AllGpu.Remove(i);
                GARM.AllGpuMain.Remove(i);
                GARM.GTX1050.Remove(i);
                Destroy(i);
                break;
            case "Graphics 1X":
                GARM.AllGpu.Remove(i);
                GARM.AllGpuMain.Remove(i);
                GARM.Graphics_1.Remove(i);
                Destroy(i);
                break;
            case "Graphics XS":
                GARM.AllGpu.Remove(i);
                GARM.AllGpuMain.Remove(i);
                GARM.X.Remove(i);
                Destroy(i);
                break;
            case "RTX 2000":
                GARM.AllGpu.Remove(i);
                GARM.AllGpuMain.Remove(i);
                GARM.RTX_3090.Remove(i);
                Destroy(i);
                break;
            case "REDEON 580":
                GARM.AllGpu.Remove(i);
                GARM.AllGpuMain.Remove(i);
                GARM.RX_570.Remove(i);
                Destroy(i);
                break;
            case "RED 7900 XT":
                GARM.AllGpu.Remove(i);
                GARM.AllGpuMain.Remove(i);
                GARM.XE.Remove(i);
                Destroy(i);
                break;
            case "RTX 2077 S":
                GARM.AllGpu.Remove(i);
                GARM.AllGpuMain.Remove(i);
                GARM.RTX_2060_Super.Remove(i);
                Destroy(i);
                break;
            case "RTX 4000G":
                GARM.AllGpu.Remove(i);
                GARM.AllGpuMain.Remove(i);
                GARM.RTX_4000.Remove(i);
                Destroy(i);
                break;
            case "Graphics Blue+":
                GARM.AllGpu.Remove(i);
                GARM.AllGpuMain.Remove(i);
                GARM.RX_590.Remove(i);
                Destroy(i);
                break;
            case "RED RX 475":
                GARM.AllGpu.Remove(i);
                GARM.AllGpuMain.Remove(i);
                GARM.RX_5600.Remove(i);
                Destroy(i);
                break;
            case "RED 6700XT":
                GARM.AllGpu.Remove(i);
                GARM.AllGpuMain.Remove(i);
                GARM.RX_6700XT.Remove(i);
                Destroy(i);
                break;
            case "Blue GOLD XE":
                GARM.AllGpu.Remove(i);
                GARM.AllGpuMain.Remove(i);
                GARM.RX_6900.Remove(i);
                Destroy(i);
                break;
            case "RTX Emerald":
                GARM.AllGpu.Remove(i);
                GARM.AllGpuMain.Remove(i);
                GARM.Intel_Predator.Remove(i);
                Destroy(i);
                break;
            case "Briliant Blue":
                GARM.AllGpu.Remove(i);
                GARM.AllGpuMain.Remove(i);
                GARM.RTX_5000.Remove(i);
                Destroy(i);
                break;
            case "RED Ruby XT":
                GARM.AllGpu.Remove(i);
                GARM.AllGpuMain.Remove(i);
                GARM.RX_9000.Remove(i);
                Destroy(i);
                break;

        }
        yield return new WaitForSeconds(0.015f);
        float avpt = 0f;
        foreach (GameObject j in GARM.AllGpuMain)
        {
            if (j.GetComponent<GPUMainPanelObject>().Damage > (int)0)
            {
                avpt += j.GetComponent<GPUMainPanelObject>().data.EarningPerTime;
            }
        }
        GARM.EarningPerTime = avpt;
    }
}
