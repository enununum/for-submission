using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject select;
    // Start is called before the first frame update
    public void Active()
    {
        SoundManager.instance.PlaySE("btn");
        select.gameObject.SetActive(true);
    }
    public void InActive()
    {
        SoundManager.instance.PlaySE("btn");
        select.gameObject.SetActive(false);
    }
}
