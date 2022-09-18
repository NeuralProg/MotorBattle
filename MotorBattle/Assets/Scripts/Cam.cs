using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public AudioClip boomFX;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("camShaking", false);
    }

    public void PlayBoomFX()
    {
        GetComponent<AudioSource>().PlayOneShot(boomFX);
        anim.SetBool("camShaking", true);
        Invoke("StopShaking", 1);
    }

    void StopShaking()
    {
        anim.SetBool("camShaking", false);
    }
}
