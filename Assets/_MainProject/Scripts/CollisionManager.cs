using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    //Attributs
    private GameManager _gestionJeu;
    private bool _touch;

    private void Start()
    {
        _gestionJeu = FindObjectOfType<GameManager>();
        _touch = false;
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!_touch)
            {
                _touch = true;
                Debug.Log("Touché");
                gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                //gameObject.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1); mettre couleur en rgb
                //_gestionJeu.AugmenterPointage();
            }
        }
    }
}
