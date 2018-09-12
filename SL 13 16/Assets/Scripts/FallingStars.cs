using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingStars : MonoBehaviour
{

    float speed;
    public Vector2 speedMinMax;

    void Update()
    {
        speed = Random.Range(speedMinMax.x, speedMinMax.y);
        transform.Translate(Vector3.back * speed * Time.deltaTime, Space.Self);
        if (transform.position.z < -10)
        {
            Destroy(gameObject);
        }

    }
}
