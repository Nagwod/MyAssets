using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esmaga : MonoBehaviour
{
    Esmaga e; //Variavel do tipo do objeto que controla as paredes
    public GameObject esmaga; //Recebe o objeto que controla as paredes
    PEsmagad esm; //Variavel do tipo parede
    public GameObject esmagador; //Recebe a outra parede
    Tatu t;
    public Rigidbody player;
    private bool fechando;
    public AudioClip[] som; //Vetor de sons
    public AudioSource source;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.tag == "Player")
        {
            if (fechando)
            {
                StartCoroutine(Delay());
            }
        }
    }

    IEnumerator Delay()
    {
        if (!e.source.isPlaying) //Só mata se o som de morte não estiver tocando na outra parede
        {
            int index = Random.Range(0, som.Length); //Escolhe um som aleatório
            source.clip = som[index]; //Passa o som pro controle
            source.Play(); //Toca o som
            Physics.gravity = new Vector3(0, Physics.gravity.y, 0);
            Tatu.podeMover = false;
            yield return new WaitForSeconds(0.4f);
            player.velocity = new Vector3(0, 0, 0); //Para o tatu
            player.transform.position = t.checkpoint; //Manda o tatu pro checkpoint
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        esm = esmagador.GetComponent<PEsmagad>();
        e = esmaga.GetComponent<Esmaga>();
        t = player.GetComponent<Tatu>();
    }

    // Update is called once per frame
    void Update()
    {
        fechando = esm.fechando;
    }
}
