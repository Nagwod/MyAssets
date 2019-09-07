using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public float velocidade, intervalo;
    public bool x, y, z; //Define o eixo de movimentação
    public float posicao1, posicao2;
    public Rigidbody player;
    public bool transportando; //Transportando o tatu
    private bool trigger;
    public int deteccao;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            transportando = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            transportando = false;
        }
    }

    IEnumerator Move()
    {
        if (trigger)
        {
            if (x)
            {
                while (transform.position.x < posicao2)
                {
                    transform.position = new Vector3(transform.position.x + 0.05f * velocidade, transform.position.y, transform.position.z); //Movimenta a plataforma
                    if (transportando)
                    {
                        player.transform.position = new Vector3(player.transform.position.x + 0.05f * velocidade, player.transform.position.y, player.transform.position.z); //Movimenta o tatu
                    }
                    yield return new WaitForFixedUpdate();
                }
                yield return new WaitForSeconds(intervalo);

                while (transform.position.x > posicao1)
                {
                    transform.position = new Vector3(transform.position.x - 0.05f * velocidade, transform.position.y, transform.position.z); //Movimenta a plataforma
                    if (transportando)
                    {
                        player.transform.position = new Vector3(player.transform.position.x - 0.05f * velocidade, player.transform.position.y, player.transform.position.z); //Movimenta o tatu
                    }
                    yield return new WaitForFixedUpdate();
                }
                yield return new WaitForSeconds(intervalo);
            }

            if (y)
            {
                while (transform.position.y < posicao2)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + 0.05f * velocidade, transform.position.z); //Movimenta a plataforma
                    if (transportando)
                    {
                        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.05f * velocidade, player.transform.position.z); //Movimenta o tatu
                    }
                    yield return new WaitForFixedUpdate();
                }
                yield return new WaitForSeconds(intervalo);

                while (transform.position.y > posicao1)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f * velocidade, transform.position.z); //Movimenta a plataforma
                    if (transportando)
                    {
                        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 0.05f * velocidade, player.transform.position.z); //Movimenta o tatu
                    }
                    yield return new WaitForFixedUpdate();
                }
                yield return new WaitForSeconds(intervalo);
            }

            if (z)
            {
                while (transform.position.z < posicao2)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.05f * velocidade); //Movimenta a plataforma
                    if (transportando)
                    {
                        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + 0.05f * velocidade); //Movimenta o tatu
                    }
                    yield return new WaitForFixedUpdate();
                }
                yield return new WaitForSeconds(intervalo);

                while (transform.position.z > posicao1)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.05f * velocidade); //Movimenta a plataforma
                    if (transportando)
                    {
                        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 0.05f * velocidade); //Movimenta o tatu
                    }
                    yield return new WaitForFixedUpdate();
                }
                yield return new WaitForSeconds(intervalo);
            }
        }
        yield return new WaitForFixedUpdate();
        StartCoroutine(Move());
    }

    // Start is called before the first frame update
    void Start()
    {
        transportando = false;
        StartCoroutine(Move());
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
