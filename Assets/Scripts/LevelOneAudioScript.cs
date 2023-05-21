using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneAudioScript : MonoBehaviour
{
    [SerializeField] AudioClip jumpSFX;
    [SerializeField] AudioClip hitSFX;
    [SerializeField] AudioClip fuelSFX;
    [SerializeField] AudioClip emptySFX;
    [SerializeField] AudioClip winSFX;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GameObject.Find("AudioObject").GetComponent<AudioSource>();
    }

    public void PlayJumpSFX()
    {
        audioSource.PlayOneShot(jumpSFX, 0.2f);
    }

    public void PlayHitSFX()
    {
        audioSource.PlayOneShot(hitSFX, 0.2f);
    }

    public void PlayFuelSFX()
    {
        audioSource.PlayOneShot(fuelSFX, 0.2f);
    }

    public void PlayEmptySFX()
    {
        audioSource.PlayOneShot(emptySFX, 0.2f);
    }

    public void PlayWinSFX()
    {
        audioSource.PlayOneShot(winSFX, 0.2f);
    }

    public void Stop()
    {
        audioSource.Stop();
    }
}
