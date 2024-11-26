using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public AudioClip buttonClickSound; // AudioClip untuk suara tombol
    private AudioSource audioSource; // Referensi ke AudioSource
    public float sfxVolume = 2.0f;

    void Start()
    {
        // Mencari atau membuat AudioManager jika belum ada
        GameObject audioManager = GameObject.Find("AudioManager");
        if (audioManager == null)
        {
            audioManager = new GameObject("AudioManager");
            audioSource = audioManager.AddComponent<AudioSource>();
        }
        else
        {
            audioSource = audioManager.GetComponent<AudioSource>();
        }

        // Atur AudioClip di AudioSource
        audioSource.clip = buttonClickSound;
        audioSource.volume = sfxVolume;

        // Tambahkan listener untuk tombol ini
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(PlaySound);
        }
    }

    public void PlaySound()
    {
        if (audioSource.clip != null)
        {
            audioSource.PlayOneShot(audioSource.clip); // Mainkan suara
        }
    }
}
