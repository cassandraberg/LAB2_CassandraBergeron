using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    //Attributs
    [SerializeField] private float _vitesseRotationY = 0.5f;
    private void Start()
    {
        
    }

    private void Update()
    {
        transform.Rotate(0f, _vitesseRotationY, 0f);
    }
}
