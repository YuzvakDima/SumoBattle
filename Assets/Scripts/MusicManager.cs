using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource = FindObjectOfType<AudioSource>();
        audioSource.loop = false;
    }
    private AudioClip GetRandomMusic()
    {
        return clips[Random.Range(0, clips.Length)];
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            audioSource.clip = GetRandomMusic();
            audioSource.Play();
        }
    }
}
