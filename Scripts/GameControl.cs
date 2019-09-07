using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[Serializable]
class Admin
{
    public string nome;
    public string senha;
    public List<string> saves = new List<string>();
}

[Serializable]
class Save
{
    public string nome;
    public string idade;
    public int fasesCompletas;
    public int[] moedas = new int[18];
    public int[] tempos = new int[18];
    public int[] mortes = new int[18];
    public int[] pontos = new int[18];
}

public class GameControl : MonoBehaviour
{
    public static GameControl gameControl;
    public string filePath, fileAdm;
    //private List<string> filePath = new List<string>();
    private string nomeAdmin, senhaAdmin;
    private List<string> saves = new List<string>();
    private string nomeJogador;
    private string idadeJogador;
    private int fasesCompletas;
    private int[] moedas = new int[18];
    private int[] tempos = new int[18];
    private int[] mortes = new int[18];
    private int[] pontos = new int[18];

    //Jogadores

    public bool ChecaSave()
    {
        if (!File.Exists(filePath + nomeJogador + ".dat"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public void CriarSave()
    {
        if (!File.Exists(filePath + nomeJogador + ".dat"))
        {
            BinaryFormatter bf = new BinaryFormatter(); //Variável para converter um arquivo para binário
            FileStream file = File.Create(filePath + nomeJogador + ".dat"); //Cria um novo arquivo
            Save save = new Save  //Instancia um novo "save"
            {
                nome = nomeJogador,
                idade = idadeJogador,
                fasesCompletas = fasesCompletas,
                moedas = moedas,
                tempos = tempos,
                mortes = mortes,
                pontos = pontos
            };
            bf.Serialize(file, save); //Guarda os valores de "save" no arquivo
            file.Close();
            CarregarAdmin();
            saves.Add(filePath + nomeJogador + ".dat");
            AlterarSaves();
        }
    }

    public void Salvar()
    {
        if (File.Exists(filePath + nomeJogador + ".dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(filePath + nomeJogador + ".dat", FileMode.Open);
            Save save = new Save
            {
                nome = nomeJogador,
                idade = idadeJogador,
                fasesCompletas = fasesCompletas,
                moedas = moedas,
                tempos = tempos,
                mortes = mortes,
                pontos = pontos
            };
            bf.Serialize(file, save); //Guarda os valores de "save" no arquivo
            file.Close();
        }
        else
        {

        }
    }

    public void Carregar()
    {
        if (File.Exists(filePath + nomeJogador + ".dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(filePath + nomeJogador + ".dat", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();
            nomeJogador = save.nome;
            idadeJogador = save.idade;
            fasesCompletas = save.fasesCompletas;
            moedas = save.moedas;
            tempos = save.tempos;
            mortes = save.mortes;
            pontos = save.pontos;
        }
        else
        {

        }
    }

    public void Apagar()
    {
        File.Delete(filePath + nomeJogador + ".dat");
        saves.Remove(filePath + nomeJogador + ".dat");
        AlterarSaves();
    }

    //Admin
    public bool VerificaAdmin()
    {
        if (File.Exists(fileAdm))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(fileAdm, FileMode.Open);
            Admin adm = (Admin)bf.Deserialize(file);
            file.Close();
            string n = adm.nome;
            string s = adm.senha;
            if (n == "" || s == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            return false;
        }
    }

    public void CriarAdmin()
    {
        if (!File.Exists(fileAdm))
        {
            BinaryFormatter bf = new BinaryFormatter(); //Variável para converter um arquivo para binário
            FileStream file = File.Create(fileAdm); //Cria um novo arquivo
            Admin adm = new Admin //Instancia um novo "Admin"
            {
                nome = nomeAdmin,
                senha = senhaAdmin,
                saves = saves
            };
            bf.Serialize(file, adm); //Guarda os valores de "adm" no arquivo
            file.Close();
        }
        else
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(fileAdm, FileMode.Open);
            Admin adm = (Admin)bf.Deserialize(file);
            file.Close();
            string n = adm.nome;
            string s = adm.senha;
            if (n == "" || s == "")
            {
                File.Delete(fileAdm);
                CriarAdmin();
            }
            else
            {
                //Não pode
            }
        }
    }

    public void AlterarAdmin()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(fileAdm, FileMode.Open); //Abre o arquivo
        Admin adm = new Admin
        {
            nome = nomeAdmin,
            senha = senhaAdmin,
            saves = saves
        };
        bf.Serialize(file, adm);
        file.Close();
    }

    public void AlterarSaves()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(fileAdm, FileMode.Open);
        Admin adm = new Admin
        {
            nome = nomeAdmin,
            senha = senhaAdmin,
            saves = saves
        };
        bf.Serialize(file, adm);
        file.Close();
    }

    public void CarregarAdmin()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(fileAdm, FileMode.Open);
        Admin adm = (Admin)bf.Deserialize(file);
        file.Close();
        nomeAdmin = adm.nome;
        senhaAdmin = adm.senha;
        saves = adm.saves;
    }

    public bool Autenticar()
    {
        if (File.Exists(fileAdm))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(fileAdm, FileMode.Open);
            Admin adm = (Admin)bf.Deserialize(file);
            file.Close();
            if (nomeAdmin.Equals(adm.nome) && senhaAdmin.Equals(adm.senha))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    //Get's e Set's
    public string GetSaves(string nome)
    {
        return filePath + nome + ".dat";
    }

    public int GetMoedas(int index)
    {
        return moedas[index];
    }
    public void SetMoedas(int index, int valor)
    {
        moedas[index] = valor;
    }
    public int GetTempos(int index)
    {
        return tempos[index];
    }
    public void SetTempos(int index, int valor)
    {
        tempos[index] = valor;
    }
    public int GetMortes(int index)
    {
        return mortes[index];
    }
    public void SetMortes(int index, int valor)
    {
        mortes[index] = valor;
    }
    public int GetPontos(int index)
    {
        return pontos[index];
    }
    public void SetPontos(int index, int valor)
    {
        pontos[index] = valor;
    }

    public int GetFasesCompletas()
    {
        return fasesCompletas;
    }
    public void SetFasesCompletas(int fases)
    {
        fasesCompletas = fases;
    }

    public string GetNomeJogador()
    {
        return nomeJogador;
    }
    public void SetNomeJogador(string nome)
    {
        nomeJogador  = nome;
    }
    public string GetIdadeJogaor()
    {
        return idadeJogador;
    }
    public void SetIdadeJogador(string idade)
    {
        idadeJogador = idade;
    }

    public string GetNomeAdmin()
    {
        return nomeAdmin;
    }
    public void SetNomeAdmin(string nome)
    {
        nomeAdmin = nome;
    }
    public string GetSenhaAdmin()
    {
        return senhaAdmin;
    }
    public void SetSenhaAdmin(string senha)
    {
        senhaAdmin = senha;
    }

    private void Awake()
    {
        filePath = Application.persistentDataPath + "/Save";
        fileAdm = Application.persistentDataPath + "/Admin.dat";
        Screen.sleepTimeout = SleepTimeout.NeverSleep; //Nunca apagar a tela

        if (gameControl == null) //Se tiver mais de um, destrói o outro
        {
            gameControl = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject); //Não destruir quando carregar outra cena
    }
}
