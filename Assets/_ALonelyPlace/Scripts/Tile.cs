using System;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject model;

    public float life;
    public float timer;

    private bool _active;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        model.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!_active)
            return;
        
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 0;
            model.SetActive(false);
            _active = false;
        }
    }

    private void ActivateTile()
    {
        timer = life;
        model.SetActive(true);
        _active = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cane"))
        {
            ActivateTile();
        }
        else
        {
            print ("Error: Tile.cs OnTriggerEnter: " + other.name + " does not have tag Cane");
        }
    }
}
