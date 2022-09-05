using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public AudioClip boomFX;

    public void PlayBoomFX()
    {
        GetComponent<AudioSource>().PlayOneShot(boomFX);
    }
}
