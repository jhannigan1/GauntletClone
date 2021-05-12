using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public int health = 100;
    public float speed = 2f;
    public bool onScreen = false;
        
    protected Renderer _renderer;
    protected List<Vector3> playerPositions = new List<Vector3>();
    protected Vector3 chaseVector;

    protected void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    protected void Update()
    {
        OnScreenCheck();
        if (onScreen == true)
            Chase();
    }
    
    protected void Chase()
    {
        int arrayPos = FindClosestPlayer();
        transform.position += (playerPositions[arrayPos] - transform.position).normalized * Time.deltaTime * speed;
    }

    protected void OnScreenCheck()
    {
        if (_renderer.isVisible)
            onScreen = true;
        else
            onScreen = false;
    }

    protected int FindClosestPlayer()
    {
        playerPositions.Clear();

        foreach (GameObject player in GameManager.GM.activePlayers)
        {
            playerPositions.Add(player.transform.position);
        }

        float dist = 0f;
        float last = 0f;
        int closest = 0;

        for (int i = 0; i < playerPositions.Count; i++)
        {
            //3D Pythagorean Theorem
            dist = Mathf.Sqrt(Mathf.Pow((transform.position.x - playerPositions[i].x), 2) + Mathf.Pow((transform.position.y - playerPositions[i].y), 2) + Mathf.Pow((transform.position.z - playerPositions[i].z), 2));
            if (i == 0)
                closest = i;
            else if (dist < last)
                closest = i;
            last = dist;
        }
        return closest;
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.tag == "projectile")
            TakeDamage();
    }

    protected void TakeDamage()
    {
        health -= 50;
        if (health <= 0)
            Destroy(this.gameObject);
    }
}
