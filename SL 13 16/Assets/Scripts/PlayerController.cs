﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 7f;
    float screenHalfWidthUnits;


    // Use this for initialization
    void Start()
    {
        float halfPlayerWidth = transform.localScale.x / 2f;
        screenHalfWidthUnits = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;
    }

    // Update is called once per frame
    void Update()
    {

        float inputX = Input.GetAxisRaw("Horizontal");
        float velocity = inputX * speed;
        transform.Translate(Vector2.right * velocity * Time.deltaTime);

        if (transform.position.x < -screenHalfWidthUnits)
        {
            transform.position = new Vector2(screenHalfWidthUnits, transform.position.y);
        }
        if (transform.position.x > screenHalfWidthUnits)
        {
            transform.position = new Vector2(-screenHalfWidthUnits, transform.position.y);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Falling Block")
        {
            Destroy(gameObject);
        }
    }
}