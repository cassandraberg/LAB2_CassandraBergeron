using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Attributs
    [SerializeField] private float _vitesse = 100; 
    public float _jumpForce = 10f;
    private Rigidbody rb;

    // Start is called before the first frame update
    private void Start()
    {
        transform.position = new Vector3(5f, 0f, 1f); // mettre en float
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float positionX = Input.GetAxis("Horizontal");
        float positionZ = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(positionX, 0f, positionZ);
        rb.velocity = direction * Time.fixedDeltaTime * _vitesse;
    }
}
