using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour
{
    // Attributs
    private GameManager _gameManager;
    private Player _player;

    // Méthodes privées

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _player = FindObjectOfType<Player>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        int indexScene = SceneManager.GetActiveScene().buildIndex;

        if(indexScene == 2)
        {
            if (collision.gameObject.tag == "Player")
            {
                //gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
                _player.GameEnd();
            }
        }
        else
        {
            SceneManager.LoadScene(indexScene + 1);
        }
    }
}
