using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moeda : MonoBehaviour
{
    Tatu t; //Variável do tipo tatu
    [SerializeField] private GameObject tatu; //Recebe o tatu
    [SerializeField] private int valor; //Valor da moeda

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            t.SomMoeda(); //Toca o som da moeda no tatu
            Destroy(gameObject); //Deleta a moeda
            ConfigGeral.moedas += valor; //Aumenta a quantidade de moedas
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Gira());
        t = tatu.GetComponent<Tatu>();
    }
}
