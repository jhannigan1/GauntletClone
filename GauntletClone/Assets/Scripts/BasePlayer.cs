using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer : MonoBehaviour
{
    //override floats in children
    //reference class discord
    public int playerSpeed;
    public int playerHealth;
    public int playerScore;
    public int keys;
    public int potions;

    public int joysticknum;


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
    public void PlayerMove()
    {
        currentPlayerPos = transform.position;

        //keyboard option
        if (Input.GetKey("a"))
        {
            currentPlayerPos += Vector3.left * Time.deltaTime * playerSpeed * 2;
        }
        if (Input.GetKey("d"))
        {
            currentPlayerPos += Vector3.right * Time.deltaTime * playerSpeed * 2;
        }
        if (Input.GetKey("s"))
        {
            currentPlayerPos += Vector3.back * Time.deltaTime * playerSpeed * 2;
        }
        if (Input.GetKey("w"))
        {
            currentPlayerPos += Vector3.forward * Time.deltaTime * playerSpeed * 2;
        }

        //controller option
        //Debug.Log("Horizantal Input: " + Input.GetAxis("Horizontal"));
        //Debug.Log("Vertical Input: " + Input.GetAxis("Vertical"));
        if (Input.GetAxis("Vertical" + joysticknum.ToString()) >= .01)
        {
            currentPlayerPos += Vector3.forward * Time.deltaTime * playerSpeed * 2;
        }
        if (Input.GetAxis("Vertical" + joysticknum.ToString()) <= -.01)
        {
            currentPlayerPos += Vector3.back * Time.deltaTime * playerSpeed * 2;
        }
        if (Input.GetAxis("Horizontal" + joysticknum.ToString()) >= .01)
        {
            currentPlayerPos += Vector3.right* Time.deltaTime * playerSpeed * 2;
        }
        if (Input.GetAxis("Horizontal" + joysticknum.ToString()) <= -.01)
        {
            currentPlayerPos += Vector3.left * Time.deltaTime * playerSpeed * 2;
        }
        transform.position = currentPlayerPos;
    }

    public void PlayerAction()
    {
        if (Input.GetKey("e") && potions >= 1)
        {
            potions--;
            Debug.Log("Potion Was Used");
        }

        if (Input.GetButton("Fire1" + joysticknum.ToString()) && potions >= 1)
        {
            potions--;
            Debug.Log("Potion Was Used");
        }
        if(Input.GetButton("Fire2" + joysticknum.ToString()))
        {
            Debug.Log("Fire2 Pressed");
        }
        if (Input.GetButton("Fire3" + joysticknum.ToString()))
        {
            Debug.Log("Fire3 Pressed");
        }
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
