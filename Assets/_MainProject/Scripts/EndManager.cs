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
    private bool _endGame;


    // Méthodes privées

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _player = FindObjectOfType<Player>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" && !_endGame)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.green;  
            

            int noScene = SceneManager.GetActiveScene().buildIndex;

            if (noScene == (SceneManager.sceneCountInBuildSettings - 1)) 
            {
                _endGame = true;
                int accrochages = _gameManager.GetPointage(); 
                float tempsTotalniv1 = _gameManager.GetTempsLv1() + _gameManager.GetAccrochagesLv1(); 
                
                float _tempsNiveau2 = Time.time - _gameManager.GetTempsLv1();
                int _accrochagesNiveau2 = _gameManager.GetPointage() - _gameManager.GetAccrochagesLv1(); 
                float tempsTotalniv2 = _tempsNiveau2 + _accrochagesNiveau2;

                float _tempsNiveau3 = Time.time - (_gameManager.GetTempsLv1() + _gameManager.GetTempsLv2());
                int _accrochagesNiveau3 = _gameManager.GetPointage() - _gameManager.GetAccrochagesLv3();
                float tempsTotalniv3 = _tempsNiveau3 + _accrochagesNiveau3; 

                // Affichage des résultats finaux niveau 1
                Debug.Log("Fin de partie");
                Debug.Log("Le temps pour le niveau 1 est de : " + _gameManager.GetTempsLv1().ToString("f2") + " secondes");
                Debug.Log("Vous avez accroché au niveau 1 : " + _gameManager.GetAccrochagesLv1() + " obstacles");
                Debug.Log("Temps total niveau 1 : " + tempsTotalniv1.ToString("f2") + " secondes");

                // niveau 2
                Debug.Log("Le temps pour le niveau 2 est de : " + _tempsNiveau2.ToString("f2") + " secondes");
                Debug.Log("Vous avez accroché au niveau 2 : " + _accrochagesNiveau2 + " obstacles");
                Debug.Log("Temps total niveau 2 : " + tempsTotalniv2.ToString("f2") + " secondes");

                // niveau 3
                Debug.Log("Le temps pour le niveau 3 est de : " + _tempsNiveau3.ToString("f2") + " secondes");
                Debug.Log("Vous avez accroché au niveau 3 : " + _accrochagesNiveau3 + " obstacles");
                Debug.Log("Temps total niveau 3 : " + tempsTotalniv3.ToString("f2") + " secondes");

                //total
                Debug.Log("Le temps total pour les trois niveaux est de : " + (tempsTotalniv1 + tempsTotalniv2 + tempsTotalniv3).ToString("f2") + " secondes");

                _player.GameEnd();  // Appeler la méthode publique dans Player pour désactiver le joueur
            }
            else
            {
                // Appelle la méthode publique dans gestion jeu pour conserver les informations du niveau 1-2-3
                if(noScene == 0)
                    _gameManager.SetLv1(_gameManager.GetPointage(), Time.time);
                else if(noScene == 1)
                    _gameManager.SetLv2(_gameManager.GetPointage(), Time.time);
                else if(noScene == 2)
                    _gameManager.SetLv3(_gameManager.GetPointage(), Time.time);
                // Charge la scène suivante
                SceneManager.LoadScene(noScene + 1);
            }
        }
    }
}
