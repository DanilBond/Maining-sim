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

    public Animator anim;
    AudioManager audio;
    private void Start()
    {
        audio = FindObjectOfType<AudioManager>();
        switch (data.GP)
        {
            case "GTX 1040TI":
                anim.SetBool("gtx1050", true);
                break;
            case "Graphics 1X":
                anim.SetBool("intel1", true);
                break;
            case "Graphics XS":
                anim.SetBool("intelX", true);
                break;
            case "RED 7900 XT":
                anim.SetBool("intelRed", true);
                break;
            case "RTX 2077 S":
                anim.SetBool("rtx2060", true);
                break;
            case "RTX 2000":
                anim.SetBool("rtx3090", true);
                break;
            case "RTX 4000G":
                anim.SetBool("rtx4000", true);
                break;
            case "REDEON 580":
                anim.SetBool("rx570", true);
                break;
            case "Graphics Blue+":
                anim.SetBool("rx590", true);
                break;
            case "RED RX 475":
                anim.SetBool("rx5600", true);
                break;
            case "RED 6700XT":
                anim.SetBool("rx6700", true);
                break;
            case "Blue GOLD XE":
                anim.SetBool("rx6900", true);
                break;
            case "RTX Emerald":
                anim.SetBool("predator", true);
                break;
            case "Briliant Blue":
                anim.SetBool("rtx5000", true);
                break;
            case "RED Ruby XT":
                anim.SetBool("rx9000", true);
                break;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            int first = 1;
            float q = 1.2f;
            
            for (int i = 0; i < 16; i++)
            {
                Debug.Log(i + "= " + first * Mathf.Pow(q,i));
            }
        }
    }
    bool ok = true;
    public void UpdateValues()
    {
        damageTxt.text = Damage.ToString("0") + "%";
        if (Damage < 1f) { if (ok) { if (audio != null) { audio.PlayAudio(4); } if (anim != null) { anim.enabled = false; } Damage = 0f; if (damageTxt != null) { damageTxt.text = "0%"; } ok = false; } }
        if (Damage < 35f) { damageTxt.color = Color.red; gameObject.transform.GetChild(2).GetChild(0).GetComponent<ParticleSystem>().Play(); }
        if (Damage >= 35f && Damage <= 60f) { damageTxt.color = Color.yellow; }
        if (Damage > 60f) { damageTxt.color = Color.green; }
        GetComponent<Image>().sprite = data.sprite;
        
    }
}
