using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorcerer : BaseEnemy
{
    public float blinkRateMin = 0.5f;
    public float blinkRateMax = 5f;
    public float blinkDuration = 0.5f;

    private Collider _collider;

    private void Start()
    {
        _collider = GetComponent<Collider>();
        StartCoroutine("Blink");
    }

    IEnumerator Blink()
    {
        while (true)
        {
            _renderer.enabled = true;
            _collider.enabled = true;
            yield return new WaitForSeconds(Random.Range(blinkRateMin, blinkRateMax));
            _renderer.enabled = false;
            _collider.enabled = false;
            yield return new WaitForSeconds(blinkDuration);
        }
    }
}
