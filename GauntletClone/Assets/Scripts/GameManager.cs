using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    public GameObject[] players;
    public List<GameObject> activePlayers;

    private void Awake()
    {
        GM = this;
    }

    private void Update()
    {
        activePlayers.Clear();

        foreach (GameObject player in players)
        {
            if (player.activeInHierarchy)
                activePlayers.Add(player);
        }        
    }
}
