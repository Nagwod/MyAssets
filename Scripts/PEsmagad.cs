using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PEsmagad : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private int deteccao;
    [SerializeField] private GameObject parede1, parede2;
    [SerializeField] private float distancia; //metade da distância entre as duas paredes
    [SerializeField] private float intervalo1, intervalo2; //Intervalo1: tempo de intervalo aberto. Intervalo2: tempo de intervalo fechado
    [SerializeField] private bool x, y, z; //Direção que as paredes se fecham
    [SerializeField] private bool trigger;
    public bool fechando; //está fechando ou abrindo
    private float posinic, posfin; //pega a posição onde a prede deve iniciar o movimento de fechar e finalizar o movimento de abrir
    private int a; //coresponde ao eixo em que a parede vai se movimentar
    private AudioSource source;

    IEnumerator Fecha()
    {
        if (trigger)
        {
            yield return new WaitForSeconds(intervalo1);
            fechando = true;
            while (parede1.transform.position[a] * -1 < -posfin) //Fecha
            {
                switch (a)
                {
                    case 0: //x
                        parede1.transform.position = new Vector3(parede1.transform.position[0] - 0.1f, parede1.transform.position[1], parede1.transform.position[2]);
                        parede2.transform.position = new Vector3(parede2.transform.position[0] + 0.1f, parede2.transform.position[1], parede2.transform.position[2]);
                        break;
                    case 1: //y
                        parede1.transform.position = new Vector3(parede1.transform.position[0], parede1.transform.position[1] - 0.1f, parede1.transform.position[2]);
                        parede2.transform.position = new Vector3(parede2.transform.position[0], parede2.transform.position[1] + 0.1f, parede2.transform.position[2]);
                        break;
                    case 2: //z
                        parede1.transform.position = new Vector3(parede1.transform.position[0], parede1.transform.position[1], parede1.transform.position[2] - 0.1f);
                        parede2.transform.position = new Vector3(parede2.transform.position[0], parede2.transform.position[1], parede2.transform.position[2] + 0.1f);
                        break;
                }
                yield return new WaitForFixedUpdate();
            }
            source.Play(0); //Som da batida
            fechando = false;
            yield return new WaitForSeconds(intervalo2);
            while (parede1.transform.position[a] * -1 > -posinic) //Abre
            {
                switch (a)
                {
                    case 0: //x
                        parede1.transform.position = new Vector3(parede1.transform.position[0] + 0.1f, parede1.transform.position[1], parede1.transform.position[2]);
                        parede2.transform.position = new Vector3(parede2.transform.position[0] - 0.1f, parede2.transform.position[1], parede2.transform.position[2]);
                        break;
                    case 1: //xy
                        parede1.transform.position = new Vector3(parede1.transform.position[0], parede1.transform.position[1] + 0.1f, parede1.transform.position[2]);
                        parede2.transform.position = new Vector3(parede2.transform.position[0], parede2.transform.position[1] - 0.1f, parede2.transform.position[2]);
                        break;
                    case 2: //z
                        parede1.transform.position = new Vector3(parede1.transform.position[0], parede1.transform.position[1], parede1.transform.position[2] + 0.1f);
                        parede2.transform.position = new Vector3(parede2.transform.position[0], parede2.transform.position[1], parede2.transform.position[2] - 0.1f);
                        break;
                }
                yield return new WaitForSeconds(0.05f);
            }
        }
        yield return new WaitForEndOfFrame();
        StartCoroutine(Fecha());
    }

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        fechando = false;
        //cont = 0;

        if (x)
        {
            a = 0;
        }
        if (y)
        {
            a = 1;
        }
        if (z)
        {
            a = 2;
        }

        posinic = parede1.transform.position[a]; //Define a posição inicial
        posfin = posinic - distancia; //Define a posição final
        StartCoroutine(Fecha());
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < deteccao) //Controle de distância do tatu
        {
            trigger = true;
        }
        else
        {
            trigger = false;
        }
    }
}
