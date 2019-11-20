using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esmaga : MonoBehaviour
{
    Esmaga e; //Variavel do tipo do objeto que controla as paredes
    [SerializeField] private GameObject esmaga; //Recebe o objeto que controla as paredes
    PEsmagad esm; //Variavel do tipo parede
    [SerializeField] private GameObject esmagador; //Recebe a outra parede
    Tatu t;
    [SerializeField] private Rigidbody player;
    [SerializeField] private AudioSource source;
    [SerializeField] private TrailRenderer trail;
    private bool fechando;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player") && fechando)
        {
            source.Play(); //Toca o som
            if (Tatu.vivo)
            {
                StartCoroutine(Delay());
            }
        }
    }

    IEnumerator Delay()
    {
        Physics.gravity = new Vector3(0, Physics.gravity.y, 0);
        trail.emitting = false;
        Tatu.podeMover = false;
        Tatu.vivo = false;
        player.transform.localScale = new Vector3(1, 1, 0.01f);
        yield return new WaitForSeconds(0.8f);
        player.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        player.velocity = new Vector3(0, 0, 0); //Para o tatu
        player.transform.position = t.checkpoint; //Manda o tatu pro checkpoint
        Tatu.vivo = true;
        ConfigGeral.mortesParedes++;
        ConfigGeral.mortes++;
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
