using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Timeline;

public class CarBumpSounds : MonoBehaviour
{
    private AudioSource _audio;
    public AudioClip[] _clip;
    public PlayerController pc;

    private string obstacleTag = "Obstacle";

    private ulong clipIndex = 0;
    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)      
    {
        if (collision.gameObject.CompareTag(obstacleTag))
        {
            _audio.Play(clipIndex);
        }
    }
}
