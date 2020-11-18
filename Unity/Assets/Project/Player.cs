using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private void FixedUpdate()
    {
        base.Move(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
    }
}
