using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float force = 10.0f;
    [SerializeField] private float lifeDuration = 3.0f;
    private Rigidbody rigidbody = null;    

    private void Awake()
    {
        this.rigidbody = this.GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        StartCoroutine(DestroySelf());
    }

    private void FixedUpdate()
    {
        this.ApplyForce();
    }

    private void ApplyForce()
    {
        this.rigidbody.AddRelativeForce(Vector3.forward * this.force);
    }

    private IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(lifeDuration);
        Destroy(this.gameObject);
    }
}
