using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetManager : MonoBehaviour
{
    public void ReTranslate(string url)
    {
        Application.OpenURL(url);
    }
}
