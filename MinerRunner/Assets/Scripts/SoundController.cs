using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource sound;

    private void OnTriggerEnter(Collider other) {
        sound.Play();
    }
}
