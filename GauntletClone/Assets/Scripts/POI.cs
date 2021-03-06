using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POI : MonoBehaviour
{
    public GameObject[] players;
    public List<GameObject> activePlayers;

    //Keeps a list of which players are active
    private void Update()
    {
        activePlayers.Clear();

        foreach (GameObject player in players)
        {
            if (player.activeInHierarchy)
                activePlayers.Add(player);
        }

        FindMidPoint();
    }

    //Finds the average position of all active players and moves the POI to it
    private void FindMidPoint()
    {
        Vector3 tempV3 = new Vector3(0, 0, 0);

        foreach (GameObject player in activePlayers)
        {
            tempV3 += player.transform.position;
        }

        this.transform.position = tempV3 / activePlayers.Count;
    }
}
