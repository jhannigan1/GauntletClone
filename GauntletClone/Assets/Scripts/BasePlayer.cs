using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer : MonoBehaviour
{
    //override floats in children
    //reference class discord
    int playerSpeed = 10;
    int playerHealth = 100;
    int playerScore;
    int keys;
    int potions;


    Vector3 currentPlayerPos;


    // Start is called before the first frame update
    void Start()
    {
        currentPlayerPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        if (playerHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// PlayerMove
    /// Includes base player movement
    /// Both Keyboard and Controller options
    /// </summary>
    void PlayerMove()
    {
        currentPlayerPos = transform.position;

        //keyboard option
        if (Input.GetKey("a"))
        {
            currentPlayerPos += Vector3.left * Time.deltaTime * playerSpeed;
        }
        if (Input.GetKey("d"))
        {
            currentPlayerPos += Vector3.right * Time.deltaTime * playerSpeed;
        }
        if (Input.GetKey("s"))
        {
            currentPlayerPos += Vector3.back * Time.deltaTime * playerSpeed;
        }
        if (Input.GetKey("w"))
        {
            currentPlayerPos += Vector3.forward * Time.deltaTime * playerSpeed;
        }
        //once we know the proper controlls, we can change the key. For now, I'm using "e" to test
        if(Input.GetKey("e") && potions >= 1)
        {
            potions--;
            Debug.Log("Potion Was Used");
        }


        //controller option
        //Debug.Log("Horizantal Input: " + Input.GetAxis("Horizontal"));
        //Debug.Log("Vertical Input: " + Input.GetAxis("Vertical"));
        if (Input.GetAxis("Vertical") >= .01)
        {
            currentPlayerPos += Vector3.forward * Time.deltaTime * playerSpeed;
        }
        if (Input.GetAxis("Vertical") <= -.01)
        {
            currentPlayerPos += Vector3.back * Time.deltaTime * playerSpeed;
        }
        if (Input.GetAxis("Horizontal") >= .01)
        {
            currentPlayerPos += Vector3.right* Time.deltaTime * playerSpeed;
        }
        if (Input.GetAxis("Horizontal") <= -.01)
        {
            currentPlayerPos += Vector3.left * Time.deltaTime * playerSpeed;
        }
        //again, just using a random button to test this control
        if (Input.GetButton("Fire1") && potions >=1)
        {
            potions--;
            Debug.Log("Potion Was Used");
        }
        transform.position = currentPlayerPos;
    }

    /// <summary>
    /// OnCollisionEnter
    ///If you would rather use an OnTriggerEnter function, go ahead and change it
    ///I just tend to default to OnCollisionEnter
    /// </summary>

    private void OnCollisionEnter(Collision collision)
    {
        //not sure why I'm getting these errors here, but it seems to be working so far
        if (collision.other.name.StartsWith("Key"))
        {
            Destroy(collision.other.gameObject);
            keys++;
            Debug.Log("Keys: " + keys);
        }
        if (collision.other.name.StartsWith("Door") && keys >= 1)
        {
            Destroy(collision.other.gameObject);
            keys--;
            Debug.Log("Keys: " + keys);
        }
        if (collision.other.name.StartsWith("Food"))
        {
            Destroy(collision.other.gameObject);
            playerHealth = playerHealth + 10;
            Debug.Log("Health: " + playerHealth);
        }
        if (collision.other.name.StartsWith("Potion"))
        {
            Destroy(collision.other.gameObject);
            potions++;
        }
        if (collision.other.name.StartsWith("Treasure"))
        {
            Destroy(collision.other.gameObject);
            playerScore = playerScore + 10;
            Debug.Log("Score: " + playerScore);
        }
    }
}
