using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusikManager : MonoBehaviour
{
    public static MusikManager instance;
    
    [SerializeField] private Image SoundOnIcon;
    [SerializeField] private Image SoundOffIcon;
    
    private bool muted = false;

    void Start()
    {
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }

        UpdateButtonIcon();
        AudioListener.pause = muted;
    }

    public void OnButtonPress()
    {
        // Toggle mute/unmute musik
        muted = !muted;
        AudioListener.pause = muted;

        Save();
        UpdateButtonIcon();
    }

    private void UpdateButtonIcon()
    {
        SoundOnIcon.enabled = !muted;
        SoundOffIcon.enabled = muted;
    }

    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
}
