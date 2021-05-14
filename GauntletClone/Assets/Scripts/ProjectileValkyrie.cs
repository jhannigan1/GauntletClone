using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileValkyrie : MonoBehaviour
{
    int projectileSpeed = 20;

    GameObject valkyriePlayer;

    Vector3 instantiationPoint;

    bool projUp;
    bool projDown;
    bool projLeft;
    bool projRight;

    void Awake()
    {
        valkyriePlayer = GameObject.Find("Valkyrie");
        //saves point of instantiation
        instantiationPoint = transform.position;
        //detects player's position
        if (valkyriePlayer.gameObject.GetComponent<Valkyrie>().up == true)
        {
            projUp = true;
        }
        if (valkyriePlayer.gameObject.GetComponent<Valkyrie>().down == true)
        {
            projDown = true;
        }
        if (valkyriePlayer.gameObject.GetComponent<Valkyrie>().left == true)
        {
            projLeft = true;
        }
        if (valkyriePlayer.gameObject.GetComponent<Valkyrie>().right == true)
        {
            projRight = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (projUp)
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
        if (transform.position.z <= instantiationPoint.z - 20 || transform.position.z >= instantiationPoint.z + 20)
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
