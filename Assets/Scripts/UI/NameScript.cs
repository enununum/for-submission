using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class NameScript : MonoBehaviour
{
    public TMP_InputField inputName;

    public void NameSave()
    {
        PlayerPrefs.SetString("Name", inputName.text);
        LodingSceneController.LoadScene("GameScene1");
    }
}
