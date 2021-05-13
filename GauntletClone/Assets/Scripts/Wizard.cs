﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : BasePlayer
{
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        joysticknum = 3;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerAction();
    }

    public override void SpecialAction()
    {
        Vector3 upInstantiation = new Vector3(transform.position.x, transform.position.y, (transform.position.z + 1.5f));
        Vector3 downInstantiation = new Vector3(transform.position.x, transform.position.y, (transform.position.z - 1.5f));
        Vector3 leftInstantiation = new Vector3((transform.position.x - 1.5f), transform.position.y, transform.position.z);
        Vector3 rightInstantiation = new Vector3((transform.position.x + 1.5f), transform.position.y, transform.position.z);

        if (up)
        {
            Instantiate(projectile, upInstantiation, Quaternion.identity);
        }
        if (down)
        {
            Instantiate(projectile, downInstantiation, Quaternion.identity);
        }
        if (left)
        {
            Instantiate(projectile, leftInstantiation, Quaternion.identity);
        }
        if (right)
        {
            Instantiate(projectile, rightInstantiation, Quaternion.identity);
        }
    }
}
