using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Animation_sound : MonoBehaviour
{
    public AudioClip Breathing;
    public AudioClip Chase;
    public AudioClip Attack;
    public AudioClip Die;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    public void Wandering_sound()
    {
        audioSource.PlayOneShot(Breathing, 0.05f);
    }

    public void Chase_sound()
    {
        audioSource.PlayOneShot(Chase, 0.1f);

    }

    public void attack_sound()
    {
        audioSource.PlayOneShot(Attack, 0.15f);
    }

    public void Die_sound()
    {
        audioSource.PlayOneShot(Die, 0.3f);
    }


}
