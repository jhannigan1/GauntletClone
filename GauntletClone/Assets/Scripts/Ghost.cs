using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : BaseEnemy
{
    new private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "dontdestroy")
        {
            Destroy(this.gameObject);
        }

        if (other.tag == "projectile")
        {
            TakeDamage();
        }
    }
}
