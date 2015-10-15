﻿using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    public float tumble;

    void Start()
    {
        Rigidbody rigibody = GetComponent<Rigidbody>();
        rigibody.angularVelocity = Random.insideUnitSphere * tumble;
    }
}
