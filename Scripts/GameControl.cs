using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Proyecto26;

[Serializable]
class Admin //Modelo para Salvar o admin
{
    public string nome;
    public string senha;
    public string email;
    public List<string> saves = new List<string>();
}

[Serializable]
class Save //Modelo para salvar o jogador
{
    public string nome;
    public string idade;
    public int[] faseCompleta = new int[4];
    public int[] moedas = new int[4];
    public int[] tempos = new int[4];
    public float[] velocMedias = new float[4];
    public int[] mortes = new int[4];
    public int[] mortesBuraco = new int[4];
    public int[] mortesEspinho = new int[4];
    public int[] mortesParedes = new int[4];
    public int[] mortesQueda = new int[4];
    public int[] batidasParede = new int[4];
    public int[] batidasArvore = new int[4];
    //public int[] pontos = new int[4];
}

public class GameControl : MonoBehaviour
{
    //Save cloudSave = new Save(); // variável de controle para o save
    public int volume, qualidade;
    public bool logado;
    public static GameControl gameControl;
    public string filePath, fileAdm; //Caminhos dos arquivos
    //private List<string> filePath = new List<string>();
    public string nomeAdmin, senhaAdmin, emailAdmin;
    public List<string> saves = new List<string>(); //Lista para controlar os saves
    public string nomeJogador, idadeJogador;
    public int[] faseCompleta = new int[4]; //0: não jogada, 1: incompleta, 2:completa
    public int[] moedas = new int[4];
    public int[] tempo = new int[4];
    public float[] velocMedia = new float[4];
    public int[] mortes = new int[4];
    public int[] mortesEspinho = new int[4];
    public int[] mortesParede = new int[4];
    public int[] mortesBuraco = new int[4];
    public int[] mortesQueda = new int[4];
    public int[] batidasParede = new int[4];
    public int[] batidasArvore = new int[4];
    public float[] mediaMoedas = new float[4];
    public float[] mediaTempos = new float[4];
    public float[] mediaVeloc = new float[4];
    public float[] mediaMortes = new float[4];
    public float[] mediaMorteBuraco = new float[4];
    public float[] mediaMorteEspinho = new float[4];
    public float[] mediaMorteParede = new float[4];
    public float[] mediaMorteQueda = new float[4];
    public float[] mediaBatidaParede = new float[4];
    public float[] mediaBatidaArvore = new float[4];
    //public int[] pontos = new int[4];

    public void SendSaveToDatabase()
    {
        Save pSave = new Save
        {
            nome = nomeJogador,
            idade = idadeJogador,
            faseCompleta = faseCompleta,
            moedas = moedas,
            tempos = tempo,
            velocMedias = velocMedia,
            mortes = mortes,
            mortesBuraco = mortesBuraco,
            mortesEspinho = mortesEspinho,
            mortesParedes = mortesParede,
            mortesQueda = mortesQueda,
            batidasParede = batidasParede,
            batidasArvore = batidasArvore
        };
        //RestClient.Put("https://prod-tcc-tbpdb.firebaseio.com/" + nomeAdmin + "/" + pSave.nome + ".json", pSave); //Teste oficial
        RestClient.Put("https://db-tbp.firebaseio.com/" + nomeAdmin + "/" + pSave.nome + ".json", pSave); //Teste normal
    }

    /*public void RetreiveSaveData(String pNome){

        RestClient.Get<Save>("https://tcc-tbpdb.firebaseio.com/" + nomeAdmin + "/" + pNome + ".json").Then(response =>{
            cloudSave = response;
            UpdatePlayerScore();
        });

    }*/

