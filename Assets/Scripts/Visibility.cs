using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Visibility : MonoBehaviour
{
    Animator anim;
    Image img;
    private void Start()
    {
        anim = gameObject.transform.parent.gameObject.GetComponent<Animator>();
        img = gameObject.transform.parent.gameObject.GetComponent<Image>();
    }
    private void OnTriggerEnter(Collider other)
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        anim.enabled = false;
        img.enabled = false;
    }
    private void OnTriggerExit(Collider other)
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        anim.enabled = true;
        img.enabled = true;
    }
}
