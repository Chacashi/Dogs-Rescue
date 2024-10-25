using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClipSO audioClipSO;
    public AudioSource audioSourceGeneral;
    AudioSource _compAudioSource;
    private void Awake()
    {
        _compAudioSource = GetComponent<AudioSource>();

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _compAudioSource.Play();
            audioClipSO.PlayOneShoot();
            audioSourceGeneral.Stop();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _compAudioSource.Stop();
            audioClipSO.PlayOneShoot();
            audioSourceGeneral.Play();
        }
    }
}
