using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoTitle : MonoBehaviour
{
    public void GoTitleBtn()
    {
        SoundManager.instance.PlaySE("btn");
        SceneManager.LoadScene("StartScene");
    }
}
