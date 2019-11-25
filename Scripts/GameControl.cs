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
    public static GameControl gameControl;
    [SerializeField] private string filePath, fileAdm; //Caminhos dos arquivos
    public string nomeDB;
    public bool logado;
    private string nomeAdmin, senhaAdmin, emailAdmin;
    private List<string> saves = new List<string>(); //Lista para controlar os saves
    private string nomeJogador, idadeJogador;
    private int[] faseCompleta = new int[4]; //0: não jogada, 1: incompleta, 2:completa
    private int[] moedas = new int[4];
    private int[] tempo = new int[4];
    private float[] velocMedia = new float[4];
    private int[] mortes = new int[4];
    private int[] mortesEspinho = new int[4];
    private int[] mortesParede = new int[4];
    private int[] mortesBuraco = new int[4];
    private int[] mortesQueda = new int[4];
    private int[] batidasParede = new int[4];
    private int[] batidasArvore = new int[4];
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

    //Jogadores
    public bool ChecaSave() //Verifica se já existe um jogador com o mesmo nome
    {
        foreach (string i in saves)
        {
            if (!(i == nomeAdmin + "/" + nomeJogador))
            {
                return true;
            }
        }
        return false;
    }

    public void CriarSave() //Cria o arquivo de save do jogador
    {
        if (!File.Exists(filePath + nomeAdmin + nomeJogador + ".dat"))
        {
            Limpar();
            BinaryFormatter bf = new BinaryFormatter(); //Variável para converter um arquivo para binário
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
            RestClient.Put("https://db-tbp.firebaseio.com/" + nomeAdmin + "/" + pSave.nome + ".json", pSave); //Teste normal
            CarregarAdmin(); //Carrega o admin para adicionar o novo jogador
            saves.Add(nomeAdmin +"/"+ nomeJogador); //Adciona o novo jogador na lista
            AlterarSaves(); //Salva o novo jogador em admin
        }
    }

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

    public void RetreiveSaveData(string savepath)
    {
        Save save = new Save();
        RestClient.Get<Save>("https://db-tbp.firebaseio.com/" + savepath + ".json").Then(response => {
            save = response;
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
        });
    }
    
    public void GetNomeDB(string savepath)
    {
        Save save = new Save();
        RestClient.Get<Save>("https://db-tbp.firebaseio.com/" + savepath + ".json").Then(response => {
            save = response;
            nomeDB = save.nome;
        });
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
        saves.Remove(nomeAdmin + nomeJogador); //Remove o jogador da lista
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
        StartCoroutine(MediaDelay());
    }

    public IEnumerator MediaDelay()
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
        bool aux = false;
        foreach (string i in s)
        {
            Save save = new Save();
            RestClient.Get<Save>("https://db-tbp.firebaseio.com/" + i + ".json").Then(response =>
            {
                save = response;
                for (int j = 0; j <= 3; j++)
                {
                    if (save.faseCompleta[j] > 0)
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
                aux = true;
            });
            while (!aux)
            {
                yield return new WaitForSeconds(0.1f);
            }
            aux = false;
        }
        for (int i = 0; i <= 3; i++)
        {
            if (cont[i] > 0)
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
    public void SetSaves(List<string> s)
    {
        saves = s;
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
    public string GetIdadeJogador()
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

    private void GetTeste()
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
        if (!File.Exists(fileAdm + "RaulPila" + ".dat")){
            List<string> s = new List<string>();
            s.Add("RaulPila/Alex");
            s.Add("RaulPila/Alex Sandro");
            s.Add("RaulPila/Emanuely");
            s.Add("RaulPila/Joyce");
            s.Add("RaulPila/Laura");
            s.Add("RaulPila/Melissa");
            s.Add("RaulPila/Miguel");
            s.Add("RaulPila/Talita");
            s.Add("RaulPila/Ana");
            s.Add("RaulPila/Eduardo");
            s.Add("RaulPila/Endriew");
            s.Add("RaulPila/Ingrid");
            s.Add("RaulPila/Juliana");
            s.Add("RaulPila/Nathan");
            s.Add("RaulPila/Raul");
            s.Add("RaulPila/Sara");
            BinaryFormatter bf = new BinaryFormatter(); //Variável para converter um arquivo para binário
            FileStream file = File.Create(fileAdm + "RaulPila" + ".dat"); //Cria um novo arquivo
            Admin adm = new Admin //Instancia um novo "Admin"
            {
                nome = "RaulPila",
                senha = "1234",
                email = "tcc.tbp2019@gmail.com",
                saves = s
            };
            bf.Serialize(file, adm); //Guarda os valores de "adm" no arquivo
            file.Close(); //Fecha o arquivo
        }
    }

    private void Awake()
    {
        filePath = Application.persistentDataPath + "/Save"; //Caminho do save do jogador
        fileAdm = Application.persistentDataPath + "/Admin"; //Caminho do save do Admin
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
        GetTeste();
    }
}
