using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Attributs
    [SerializeField] private float _vitesse = 50;
    private Rigidbody rb;

    //Méthodes privées
    private void Start()
    {
        //transform.position = new Vector3(0.5f, 0.15f, 1f); 
        rb = GetComponent<Rigidbody>();
    }

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

        if(direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            targetRotation = Quaternion.RotateTowards(
                    transform.rotation,
                    targetRotation,
                    360 * Time.fixedDeltaTime);
            rb.MovePosition(rb.position + direction * _vitesse * Time.fixedDeltaTime);
            rb.MoveRotation(targetRotation);
        }
    }

    // Méthodes publiques

    public void GameEnd()
    {
        this.gameObject.SetActive(false);
    }
}
