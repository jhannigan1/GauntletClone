using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public int health = 100;
    public float speed = 1f;
    public bool onScreen = false;
        
    private Renderer _renderer;
    private List<Vector3> playerPositions = new List<Vector3>();
    private Vector3 chaseVector;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        OnScreenCheck();
        if (onScreen == true)
            Chase();
    }
    
    private void Chase()
    {
        int arrayPos = FindClosestPlayer();
        transform.position += (playerPositions[arrayPos] - transform.position).normalized * Time.deltaTime * speed;
    }

    private void OnScreenCheck()
    {
        if (_renderer.isVisible)
            onScreen = true;
        else
            onScreen = false;
    }

    private int FindClosestPlayer()
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
}
