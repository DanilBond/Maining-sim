using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Click : MonoBehaviour,IPointerClickHandler
{
    public GameObject ClickTextAnimated;
    public RectTransform VFXTransform;
    MoneyManager MM;
    GPUandRIGManager GARM;
    EnergyManager EM;

    public GameObject CoinVFX;
    public ParticleSystem[] Particles;

    public float delay;
    private void Start()
    {
        MM = FindObjectOfType<MoneyManager>();
        GARM = FindObjectOfType<GPUandRIGManager>();
        EM = FindObjectOfType<EnergyManager>();
        Particles = FindObjectsOfType<ParticleSystem>();
        StartCoroutine(researchParticles());
    }
    IEnumerator researchParticles()
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            Particles = FindObjectsOfType<ParticleSystem>();
        }
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (GARM.AllGpu.Count > 0)
        {
            if (EM.energyCount > 0f)
            {
                MM.AddMoney((int)GARM.Earning);
                // GameObject VFX = Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube), VFXTransform);
                // VFX.GetComponent<Text>().text = (int)GARM.Earning + "$";
                foreach (ParticleSystem i in Particles)
                {
                    i.Play();
                }
                EM.RemoveEnergy(1);
                for (int i = 0; i < GARM.AllGpu.Count; i++)
                {

                    GARM.AllGpuMain[i].GetComponent<GPUMainPanelObject>().UpdateValues();
                    if (GARM.AllGpuMain[i].GetComponent<GPUMainPanelObject>().Damage <= (int)0)
                    {
                        GARM.Check();
                    }
                    else
                    {
                        float rand = Random.Range(0.1f, 0.4f);
                        GARM.AllGpuMain[i].GetComponent<GPUMainPanelObject>().Damage -= rand;
                    }
                    
                }
            }
        }
    }
}
