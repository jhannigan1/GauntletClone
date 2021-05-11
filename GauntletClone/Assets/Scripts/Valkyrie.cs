using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valkyrie : BasePlayer
{
    // Start is called before the first frame update
    void Start()
    {
        joysticknum = 2;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerAction();
    }
}
