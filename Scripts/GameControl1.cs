using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[Serializable]
class Save1
{
    public int fasesCompletas;
    public int[] moedas = new int[3];
    public int[] tempos = new int[3];
    public int[] pontos = new int[3];
}

public class GameControl1 : MonoBehaviour
{
    public static GameControl1 gameControl1;
    public string filePath1, filePath2, filePath3;
    public int save;
    public int fasesCompletas;
    public int[] moedas = new int[3];
    public int[] tempos = new int[3];
    public int[] pontos = new int[3];

    private void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep; //Nunca apagar a tela

        if (gameControl1 == null) //Se tiver mais de um, destrói o outro
        {
            gameControl1 = this;
        }else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject); //Não destruir quando carregar outra cena

        filePath1 = Application.persistentDataPath + "/Estagio2save1.dat"; //Caminhos dos arquivos de save
        filePath2 = Application.persistentDataPath + "/Estagio2save2.dat";
        filePath3 = Application.persistentDataPath + "/Estagio2save3.dat";
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter(); //Variável para converter um arquivo para binário
        FileStream file = File.Create(GetFilePath(gameControl1.save)); //Cria um novo arquivo
        Save save = new Save(); //Instancia um novo "save"
        save.fasesCompletas = fasesCompletas; //Seta o valor de "fasesCompletas" de "save"
        save.moedas = moedas;
        save.tempos = tempos;
        save.pontos = pontos;
        bf.Serialize(file, save); //Guarda os valores de "save" no arquivo
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(GetFilePath(gameControl1.save)))
        {
            BinaryFormatter bf = new BinaryFormatter(); //Variável para criar um arquivo binário
            FileStream file = File.Open(GetFilePath(gameControl1.save), FileMode.Open); //Abre o arquivo
            Save save = (Save)bf.Deserialize(file); //Retorna os valores guardados no arquivo para "save"
            file.Close();
            fasesCompletas = save.fasesCompletas; //Retorna o valor de "fasesCompletas" de "save"
            moedas = save.moedas;
            tempos = save.tempos;
            pontos = save.pontos;
        }
        else
        {
            Apagar();
        }
    }

    public void Apagar()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(GetFilePath(gameControl1.save));
        Save save = new Save();
        fasesCompletas = 0;
        save.fasesCompletas = fasesCompletas;
        save.moedas = moedas;
        save.tempos = tempos;
        save.pontos = pontos;
        bf.Serialize(file, save);
        file.Close();
    }

    public void SetSave(int save)
    {
        gameControl1.save = save;
    }

    private string GetFilePath(int file)
    {
        switch (file)
        {
            case 1:
                return filePath1;
            case 2:
                return filePath2;
            case 3:
                return filePath3;
        }
        return "";
    }

    public string FileToString(int value)
    {
        if (!File.Exists(GetFilePath(value)))
        {
            return "Criar save "+ value;
        }
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(GetFilePath(value), FileMode.Open);
        Save save = (Save)bf.Deserialize(file);
        file.Close();
        return "Save "+value+":\n" +
            "Fase: "+(save.fasesCompletas+1);
    }

    public void SetFasesCompletas(int value)
    {
        if (value>fasesCompletas)
        {
            fasesCompletas = value;
        }
    }

    public int GetFasesCompletas()
    {
        return fasesCompletas;
    }

    public void SetPontos(int index, int pontos, int tempo, int moedas)
    {
        if (pontos >= this.pontos[index - 1])
        {
            this.pontos[index - 1] = pontos;
            this.moedas[index - 1] = moedas;
            tempos[index - 1] = tempo;
        }
    }

    public int GetPontos(int index)
    {
        return pontos[index];
    }

    public int GetMoedas(int index)
    {
        return moedas[index];
    }

    public int GetTempo(int index)
    {
        return tempos[index];
    }

    public string PontuacaoToString(int fase)
    {
        return "Pontuação fase "+fase+":";
    }

    public string PontosToString(int fase)
    {
        return "Moedas: "+moedas[fase-1]+"\n" +
            "Tempo: "+tempos[fase-1]+"\n" +
            "Pontos: "+pontos[fase-1];
    }
}
