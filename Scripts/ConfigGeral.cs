using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigGeral : MonoBehaviour
{
    public Text tmoedas, ttempo;
    static public int moedas;
    static public float tempo;
    static public int mortes, mburacos, mespinhos, mparedes, mqueda, batidasParedes, batidasArvores;

    // Start is called before the first frame update
    void Start()
    {
        tempo = 0;
        moedas = 0; //É alterada pelo script de Moeda
    }

    // Update is called once per frame
    void Update()
    {
        tempo += Time.deltaTime; //Aumenta o tempo
        ttempo.text = "Tempo: " + (System.Math.Floor(tempo)); //Tempo arredondado é passado pro campo de texto
        tmoedas.text = "Moedas: "+moedas; //Quantidade de moedas é passada para o campo de texto
    }
}
