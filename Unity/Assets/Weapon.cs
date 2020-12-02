using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject m_Projectile = null;

    public void Shoot()
    {
        Instantiate(m_Projectile, this.transform.position, this.transform.rotation);
    }
}
