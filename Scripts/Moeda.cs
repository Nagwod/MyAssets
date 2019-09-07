using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moeda : MonoBehaviour
{
    Tatu t; //Variável do tipo tatu
    public GameObject tatu; //Recebe o tatu
    public int valor; //Valor da moeda
    //public bool trigger;
    //public int deteccao;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            t.SomMoeda(); //Toca o som da moeda no tatu
            Destroy(this.gameObject); //Deleta a moeda
            ConfigGeral.moedas += valor; //Aumenta a quantidade de moedas
        }
    }
    
    //IEnumerator Gira()
    //{
    //    if (trigger)
    //    {
    //        transform.Rotate(0, 0, 5);
    //    }
    //    yield return new WaitForSeconds(0.05f);
    //    StartCoroutine(Gira());
    //}
    
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Gira());
        t = tatu.GetComponent<Tatu>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (Vector3.Distance(transform.position, tatu.transform.position) < deteccao) //Controle de distância do tatu
        //{
        //    trigger = true;
        //}
        //else
        //{
        //    trigger = false;
        //}
    }
}
