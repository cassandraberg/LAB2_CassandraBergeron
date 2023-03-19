using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Attributs
    private int _pointage;

    // M�thodes priv�es
    private void Awake()
    {
        int nbGestionJeu = FindObjectsOfType<GameManager>().Length;

        if (nbGestionJeu > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        _pointage = 0;
    }

    private static void InstructionsDepart()
    {
        Debug.Log("*** Course � obstacles");
        Debug.Log("Le but du jeu est d'atteindre la zone d'arriv�e le plus rapidement possible");
        Debug.Log("Chaque contact avec un obstable entra�nera une p�nalit�");
        Debug.Log("");
    }

    // M�thodes publiques 
    public void AugmenterPointage()
    {
        _pointage++;
    }

    // Accesseur qui retourne la valeur de l'attribut pointage
    public int GetPointage()
    {
        return _pointage;
    }
}
