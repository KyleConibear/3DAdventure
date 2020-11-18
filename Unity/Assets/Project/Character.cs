using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Animator animator = null;

    [SerializeField] new private Rigidbody rigidbody = null;

    [Range(5, 25)]
    [SerializeField] private float baseForce = 6;

    protected void Move(Vector3 direction)
    {
        this.rigidbody.velocity = direction * this.baseForce;
        this.animator.SetFloat("xVel", direction.x);
        this.animator.SetFloat("zVel", direction.z);
    }
}
