using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public AudioClip boomFx;

    public void playBoomFx()
    {
        GetComponent<AudioSource>().PlayOneShot(boomFx);
    }
}
