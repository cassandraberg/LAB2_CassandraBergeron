using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TrapZone : MonoBehaviour
{
    //zone détection changer grandeur dans box collider seulement

    private bool _estActif = false;
    [SerializeField] private List<GameObject> _listePieges = new List<GameObject>();
    private List<Rigidbody> _listRb = new List<Rigidbody>();
    [SerializeField] private float _intensiteForce = 300;

    public void Start()
    {
        foreach(var piege in _listePieges)
        {
            _listRb.Add(piege.GetComponent<Rigidbody>());   
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !_estActif)
        {
            foreach(var rb in _listRb)
            {
                rb.useGravity = true;
    
                rb.AddForce(Vector3.down * _intensiteForce);
            }
            _estActif = true;
        }
    }
}
