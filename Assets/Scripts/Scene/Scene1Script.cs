using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using KoreanTyper;

public class Scene1Script : MonoBehaviour
{
    public GameObject b1;
    public GameObject b2;
    public GameObject EndCursor;
    public Chat CloseBtn;

    public Image emptyImage;
    public Sprite chageSprite;

    public TMP_Text ChatTMP;
    public TMP_Text CharacterName;

    public string writerText = "";
    public bool auto=false;
    public int CharPerSeconds=10;
    public bool typingSkip=true;
    public bool click;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("Scene","GameScene1"); ; 
        b1.SetActive(false);
        b2.SetActive(false);
        
        StartCoroutine(Speech());
    }

    // Update is called once per frame
    void Update()
    {
        if (click||Input.GetKeyDown(KeyCode.Space))
        {
            typingSkip = false;
        }
    }

    IEnumerator NomalChat(string narrator, string narration,int person)
    {
        SoundManager.instance.PlaySE("btn");

        int typingLength=narration.GetTypingLength();

        CharacterName.text = narrator;
        ChatTMP.text = "";
        typingSkip = true;
        click = false;
        float intervel = 1 / (float)CharPerSeconds;

        EndCursor.SetActive(false);

        switch (person)
        {
            case 1:
                emptyImage.sprite = chageSprite;
                break;
        }
                   
        
        for (int i = 0; i <= typingLength; i++) //typing
        {           
            if (!typingSkip&&!CloseBtn.isClose)    
            {
                ChatTMP.text = narration;
                break;
            }          
            ChatTMP.text = narration.Typing(i);
            yield return new WaitForSeconds(intervel);
        }    
        click = false;
        typingSkip = false;
        EndCursor.SetActive(true);
        mLogWindow.instance.PlusLog(narrator + ":" + narration + "\n\n"); 

        
        while (true) //waiting
        {
            if (!auto)
            {
                if ((click||Input.GetKeyDown(KeyCode.Space))&&!CloseBtn.isClose)
                {
                     break;
                }
            }
            else
            {
                yield return new WaitForSeconds(3);
                break;
            }
            yield return null;
        }
    }

    IEnumerator Speech()
    {
        string str = PlayerPrefs.GetString("Name");
        yield return StartCoroutine(NomalChat("Test", "\"마법소녀가 되지 않을래?\"",0));
        yield return StartCoroutine(NomalChat(str, "살려줘요",0));
        yield return StartCoroutine(NomalChat("Test","동해물과 백두산이 마르고 닳도록",0));
        yield return StartCoroutine(NomalChat("Test", "테스트테스트테스트테스트테스트테스트테스트", 0));
    }

    public void Auto()//오토인걸 알아야 함
    {
        auto = !auto;
        SoundManager.instance.PlaySE("btn");
    }

    public void Click()
    {
        if (!CloseBtn.isClose)
            click = true;
    }

    //스킵만들어야함 + 정리 필요
}
