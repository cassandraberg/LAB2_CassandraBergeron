using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
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
                int error = _gameManager.GetPointage();
                Debug.Log("Le temps total est de : " + Time.time + " secondes");
                Debug.Log("Vous avez accroché : " + _gameManager.GetPointage() + " obstacles");

                float total = Time.time + error;
                Debug.Log("Temps final : " + total + " secondes");
                _player.GameEnd();
            }
        }
        else
        {
            SceneManager.LoadScene(indexScene + 1);
        }
    }
}
