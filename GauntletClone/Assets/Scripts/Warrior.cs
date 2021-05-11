using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : BasePlayer
{
    // Start is called before the first frame update
    void Start()
    {
        joysticknum = 4;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerAction();
    }
}
