using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    int projectileSpeed = 20;

    GameObject elfPlayer;
    GameObject wizardPlayer;
    GameObject warriorPlayer;
    GameObject valkyriePlayer;

    Vector3 instantiationPoint;

    bool projUp;
    bool projDown;
    bool projLeft;
    bool projRight;

    void Awake()
    {
        //possible players
        elfPlayer = GameObject.Find("Elf");
        wizardPlayer = GameObject.Find("Wizard");
        warriorPlayer = GameObject.Find("Warrior");
        valkyriePlayer = GameObject.Find("Valkyrie");
        //saves point of instantiation
        instantiationPoint = transform.position;
        //detects player's position
        if (elfPlayer.gameObject.GetComponent<Elf>().up == true || wizardPlayer.gameObject.GetComponent<Wizard>().up == true
            || warriorPlayer.gameObject.GetComponent<Warrior>().up == true || valkyriePlayer.gameObject.GetComponent<Valkyrie>().up == true)
        {
            projUp = true;
        }
        if (elfPlayer.gameObject.GetComponent<Elf>().down == true || wizardPlayer.gameObject.GetComponent<Wizard>().down == true
            || warriorPlayer.gameObject.GetComponent<Warrior>().down == true || valkyriePlayer.gameObject.GetComponent<Valkyrie>().down == true)
        {
            projDown = true;
        }
        if (elfPlayer.gameObject.GetComponent<Elf>().left == true || wizardPlayer.gameObject.GetComponent<Wizard>().left == true
            || warriorPlayer.gameObject.GetComponent<Warrior>().left == true || valkyriePlayer.gameObject.GetComponent<Valkyrie>().left == true)
        {
            projLeft = true;
        }
        if (elfPlayer.gameObject.GetComponent<Elf>().right == true || wizardPlayer.gameObject.GetComponent<Wizard>().right == true
            || warriorPlayer.gameObject.GetComponent<Warrior>().right == true || valkyriePlayer.gameObject.GetComponent<Valkyrie>().right == true)
        {
            projRight = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(projUp)
        {
            transform.position += Vector3.forward * Time.deltaTime * projectileSpeed;
        }
        if (projDown)
        {
            transform.position += Vector3.back * Time.deltaTime * projectileSpeed;
        }
        if (projLeft)
        {
            transform.position += Vector3.left * Time.deltaTime * projectileSpeed;
        }
        if (projRight)
        {
            transform.position += Vector3.right * Time.deltaTime * projectileSpeed;
        }
        //self destruct if moves too far away
        if(transform.position.z <= instantiationPoint.z - 20 || transform.position.z >= instantiationPoint.z + 20)
        {
            Destroy(gameObject);
        }
        if (transform.position.x <= instantiationPoint.x - 20 || transform.position.x >= instantiationPoint.x + 20)
        {
            Destroy(gameObject);
        }
    }
    //self destruct on collision
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider)
        {
            Destroy(gameObject);
        }
    }
}
