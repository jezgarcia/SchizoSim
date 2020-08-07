﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShakeObject : MonoBehaviour
{
    public float MovementShakeStrength = 0.2f;
    public float RotationShakeStrength = 5.0f;
    public float volume=0.5f;

    public AudioSource audioSource;
    public AudioClip[] audioClipArray;

    Vector3 m_StartPosition;
    Quaternion m_StartRotation;
    bool m_Shaking = false;

    AudioClip RandomClip(){
        return audioClipArray[Random.Range(0, audioClipArray.Length-1)];
    }

    void Update()
    {
        if (m_Shaking)
        {
            transform.localPosition = m_StartPosition + Random.insideUnitSphere * MovementShakeStrength;
            transform.localRotation = m_StartRotation * Quaternion.Euler(Random.insideUnitSphere * RotationShakeStrength);
        }
    }

    public void StartShaking()
    {
        m_StartPosition = transform.localPosition;
        m_StartRotation = transform.localRotation;
        m_Shaking = true;
        audioSource.PlayOneShot(RandomClip(), volume);
    }

    public void StopShaking()
    {
        transform.localPosition = m_StartPosition;
        transform.localRotation = m_StartRotation;
        m_Shaking = false;
    }
}
