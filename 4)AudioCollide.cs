﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCollide : MonoBehaviour
{
    public AudioSource source;

    // Use this for initialization
    public void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    public void OnCollisionEnter(Collision collision)
    {
        source.Play();
        print("contact");
    }
}