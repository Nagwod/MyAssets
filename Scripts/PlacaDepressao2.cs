using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacaDepressao2 : MonoBehaviour
{
    [SerializeField] private GameObject ponte;
    [SerializeField] private bool fechado;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if (fechado)
            {
                ponte.transform.position = new Vector3(ponte.transform.position.x + 2, ponte.transform.position.y, ponte.transform.position.z);
                fechado = false;
            }
            else
            {
                ponte.transform.position = new Vector3(ponte.transform.position.x - 2, ponte.transform.position.y, ponte.transform.position.z);
                fechado = true;
            }
        }
    }

}
