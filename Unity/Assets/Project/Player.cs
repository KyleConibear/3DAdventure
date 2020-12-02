using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private Weapon weapon = null;

    private void FixedUpdate()
    {
        base.Move(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
    }

    private void Update()
    {
        base.Rotate(Input.GetAxis("Mouse X"));

        // Left click
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    protected override void Shoot()
    {
        weapon.Shoot();
    }
}
