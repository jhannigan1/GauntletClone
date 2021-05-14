using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWizard : MonoBehaviour
{
    int projectileSpeed = 20;

    GameObject wizardPlayer;

    Vector3 instantiationPoint;

    bool projUp;
    bool projDown;
    bool projLeft;
    bool projRight;

    void Awake()
    {
        wizardPlayer = GameObject.Find("Wizard");
        //saves point of instantiation
        instantiationPoint = transform.position;
        //detects player's position
        if (wizardPlayer.gameObject.GetComponent<Wizard>().up == true)
        {
            projUp = true;
        }
        if (wizardPlayer.gameObject.GetComponent<Wizard>().down == true)
        {
            projDown = true;
        }
        if (wizardPlayer.gameObject.GetComponent<Wizard>().left == true)
        {
            projLeft = true;
        }
        if (wizardPlayer.gameObject.GetComponent<Wizard>().right == true)
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
