using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Chat : MonoBehaviour
{
    public Image ChatImage;
    public Image EndCursor;
    public TMP_Text cText;
    public TMP_Text ChatText;
    public TMP_Text ChatNameText;
    public TMP_Text LogBtn;
    public TMP_Text AutoBtn;
    public TMP_Text SkipBtn;//스킵 만들어야함    
    public TMP_Text SaveBtn;
    public TMP_Text LoadBtn;
    public TMP_Text OptionBtn;

    public bool isClose = false;
    public void Close()
    {
        if (!isClose)  
        {
            SoundManager.instance.PlaySE("btn");
            isClose = true;
            cText.text = "Open";
            cText.color = Color.black;//잘 안보임 
            StartCoroutine(OpenCoroutine());
        }
        else if (isClose)        
        {
            SoundManager.instance.PlaySE("btn");
            isClose = false;
            cText.text = "Close";
            cText.color = Color.white;
            StartCoroutine(CloseCoroutine());
        }
    }

    IEnumerator OpenCoroutine()  
    {
        float fadeCount = 1;
        while (fadeCount > 0.0f)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            ChatImage.color = new Color(255, 255, 255, fadeCount);
            EndCursor.color = new Color(255, 255, 255, fadeCount);
            ChatText.color = new Color(255, 255, 255, fadeCount);
            ChatNameText.color = new Color(255, 255, 255, fadeCount);
            LogBtn.color = new Color(255, 255, 255, fadeCount);
            AutoBtn.color = new Color(255, 255, 255, fadeCount);
            SkipBtn.color = new Color(255, 255, 255, fadeCount);
            SaveBtn.color = new Color(255, 255, 255, fadeCount);
            LoadBtn.color = new Color(255, 255, 255, fadeCount);
            OptionBtn.color = new Color(255, 255, 255, fadeCount);
        }
    }

    IEnumerator CloseCoroutine()   
    {
        float fadeCount = 0;
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            ChatImage.color = new Color(255, 255, 255, fadeCount);
            EndCursor.color = new Color(255, 255, 255, fadeCount);
            ChatText.color = new Color(255, 255, 255, fadeCount);
            ChatNameText.color = new Color(255, 255, 255, fadeCount);
            LogBtn.color = new Color(255, 255, 255, fadeCount);
            AutoBtn.color = new Color(255, 255, 255, fadeCount);
            SkipBtn.color = new Color(255, 255, 255, fadeCount);
            SaveBtn.color = new Color(255, 255, 255, fadeCount);
            LoadBtn.color = new Color(255, 255, 255, fadeCount);
            OptionBtn.color = new Color(255, 255, 255, fadeCount);
        }
    }
}
