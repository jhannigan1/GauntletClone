using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public float spawnDelay = 2f;
    public GameObject[] enemies;

    private GameObject enemyType;
    private Renderer _renderer;
    private Vector3 spawnPoint = Vector3.zero;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnBecameVisible()
    {
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        //I thinks renderer.isVisible is bugged in this version of Unity because this always returns true as well
        while (_renderer.isVisible)
        {
            yield return new WaitForSeconds(spawnDelay);

            enemyType = ChooseEnemy();
            spawnPoint = ChooseSpawnPoint();
            Instantiate(enemyType, (spawnPoint), Quaternion.identity);
        }
    }

    private GameObject ChooseEnemy()
    {
        return enemies[Random.Range(0, enemies.Length)];
    }

    private Vector3 ChooseSpawnPoint()
    {
        Vector3 tempV3 = transform.position;
        int tempInt = Random.Range(0, 3);
        switch (tempInt)
        {
            case 0:
                tempV3.x += 1;
                break;
            case 1:
                tempV3.z -= 1;
                break;
            case 2:
                tempV3.x -= 1;
                break;
            case 3:
                tempV3.z += 1;
                break;
            default:
                break;
        }
        return tempV3;
    }
}
