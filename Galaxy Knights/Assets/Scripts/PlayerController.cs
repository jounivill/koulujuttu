﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerController : MonoBehaviour
{
    public float speed;
    public float tilt;

    public GameObject Shot1;
    public Transform ShotSpawn;
    public float fireRate;

    private Rigidbody rb;
    private float nextFire;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(Shot1, ShotSpawn.position, ShotSpawn.rotation);
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Mouse X");
        float moveVertical = Input.GetAxis("Mouse Y");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        rb.velocity = movement * speed;

        if (transform.position.x <= -3.8f)
        {
            transform.position = new Vector2(-3.8f, transform.position.y);
        }
        else if (transform.position.x >= 3.8f)
        {
            transform.position = new Vector2(3.8f, transform.position.y);
        }

        if (transform.position.y <= -1.5f)
        {
            transform.position = new Vector2(transform.position.x, -1.5f);
        }
        else if (transform.position.y >= 6.0f)
        {
            transform.position = new Vector2(transform.position.x, 6.0f);
        }
    }
}
