using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music_manager : MonoBehaviour
{
    public AudioClip sound_clip;
    private AudioSource sound_source;
    void Start()
    {
        sound_source = gameObject.AddComponent<AudioSource>();
        sound_source.clip = sound_clip;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            sound_source.Play();
        }
    }
}
