using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public Text Txt;
    public string[] txts;
    public int current;

    public float speed;

    private void Start()
    {
        UpdateTutorial();
    }
    public void UpdateTutorial()
    {
        if (current < txts.Length-1)
        {
            
            current++;
            StartCoroutine(PlayText());
        }
        else
        {
            gameObject.SetActive(false);
            FindObjectOfType<FirstStart>().GetGPU();
        }
    }

    IEnumerator PlayText()
    {
        Txt.GetComponent<Button>().interactable = false;
        Txt.text = "";
        foreach (char c in txts[current])
        {
            Txt.text += c;
            yield return new WaitForSeconds(speed);
        }
        Txt.GetComponent<Button>().interactable = true;
    }
}
