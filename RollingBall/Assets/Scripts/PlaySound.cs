using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource CollectSound;
    
        void OnTriggerEnter(Collider other)
        {
            CollectSound.Play();
        }
}
