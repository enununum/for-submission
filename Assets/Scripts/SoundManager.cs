using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


[System.Serializable]
public class Sound
{
    public string soundName;
    public AudioClip clip;
}
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioMixer masterMixer;
    public Slider bgmSlider;
    public Slider sfxSlider;

    [Header("Sounds")]
    [SerializeField] Sound[] bgmSounds;
    [SerializeField] Sound[] sfxSounds;

    [SerializeField] AudioSource bgmPlayer;

    [SerializeField] AudioSource[] sfxPlayer;


    private void Awake()
    {
        #region singleton
        if (instance == null)
        {
            instance=this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        //scene�� ��ȯ�Ǿ object�� �������� �ʵ�����
        DontDestroyOnLoad(gameObject);
        #endregion �̱���
    }

    void Start()
    {
        instance = this;
        bgmPlayer.Play();
    }

    public void StopBGM()
    {
        bgmPlayer.clip = null;
    }


    public void PlaySE(string _soundName)
    {
        for (int i = 0; i < sfxSounds.Length; i++)
        {
            if (_soundName == sfxSounds[i].soundName)
            {
                for (int x = 0; x < sfxPlayer.Length; x++)
                {
                    if (!sfxPlayer[x].isPlaying)
                    {
                        sfxPlayer[x].clip = sfxSounds[i].clip;
                        sfxPlayer[x].Play();
                        return;
                    }
                }
                return;
            }
        }
    }

    public void StopSfx()
    {
        sfxPlayer = null;
    }

    public void BGMAudioControl()
    {
        float sound = bgmSlider.value;

        if (sound == -40f) masterMixer.SetFloat("BGM", -80);
        else masterMixer.SetFloat("BGM", sound);
    }

    public void SFXAudioControl()
    {
        float sound = sfxSlider.value;

        if (sound == -40f) masterMixer.SetFloat("SFX", -80);
        else masterMixer.SetFloat("SFX", sound);
    }
}
