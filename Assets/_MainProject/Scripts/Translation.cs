using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Translation : MonoBehaviour
{
    private const float positionZDepart = 1.016f;
    private const float positionZFin = 1.98f;

    //Attributs
    [SerializeField] private float _vitesseTranslationX = 0.5f;
    private Vector3 _positionInitiale = new Vector3(3.21499f, 0.36999f, positionZDepart);
    private Vector3 _positionFinale = new Vector3(3.21499f, 0.36999f, positionZFin);
    float phase = 0;
    float speed = 1;
    float phaseDirection = 1;
    private void Start()
    {
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(_positionInitiale, _positionFinale, phase); //phase determines (in percent, basically) where on the line between the points "back" and "forth" you want the enemy to be placed, so if we gradually increase/decrease the variable, it makes the enemy move between those two points.
        phase += Time.deltaTime * speed * phaseDirection; //subtracts from 1 to zero when phaseDirection is negative, adds from zero to one when phaseDirection is positive.
        if (phase >= 1 || phase <= 0) phaseDirection *= -1; //flip the sign to flip direction
        return;



        var vectorDirection = Vector3.forward;
        var moveForward = true;

        if (transform.position.z == positionZDepart)
        {
            moveForward = true;
            vectorDirection = Vector3.forward;
        }
        else if(transform.position.z == positionZFin)
        {
            moveForward = false;
            vectorDirection = Vector3.back;
        }


        if (moveForward) /*transform.position.z >= positionZDepart && transform.position.z < positionZFin)*/
        {
            transform.position = Vector3.MoveTowards(transform.position, _positionFinale, (positionZFin - positionZDepart));
            //transform.Translate(vectorDirection * _vitesseTranslationX * Time.deltaTime, );
            Vector3.Lerp(transform.position, _positionInitiale, (positionZFin - positionZDepart));
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _positionInitiale, (positionZFin - positionZDepart));
            //transform.Translate(vectorDirection * _vitesseTranslationX * Time.deltaTime);
        }
        //transform.Translate(vectorDirection * _vitesseTranslationX * Time.deltaTime);


        //if (transform.position.z >= positionZDepart && transform.position.z < positionZFin)
        //{
        //    transform.Translate(vectorDirection * _vitesseTranslationX * Time.deltaTime);
        //}
        //else if (transform.position.z <= positionZFin && transform.position.z > positionZDepart)
        //{
        //    transform.Translate(vectorDirection * _vitesseTranslationX * Time.deltaTime);
        //}

    }
}
