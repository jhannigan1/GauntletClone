using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

abstract public class BasePlayer : MonoBehaviour
{
    //override floats in children
    //reference class discord
    public int playerSpeed;
    public int playerHealth;
    public int playerScore;
    public int keys;
    public int potions;
    public int joysticknum;


    //in inspector, choose if you want the keyboard option
    //Only one player can use at a time
    public bool keyboardOption;
    //direction
    public bool up = false;
    public bool down = false;
    public bool left = false;
    public bool right = false;

    public Vector3 currentPlayerPos;

    GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        currentPlayerPos = transform.position;
        canvas = GameObject.Find("Canvas");
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
        if (keyboardOption)
        {
            if (Input.GetKey("a"))
            {
                currentPlayerPos += Vector3.left * Time.deltaTime * playerSpeed * 2;
                up = false;
                down = false;
                left = true;
                right = false;
            }
            if (Input.GetKey("d"))
            {
                currentPlayerPos += Vector3.right * Time.deltaTime * playerSpeed * 2;
                up = false;
                down = false;
                left = false;
                right = true;
            }
            if (Input.GetKey("s"))
            {
                currentPlayerPos += Vector3.back * Time.deltaTime * playerSpeed * 2;
                up = false;
                down = true;
                left = false;
                right = false;
            }
            if (Input.GetKey("w"))
            {
                currentPlayerPos += Vector3.forward * Time.deltaTime * playerSpeed * 2;
                up = true;
                down = false;
                left = false;
                right = false;
            }
        }
        

        //controller option
        if (Input.GetAxis("Vertical" + joysticknum.ToString()) >= .01)
        {
            currentPlayerPos += Vector3.forward * Time.deltaTime * playerSpeed * 2;
            up = true;
            down = false;
            left = false;
            right = false;
        }
        if (Input.GetAxis("Vertical" + joysticknum.ToString()) <= -.01)
        {
            currentPlayerPos += Vector3.back * Time.deltaTime * playerSpeed * 2;
            up = false;
            down = true;
            left = false;
            right = false;
        }
        if (Input.GetAxis("Horizontal" + joysticknum.ToString()) >= .01)
        {
            currentPlayerPos += Vector3.right* Time.deltaTime * playerSpeed * 2;
            up = false;
            down = false;
            left = false;
            right = true;
        }
        if (Input.GetAxis("Horizontal" + joysticknum.ToString()) <= -.01)
        {
            currentPlayerPos += Vector3.left * Time.deltaTime * playerSpeed * 2;
            up = false;
            down = false;
            left = true;
            right = false;
        }
        transform.position = currentPlayerPos;
    }

    /// <summary>
    /// PlayerAction
    /// For using potions and throwing items
    /// </summary>

    public void PlayerAction()
    {
        if (keyboardOption)
        {
            //potions
            if (Input.GetKeyDown("q") && potions >= 1)
            {
                potions--;
                ClearEnemies();
            }
            //special
            if (Input.GetKeyDown("space"))
            {
                SpecialAction();
            }
        }
        
        //potions
        if (Input.GetButtonDown("Fire1" + joysticknum.ToString()) && potions >= 1)
        {
            potions--;
            ClearEnemies();
        }
        //special
        if(Input.GetButtonDown("Fire2" + joysticknum.ToString()))
        {
            SpecialAction();
        }
    }

    public abstract void SpecialAction();


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
        }
        if (collision.other.name.StartsWith("Door") && keys >= 1)
        {
            Destroy(collision.other.gameObject);
            keys--;
        }
        if (collision.other.name.StartsWith("Food"))
        {
            Destroy(collision.other.gameObject);
            playerHealth = playerHealth + 10;
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
        }
        if (collision.other.name.StartsWith("Exit"))
        {
            SwitchScenes();
        }
        if (collision.other.tag == "enemy")
        {
            playerHealth = playerHealth - 5;
        }
    }

    void ClearEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject enemy in enemies)
        {
            GameObject.Destroy(enemy);
        }
    }

    void SwitchScenes()
    {
        Object.DontDestroyOnLoad(gameObject);
        Object.DontDestroyOnLoad(canvas);
        SceneManager.LoadScene(1);
    }
}
