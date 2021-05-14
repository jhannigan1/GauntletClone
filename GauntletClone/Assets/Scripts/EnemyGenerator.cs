using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public float spawnDelay = 2f;
    public GameObject enemyType;

    private Renderer _renderer;
    private Vector3 spawnPoint = Vector3.zero;
    private List<GameObject> myEnemies = new List<GameObject>();

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        foreach (GameObject enemy in myEnemies)
        {
            if (enemy == null)
                myEnemies.Remove(enemy);
        }
    }

    private void OnBecameVisible()
    {
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        //I think renderer.isVisible is bugged because this always returns true as well
        while (_renderer.isVisible)
        {
            yield return new WaitForSeconds(spawnDelay);

            if (myEnemies.Count < 5)
            {
                spawnPoint = ChooseSpawnPoint();
                GameObject clone = Instantiate(enemyType, (spawnPoint), Quaternion.identity);
                myEnemies.Add(clone);
            }
        }
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
