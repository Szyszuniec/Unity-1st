﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour {

    public float speed = 7f;

	void Update () {
        transform.Translate(Vector3.back * speed * Time.deltaTime, Space.Self);
        if (transform.position.z < -10)
        {
            Destroy(gameObject);
        }

	}
}
