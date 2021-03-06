using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lobber : BaseEnemy
{
    public GameObject enemyProjectile;
    public float fireDelay = 2f;
    public float lobHeight = 5f;
    public float lobDistance = 10f;

    private void OnBecameVisible()
    {
        StartCoroutine("Fire");
    }

    IEnumerator Fire()
    {
        while (_renderer.isVisible)
        {
            yield return new WaitForSeconds(fireDelay);

            Vector3 fireAt = playerPositions[FindClosestPlayer()];

            GameObject clone = Instantiate(enemyProjectile, transform.position, Quaternion.identity);
            Rigidbody cloneRigid = clone.GetComponent<Rigidbody>();
            cloneRigid.velocity = (fireAt - transform.position).normalized * lobDistance;
            cloneRigid.velocity = new Vector3(cloneRigid.velocity.x, cloneRigid.velocity.y + lobHeight, cloneRigid.velocity.z);
        }
    }
}