    //Jogadores
    public bool ChecaSave() //Verifica se já existe um jogador com o mesmo nome
    {
        if (!File.Exists(filePath+ nomeAdmin + nomeJogador + ".dat"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void CriarSave() //Cria o arquivo de save do jogador
    {
        if (!File.Exists(filePath + nomeAdmin + nomeJogador + ".dat"))
        {
            Limpar();
            BinaryFormatter bf = new BinaryFormatter(); //Variável para converter um arquivo para binário
            FileStream file = File.Create(filePath + nomeAdmin + nomeJogador + ".dat"); //Cria um novo arquivo
            Save save = new Save  //Instancia um novo "save"
            {
                nome = nomeJogador,
                idade = idadeJogador,
                faseCompleta = faseCompleta,
                moedas = moedas,
                tempos = tempo,
                velocMedias = velocMedia,
                mortes = mortes,
                mortesBuraco = mortesBuraco,
                mortesEspinho = mortesEspinho,
                mortesParedes = mortesParede,
                mortesQueda = mortesQueda,
                batidasParede = batidasParede,
                batidasArvore = batidasArvore
            };
            bf.Serialize(file, save); //Guarda os valores de "save" no arquivo
            file.Close(); //Fecha o arquivo
            CarregarAdmin(); //Carrega o admin para adicionar o novo jogador
            saves.Add(nomeJogador); //Adciona o novo jogador na lista
            AlterarSaves(); //Salva o novo jogador em admin
        }
    }

    public void Salvar()
    {
        if (File.Exists(filePath + nomeAdmin + nomeJogador + ".dat"))
        {
            BinaryFormatter bf = new BinaryFormatter(); //Variável para converter um arquivo para binário
            FileStream file = File.Open(filePath + nomeAdmin + nomeJogador + ".dat", FileMode.Open); //Abre o arquivo
            Save save = new Save //Instancia "save"
            {
                nome = nomeJogador,
                idade = idadeJogador,
                faseCompleta = faseCompleta,
                moedas = moedas,
                tempos = tempo,
                velocMedias = velocMedia,
                mortes = mortes,
                mortesBuraco = mortesBuraco,
                mortesEspinho = mortesEspinho,
                mortesParedes = mortesParede,
                mortesQueda = mortesQueda,
                batidasParede = batidasParede,
                batidasArvore = batidasArvore
            };
            bf.Serialize(file, save); //Guarda os valores de "save" no arquivo
            file.Close(); //Fecha o arquivo
        }
    }

    public void Carregar() //Carrega os dados do jogador do arquivo do jogador para o jogo
    {
        if (File.Exists(filePath + nomeAdmin + nomeJogador + ".dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();  //Variável para converter um arquivo para binário
            FileStream file = File.Open(filePath + nomeAdmin + nomeJogador + ".dat", FileMode.Open); //Abre o arquivo
            Save save = (Save)bf.Deserialize(file); //Instancia um novo "save" e carrega os dados guardados no arquivo para ele
            file.Close(); //Fecha o arquivo
            nomeJogador = save.nome; //Passa os dados carregados
            idadeJogador = save.idade;
            faseCompleta = save.faseCompleta;
            moedas = save.moedas;
            tempo = save.tempos;
            velocMedia = save.velocMedias;
            mortes = save.mortes;
            mortesBuraco = save.mortesBuraco;
            mortesEspinho = save.mortesEspinho;
            mortesParede = save.mortesParedes;
            mortesQueda = save.mortesQueda;
            batidasParede = save.batidasParede;
            batidasArvore = save.batidasArvore;
        }
    }

    public void Limpar() //Limpa os campos da classe
    {
        for (int i = 0; i < 4; i++)
        {
            faseCompleta[i] = 0;
            moedas[i] = 0;
            tempo[i] = 0;
            velocMedia[i] = 0;
            mortes[i] = 0;
            mortesBuraco[i] = 0;
            mortesEspinho[i] = 0;
            mortesParede[i] = 0;
            mortesQueda[i] = 0;
            batidasParede[i] = 0;
            batidasArvore[i] = 0;
        }
    }

    public void Apagar() //Apaga um jogador
    {
        File.Delete(filePath + nomeAdmin + nomeJogador + ".dat"); //Deleta o arquivo do jogador
        CarregarAdmin(); //Carrega o admin para remover o jogador
        saves.Remove(nomeJogador); //Remove o jogador da lista
        AlterarSaves(); //Devolve a lista sem o jogador excluido
        Limpar();
    }

    //Admin
    public bool VerificaAdmin() //Verifica se já existe o admin
    {
        if (File.Exists(fileAdm + nomeAdmin + ".dat"))
        {
            return true; //Se extiver tudo certo, retorna true
        }
        else
        {
            return false; //Se não existe, ele retorna false
        }
    }

    public void CriarAdmin() //Cria o arquivo do admin
    {
        if (!File.Exists(fileAdm + nomeAdmin + ".dat"))
        {
            BinaryFormatter bf = new BinaryFormatter(); //Variável para converter um arquivo para binário
            FileStream file = File.Create(fileAdm + nomeAdmin + ".dat"); //Cria um novo arquivo
            Admin adm = new Admin //Instancia um novo "Admin"
            {
                nome = nomeAdmin,
                senha = senhaAdmin,
                email = emailAdmin,
                saves = saves
            };
            bf.Serialize(file, adm); //Guarda os valores de "adm" no arquivo
            file.Close(); //Fecha o arquivo
        }
    }

    public void AlterarAdmin() //Alterar os dados do admin
    {
        if (File.Exists(fileAdm + nomeAdmin + ".dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(fileAdm + nomeAdmin + ".dat", FileMode.Open); //Abre o arquivo
            Admin adm = new Admin //Instancia admin
            {
                nome = nomeAdmin,
                senha = senhaAdmin,
                email = emailAdmin,
                saves = saves
            };
            bf.Serialize(file, adm); //Salva os novos dados
            file.Close(); //Fecha o arquivo
        }
    }

    public void ExcluirAdmin()
    {
        foreach (string i in GetSaves())
        {
            if (File.Exists(filePath + i + ".dat"))
            {
                File.Delete(filePath + nomeAdmin + nomeJogador + ".dat"); //Deleta o arquivo do jogador
            }
        }
        if (File.Exists(fileAdm + nomeAdmin + ".dat"))
        {
            File.Delete(fileAdm + nomeAdmin + ".dat"); //Deleta o arquivo do admin
        }
    }

    public void AlterarSaves() //Alterar a lista de controle de saves
    {
        if (File.Exists(fileAdm + nomeAdmin + ".dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(fileAdm + nomeAdmin + ".dat", FileMode.Open); //Abre o arquivo do admin
            Admin adm = new Admin //Instancia admin
            {
                nome = nomeAdmin,
                senha = senhaAdmin,
                email = emailAdmin,
                saves = saves
            };
            bf.Serialize(file, adm); //Carrega os dados do aquivo para admin
            file.Close(); //Fecha o arquivo
        }
    }

    public void CarregarAdmin() //Carrega os dados do admin do arquivo para o jogo
    {
        if (File.Exists(fileAdm + nomeAdmin + ".dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(fileAdm + nomeAdmin + ".dat", FileMode.Open); //Abre o arquivo do admin
            Admin adm = (Admin)bf.Deserialize(file); //Instancia admin e carrega os dados do arquivo para ele
            file.Close(); //Fecha o arquivo
            nomeAdmin = adm.nome; //Passa os dados para a classe
            senhaAdmin = adm.senha;
            emailAdmin = adm.email;
            saves = adm.saves;
        }
    }

    public bool Autenticar() //Faz a verificação para logar o admin
    {
        if (File.Exists(fileAdm + nomeAdmin + ".dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(fileAdm + nomeAdmin + ".dat", FileMode.Open); //Abre o arquivo
            Admin adm = (Admin)bf.Deserialize(file); //Instancia admin e carrega os dados do arquivo para ele
            file.Close(); //Fecha o arquivo
            if (nomeAdmin.Equals(adm.nome) && senhaAdmin.Equals(adm.senha))
            {
                return true; //Se os dados corresponderem, permite o login
            }
            else
            {
                return false; //Se não, não permite logar
            }
        }
        else
        {
            return false;
        }
    }

    public bool Recuperar(string nome, string email)
    {
        SetNomeAdmin(nome);
        CarregarAdmin();
        if (emailAdmin == email)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void MediaSaves()
    {
        float[] somaMoedas = new float[4];
        float[] somaTempos = new float[4];
        float[] somaVeloc = new float[4];
        float[] somaMortes = new float[4];
        float[] somaMorteBuraco = new float[4];
        float[] somaMorteEspinho = new float[4];
        float[] somaMorteParede = new float[4];
        float[] somaMorteQueda = new float[4];
        float[] somaBatidaParede = new float[4];
        float[] somaBatidaArvore = new float[4];

        List<string> s = GetSaves();
        int[] cont = new int[4];
        foreach(string i in s)
        {
            if (File.Exists(filePath + nomeAdmin + i + ".dat"))
            {
                BinaryFormatter bf = new BinaryFormatter();  //Variável para converter um arquivo para binário
                FileStream file = File.Open(filePath+ nomeAdmin + i + ".dat", FileMode.Open); //Abre o arquivo
                Save save = (Save)bf.Deserialize(file); //Instancia um novo "save" e carrega os dados guardados no arquivo para ele
                file.Close(); //Fecha o arquivo
                for (int j=0;j<=3;j++)
                {
                    if (faseCompleta[j] > 0)
                    {
                        somaMoedas[j] += save.moedas[j];
                        somaTempos[j] += save.tempos[j];
                        somaVeloc[j] += save.velocMedias[j];
                        somaMortes[j] += save.mortes[j];
                        somaMorteBuraco[j] += save.mortesBuraco[j];
                        somaMorteEspinho[j] += save.mortesEspinho[j];
                        somaMorteParede[j] += save.mortesParedes[j];
                        somaMorteQueda[j] += save.mortesQueda[j];
                        somaBatidaParede[j] += save.batidasParede[j];
                        somaBatidaArvore[j] += save.batidasArvore[j];
                        cont[j]++;
                    }
                }
            }
        }
        for (int i=0;i<=3;i++)
        {
            if(cont[i] > 0)
            {
                mediaMoedas[i] = somaMoedas[i] / cont[i];
                mediaTempos[i] = somaTempos[i] / cont[i];
                mediaVeloc[i] = somaVeloc[i] / cont[i];
                mediaMortes[i] = somaMortes[i] / cont[i];
                mediaMorteBuraco[i] = somaMorteBuraco[i] / cont[i];
                mediaMorteEspinho[i] = somaMorteEspinho[i] / cont[i];
                mediaMorteParede[i] = somaMorteParede[i] / cont[i];
                mediaMorteQueda[i] = somaMorteQueda[i] / cont[i];
                mediaBatidaParede[i] = somaBatidaParede[i] / cont[i];
                mediaBatidaArvore[i] = somaBatidaArvore[i] / cont[i];
            }
        }
    }

    //Get's e Set's
    public List<string> GetSaves()
    {
        return saves; //Retorna a lista de saves
    }
    //Seta os resultados da fase para serem salvos
    public void SetResultados(int fase, int moedas, int tempo, float velocMedia, int mortes, int mortesBuraco, int mortesEspinho, int mortesParede, int mortesQueda, int batidasParede, int batidasArvore)
    {
        this.moedas[fase] = moedas;
        this.tempo[fase] = tempo;
        this.velocMedia[fase] = velocMedia;
        this.mortes[fase] = mortes;
        this.mortesBuraco[fase] = mortesBuraco;
        this.mortesEspinho[fase] = mortesEspinho;
        this.mortesParede[fase] = mortesParede;
        this.mortesQueda[fase] = mortesQueda;
        this.batidasParede[fase] = batidasParede;
        this.batidasArvore[fase] = batidasArvore;
    }
    public int GetMoedas(int index)
    {
        return moedas[index];
    }
    public int GetTempos(int index)
    {
        return tempo[index];
    }
    public float GetVelocMedia(int index)
    {
        return velocMedia[index];
    }
    public int GetMortes(int index)
    {
        return mortes[index];
    }
    //public int GetPontos(int index)
    //{
    //    return pontos[index];
    //}
    public int GetMortesBuraco(int index)
    {
        return mortesBuraco[index];
    }
    public int GetMortesEspinho(int index)
    {
        return mortesEspinho[index];
    }
    public int GetMortesParede(int index)
    {
        return mortesParede[index];
    }
    public int GetMortesQueda(int index)
    {
        return mortesQueda[index];
    }
    public int GetBatidasParede(int index)
    {
        return batidasParede[index];
    }
    public int GetBatidasArvore(int index)
    {
        return batidasArvore[index];
    }

    public int GetFaseCompleta(int fase)
    {
        return faseCompleta[fase];
    }
    public void SetFaseCompleta(int fase, int value)
    {
        faseCompleta[fase] = value;
    }

    public string GetNomeJogador()
    {
        return nomeJogador;
    }
    public void SetNomeJogador(string nome)
    {
        nomeJogador = nome;
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
    public string GetEmailAdmin()
    {
        return emailAdmin;
    }
    public void SetEmailAdmin(string email)
    {
        emailAdmin = email;
    }

    private void Awake()
    {
        filePath = Application.persistentDataPath + "/Save"; //Caminho do save do jogador
        fileAdm = Application.persistentDataPath + "/Admin"; //Caminho do save do Admin
        volume = 7;
        qualidade = 2;
        Screen.sleepTimeout = SleepTimeout.NeverSleep; //Nunca apagar a tela

        if (gameControl == null) //Garante que só exista 1 game control
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
