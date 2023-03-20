using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    //Attributs
    private GameManager _gestionJeu;
    private bool _touch;

    //Méthodes privées
    private void Start()
    {
        _gestionJeu = FindObjectOfType<GameManager>();
        _touch = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!_touch)
            {
                _touch = true;
                gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
             
                _gestionJeu.AugmenterPointage();
            }
        }
    }
}
