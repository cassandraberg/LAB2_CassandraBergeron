using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndManager : MonoBehaviour
{
    // Attributs
    private GameManager _gameManager;
    private Player _player;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _player = FindObjectOfType<Player>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
            _player.GameEnd();
        }

    }


}
