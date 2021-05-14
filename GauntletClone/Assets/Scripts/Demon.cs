using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : BaseEnemy
{
    public GameObject enemyProjectile;
    public float fireDelay = 2f;
    public float projectileSpeed = 10f;

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
            clone.GetComponent<Rigidbody>().useGravity = false;
            clone.GetComponent<Rigidbody>().velocity = (fireAt - transform.position).normalized * projectileSpeed;
        }
    }
}
