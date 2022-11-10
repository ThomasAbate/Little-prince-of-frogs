using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Footsteps : MonoBehaviour
{
    
    [SerializeField] AudioClip[] audioClip;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void _Footsteps()
    {
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
    }


    private AudioClip GetRandomClip()
    {
        int index = Random.Range(0,audioClip.Length-1);
        audioSource.volume = Random.Range(0.6f, 0.8f);
        audioSource.pitch = Random.Range (0.95f, 1.05f);
        return audioClip[index];        
    }

}