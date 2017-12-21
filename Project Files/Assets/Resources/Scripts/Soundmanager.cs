using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundmanager : MonoBehaviour {
    public AudioSource AttackSound;

    public void AttacSoundGo()
    {
        AttackSound.Play();
    }
}
