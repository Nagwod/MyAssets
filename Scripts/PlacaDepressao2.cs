using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacaDepressao2 : MonoBehaviour
{
    public GameObject ponte;
    public bool fechado;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
