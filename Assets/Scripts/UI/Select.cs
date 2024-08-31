using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Assertions.Must;
using TMPro;

public class Select : MonoBehaviour
{
    public TMP_Text[] slotText;     
    public TMP_Text newPlayerName;  

    bool[] savefile=new bool[3];    

    void Start()
    {
        DataCheck();
        
        DataManager.instance.DataClear();
    }

    void DataCheck()
    {
        for (int i = 0; i < savefile.Length; i++)
        {
            if (File.Exists(DataManager.instance.path + $"{i}"))
            {
                savefile[i] = true;
                DataManager.instance.nowSlot = i;
                DataManager.instance.LoadData();
                slotText[i].text = DataManager.instance.nowPlayer.name + "\n"
                    + DataManager.instance.nowPlayer.scene;
            }
            else
            {
                slotText[i].text = "비어있슴";
            }
        }
    }

    public void Slot(int number)        
    {
        DataManager.instance.nowSlot = number;  

        if (savefile[number])   
        {
            DataManager.instance.LoadData();    
            GoGame();   
        }
    }
    
    public void GoGame()       
    {
        if (!savefile[DataManager.instance.nowSlot])    
        {
            string str = PlayerPrefs.GetString("Name");
            DataManager.instance.nowPlayer.name = str;   
            DataManager.instance.SaveData();   
        }
        LodingSceneController.LoadScene(DataManager.instance.nowPlayer.scene);
    }

    public void Save(int number)
    {
        string str = PlayerPrefs.GetString("Name");
        DataManager.instance.nowSlot = number;
        DataManager.instance.nowPlayer.name = str;
        DataManager.instance.SaveData();
    }
}
