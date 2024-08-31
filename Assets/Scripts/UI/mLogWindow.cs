using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class mLogWindow : MonoBehaviour
{
    public static mLogWindow instance;

    public TMP_Text logText=null;
    public Scrollbar scrollbar;

    // Start is called before the first frame update
    void Awake()
    {
        #region singleton 
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        #endregion
    }

    public void PlusLog(string text)
    {
        logText.text += text;       
    }
}
