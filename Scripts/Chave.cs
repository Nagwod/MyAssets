using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chave : MonoBehaviour
{
    Tatu t; //Variável do tipo tatu
    public GameObject tatu; //Recebe o tatu
    public GameObject portao;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            t.SomMoeda();
            Destroy(portao); //Deleta o portão
            Destroy(gameObject); //Deleta a chave
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        t = tatu.GetComponent<Tatu>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
