using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip sfx, selectSfx;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void PlaySFX()
    {
        audioSource.PlayOneShot(sfx, 0.5f);
    }

    public void PlaySelectSFX()
    {
        audioSource.PlayOneShot(selectSfx, 0.5f);
    }
}
