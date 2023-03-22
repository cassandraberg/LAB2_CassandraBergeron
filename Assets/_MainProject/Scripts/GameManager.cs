using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Attributs
    private int _accrochages;
    private int _accrochageLv1;
    private float _timeLv1;
    private float _timeLv2;
    private int _accrochageLv2;
    private float _timeLv3;
    private int _accrochageLv3;

    // Méthodes privées
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
        _accrochages = 0;
        InstructionsDepart();
    }

    private static void InstructionsDepart()
    {
        Debug.Log("*** Course à obstacles");
        Debug.Log("Le but du jeu est d'atteindre la zone d'arrivée le plus rapidement possible");
        Debug.Log("Chaque contact avec un obstable entraînera une pénalité");
        Debug.Log("");
    }

    // Méthodes publiques 
    public void AugmenterAccrochage()
    {
        _accrochages++;
    }

    public int GetAccrochage()
    {
        return _accrochages;
    }

    public float GetTempsLv1()
    {
        return _timeLv1;
    }

    public int GetAccrochagesLv1()
    {
        return _accrochageLv1;
    }

    //Méthode qui reçoit les valeurs pour le niveau 2 et qui modifie les attributs respectifs
    public void SetLv1(int accrochages, float tempsNiv1)
    {
        _accrochages = 0;
        _accrochageLv1 = accrochages;
        _timeLv1 = tempsNiv1;
    }

    public float GetTempsLv2()
    {
        return _timeLv2;
    }

    public int GetAccrochagesLv2()
    {
        return _accrochageLv2;
    }

    public void SetLv2(int accrochages, float tempsNiv2)
    {
        _accrochages = 0;
        _accrochageLv2 = accrochages;
        _timeLv2 = tempsNiv2 - _timeLv1;
    }

    public float GetTempsLv3()
    {
        return _timeLv3;
    }

    public int GetAccrochagesLv3()
    {
        return _accrochageLv3;
    }

    public void SetLv3(int accrochages, float tempsNiv3)
    {
        _accrochages = 0;
        _accrochageLv3 = accrochages;
        _timeLv3 = tempsNiv3 - _timeLv1 - _timeLv2;
    }
}
