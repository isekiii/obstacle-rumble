using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public static AudioClip Bouncing, Falling, GettingHit, GainPoint, Jump, Kick, LevelCompl, Punch, Slide, Spawn;

    private static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        Bouncing = Resources.Load<AudioClip>("Bounce");
        Falling = Resources.Load<AudioClip>("Fall");
        GettingHit = Resources.Load<AudioClip>("Hit");
        GainPoint = Resources.Load<AudioClip>("Gain");
        Jump = Resources.Load<AudioClip>("jump");
        Kick = Resources.Load<AudioClip>("kick");
        LevelCompl = Resources.Load<AudioClip>("lvlcomp");
        Punch = Resources.Load<AudioClip>("punch");
        Slide = Resources.Load<AudioClip>("slide");
        Spawn = Resources.Load<AudioClip>("spawn");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Bounce":
                audioSrc.PlayOneShot(Bouncing);
                break;
            case "Fall":
                audioSrc.PlayOneShot(Falling);
                break;
            case "Hit":
                audioSrc.PlayOneShot(GettingHit);
                break;
            case "Gain":
                audioSrc.PlayOneShot(GainPoint);
                break;
            case "jump":
                audioSrc.PlayOneShot(Jump);
                break;
            case "kick":
                audioSrc.PlayOneShot(Kick);
                break;
            case "lvlcomp":
                audioSrc.PlayOneShot(LevelCompl);
                break;
            case "punch":
                audioSrc.PlayOneShot(Punch);
                break;
            case "slide":
                audioSrc.PlayOneShot(Slide);
                break;
            case "spawn":
                audioSrc.PlayOneShot(Spawn);
                break;
        }
    }
}
