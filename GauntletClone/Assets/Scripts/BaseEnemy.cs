using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public int health = 100;
    public float speed = 1f;
    public bool onScreen = false;

    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        OnScreenCheck();
        if (onScreen == true)
            Chase();
    }

    private void Chase()
    {
        print("onScreen");
    }

    private void OnScreenCheck()
    {
        if (_renderer.isVisible)
            onScreen = true;
        else
            onScreen = false;
    }
}
