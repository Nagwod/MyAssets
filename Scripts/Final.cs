using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final : MonoBehaviour
{
    GameControl gameControl;
    public int fase;
    public int moedas;
    public int tempo;
    private AudioSource source;
    public GameObject TelaFinal, TelaPrincipal;
    public float pontosm, pontost, pontos;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            StartCoroutine(Delay());
        }
    }

    private void CalculaPontos()
    {
        pontosm = ConfigGeral.moedas * 1000 / moedas; //Calcula um valor entre 0 e 1000 para cada qauntidade de moedas ente a quantidade minima e maxima
        if (ConfigGeral.tempo < tempo)
        {
            pontost = 1000; //Se for maior que o tempo mínimo, a pontuação é 1000
        }
        else
        {
            if (ConfigGeral.tempo < tempo * 3)
            {
                pontost = ((((tempo * 2) - (ConfigGeral.tempo - tempo)) / tempo * 2) * 1000) / 4; //Calcula um valor de 0 a 1000 para cada valor entre o tempo mínimo e máximo
            }
            else
            {
                pontost = 0; //Se for maior que o tempo máximo (triplo do tempo mínimo), a pontuação é 0
            }
        }
        pontos = (pontosm + pontost) / 2; //A pontuação é a média entre os pontos de moedas e tempo
        //gameControl.SetPontos(fase, (int)pontos, (int)System.Math.Floor(ConfigGeral.tempo), ConfigGeral.moedas);
    }

    IEnumerator Delay()
    {
        source.Play(0);
        TelaFinal.SetActive(true);
        TelaPrincipal.SetActive(false);
        CalculaPontos();
        //gameControl.SetFasesCompletas(fase);
        //gameControl.Save();
        Time.timeScale = 0;
        yield return new WaitForSeconds(0.2f);
    }

    // Start is called before the first frame update
    void Start()
    {
        gameControl = GameControl.gameControl;
        source = GetComponent<AudioSource>();
    }
}
