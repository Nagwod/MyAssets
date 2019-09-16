using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigGeral : MonoBehaviour
{
    public Text tmoedas, ttempo; //Campos de texto que aparecem na tela durante a fase
    static public int moedas; //Dados a serem coletados durantre o jogo
    static public float tempo; //Dados a serem coletados durantre o jogo
    public int fase; //Para setar a fase através da interface do unity
    static public int faseAtual; //Fase que está sendo jogada
    static public int mortes, mortesBuraco, mortesEspinho, mortesParedes, mortesQueda, batidasParedes, batidasArvores; //Dados a serem coletados durantre o jogo
    //, pontos;

    // Start is called before the first frame update
    void Start()
    {
        tempo = 0;
        moedas = 0; //É alterada pelo script de Moeda
        mortes = 0;
        mortesBuraco = 0; //É alterada pelo script Cai
        mortesEspinho = 0;  //É alterada pelo script Espinho
        mortesParedes = 0;  //É alterada pelo script Esmaga
        mortesQueda = 0; //É alterada pelo script Cai
        batidasParedes = 0; //É alterada pelo script do Tatu
        batidasArvores = 0; //É alterada pelo script do Tatu
        //pontos = 0;
        faseAtual = fase; //Recebe a fase
    }

    // Update is called once per frame
    void Update()
    {
        tempo += Time.deltaTime; //Aumenta o tempo
        ttempo.text = "Tempo: " + (System.Math.Floor(tempo)); //Tempo arredondado é passado pro campo de texto
        tmoedas.text = "Moedas: "+moedas; //Quantidade de moedas é passada para o campo de texto
        //tmortes.text = "Total:" + mortes + " Buracos:" + mortesBuraco + " Espinhos:" + mortesEspinho + " Esmagado:" + mortesParedes + " Quedas:" + mortesQueda + " Batidas Arvore:" + batidasArvores + " Paredes:" + batidasParedes;
    }
}
