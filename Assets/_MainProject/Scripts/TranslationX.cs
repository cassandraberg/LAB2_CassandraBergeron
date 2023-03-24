using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationX : MonoBehaviour
{    //Attributs
    [SerializeField] private float _positionXDepart = 1.016f;
    [SerializeField] private float _positionXFin = 1.98f;
    [SerializeField] private float _positionY = 3.21499f;
    [SerializeField] private float _positionZ = 0.36999f;
    [SerializeField] private float _speed = 1;
    private float _positionBetweenPoints = 0;

    private float _direction = 1;

    //méthodes privées
    private void FixedUpdate()
    {
        Vector3 _positionInitiale = new Vector3(_positionXDepart, _positionY, _positionZ);
        Vector3 _positionFinale = new Vector3(_positionXFin, _positionY, _positionZ);

        transform.position = Vector3.Lerp(_positionInitiale, _positionFinale, _positionBetweenPoints);
        _positionBetweenPoints += Time.deltaTime * _speed * _direction;
        if (_positionBetweenPoints >= 1 || _positionBetweenPoints <= 0)
            _direction *= -1;
        return;
    }
}
 