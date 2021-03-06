﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] private Animator animator = null;

    [SerializeField] new private Rigidbody rigidbody = null;

    [Range(5, 25)]
    [SerializeField] private float baseForce = 6;

    [Range(1, 5)]
    [SerializeField] private float rotateSpeed = 3;


    protected void Move(Vector3 direction)
    {
        Vector3 targetDir = this.transform.TransformDirection(direction) * this.baseForce;
        this.rigidbody.velocity = new Vector3(targetDir.x, this.rigidbody.velocity.y, targetDir.z);
        this.animator.SetFloat("xVel", direction.x);
        this.animator.SetFloat("zVel", direction.z);
    }
    protected void Rotate(float direction)
    {
        this.transform.Rotate(Vector3.up * direction * rotateSpeed);
    }

    protected abstract void Shoot();
}
