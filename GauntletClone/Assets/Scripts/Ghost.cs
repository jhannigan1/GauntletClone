using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : BaseEnemy
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            TakeDamage();
            TakeDamage();
        }

        if (other.tag == "projectile")
        {
            TakeDamage();
        }
    }
}
