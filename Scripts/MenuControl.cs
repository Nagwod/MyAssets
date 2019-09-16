using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
    GameControl gameControl; //Variável do tipo gamecontrol, para acessar os métodos de lá 
    //public Text tsave1, tsave2, tsave3;
    //public Text tpontuacao, tpontos;
    public int fase; //Variável para saber de qual fase os dados serão exibidos na tela de resultados das fases
    public Button[] botoes; //Botões para entrar nas fases
    public Button[] botoes2; //Botões para acessar os resultados das fases
    public InputField nomeAdmCriar, senhaAdmCriar, nomeAdmLogin, senhaAdmLogin; //Campos de texto do login do admin e do cirar admin
    public InputField nomeJogador, idadeJogador; //Campos de texto do criar jogador
    public GameObject criarAdm, menu, loginAdm, admin, criarJogador, loginJogador, selecaoFases, dadosJogador, avisoExclusao;
    public GameObject erroCriarAdm, erroLoginAdm, erroCriarJogador, erroCriarJogador2, erroCriarJogador3; //Vários objetos das telas do menu
    public Slider squalidade; //O slider que altera a qualidade do jogo
    public GameObject prefabBotao, prefabBotao2; //Botões prefab para os jogadores que forem criados
    public Transform content, content2; //Os campos de rolagem que tem os botões dos jogadores criados
    public Text nomeIdadeDados, nomeIdadeExclusao, faseDados, moedasDados, tempoDados, mortesDados, mortesBuracoDados, mortesEspinhoDados, mortesParedeDados, mortesQuedaDados, batidasParedeDados, batidasArvoreDados; //Campos da tela de resultados
    public List<Button> botoesSaves, botoesSaves2 = new List<Button>(); //Lista para acessar os botões de jogadores criados na hora de excluir
    private bool isAdmin; //Quando for para a tela de criar jogador, essa variável verifica se você veio da tela de jogador ou de admin, para que seja possível voltar para a página em que você estava antes

    public void ExibirDados() //Método para exibir os resultados das fases na tela
    {
        if (gameControl.GetIdadeJogaor()=="1") //Se a idade for igual a 1, exibe "ano" ao invés de "anos"
        {
            nomeIdadeDados.text = gameControl.GetNomeJogador() + ", " + gameControl.GetIdadeJogaor() + " ano"; //Na tela de resultados
            nomeIdadeExclusao.text = gameControl.GetNomeJogador() + ", " + gameControl.GetIdadeJogaor() + " ano"; //Na tela aviso de exclusão
        }
        else
        {
            nomeIdadeDados.text = gameControl.GetNomeJogador() + ", " + gameControl.GetIdadeJogaor() + " anos"; //Na tela de resultados
            nomeIdadeExclusao.text = gameControl.GetNomeJogador() + ", " + gameControl.GetIdadeJogaor() + " anos"; //Na tela aviso de exclusão
        }
        if (fase != 0) //Se tiver fase selecionada, exibe os dados da fase
        {
            faseDados.text = "Fase " + fase + ":";
            moedasDados.text = "Moedas: " + gameControl.GetMoedas(fase - 1);
            tempoDados.text = "Tempo: " + gameControl.GetTempos(fase - 1);
            mortesDados.text = "Total de mortes: " + gameControl.GetMortes(fase - 1);
            mortesBuracoDados.text = "Buracos: " + gameControl.GetMortesBuraco(fase - 1);
            mortesEspinhoDados.text = "Espinhos: " + gameControl.GetMortesEspinho(fase - 1);
            mortesParedeDados.text = "Paredes: " + gameControl.GetMortesParede(fase - 1);
            mortesQuedaDados.text = "Quedas: " + gameControl.GetMortesQueda(fase - 1);
            batidasParedeDados.text = "Paredes: " + gameControl.GetBatidasParede(fase - 1);
            batidasArvoreDados.text = "Árvores: " + gameControl.GetBatidasArvore(fase - 1);
        }
        else //Se não tiver fase selecionada, não exibe dados
        {
            faseDados.text = "Selecione uma fase"; //Aviso de que não há fase selecionada
            moedasDados.text = "Moedas: ";
            tempoDados.text = "Tempo: ";
            mortesDados.text = "Total de mortes: ";
            mortesBuracoDados.text = "Buracos: ";
            mortesEspinhoDados.text = "Espinhos: ";
            mortesParedeDados.text = "Paredes: ";
            mortesQuedaDados.text = "Quedas: ";
            batidasParedeDados.text = "Paredes: ";
            batidasArvoreDados.text = "Árvores: ";
        }
    }

    public void AcessarDadosJogador(string nomeJogador) //Método para acessar a tela de dados do jogador
    {
        gameControl.SetNomeJogador(nomeJogador); //Seta o nome do jogador para acessar seus dados
        gameControl.Carregar(); //Carrega o jogador
        dadosJogador.SetActive(true); //Troca de tela
        admin.SetActive(false); //Troca de tela
        foreach(Button b in botoes2)
        {
            b.interactable = false; //Desativa os botões de fase
        }
        for (int i = 0; i < gameControl.GetFasesCompletas(); i++)
        {
            botoes2[i].interactable = true; //Ativa os botões das fases jogadas
        }
        fase = 0; //Para entrar sem nenhuma fase selecionada
        ExibirDados(); //Para exibir os dados na tela
    }

    public void LogarJogador(string nomeJogador) //Método para entrar na tela de fases para jogar
    {
        gameControl.SetNomeJogador(nomeJogador);  //Seta o nome do jogador para acessar seus dados
        gameControl.Carregar();  //Carrega o jogador
        selecaoFases.SetActive(true); //Troca de tela
        loginJogador.SetActive(false); //Troca de tela
        foreach(Button b in botoes)
        {
            b.interactable = false; //Desativa os botões das fases
        }
        for (int i = 0; i <= gameControl.GetFasesCompletas(); i++)
        {
            botoes[i].interactable = true; //Ativa os botões das fases liberadas
        }
    }

    public void CriaAdm() //Método para chamar o método de criar o admin
    {
        if (!(nomeAdmCriar.Equals("") || senhaAdmCriar.Equals(""))) //Se nenhum dos campos for vazio, ele permite que seja criado
        {
            gameControl.SetNomeAdmin(nomeAdmCriar.text); //Seta o nome do admin para criá-lo
            gameControl.SetSenhaAdmin(senhaAdmCriar.text); //Seta a senha do admin para criá-lo
            gameControl.CriarAdmin(); //Cria o admin
            criarAdm.SetActive(false); //Troca de tela
            menu.SetActive(true); //Troca de tela
            ApagaErros(); //Apaga as mensagens de erros das telas
            ApagaTextos(); //Apaga os campos de texto
        }
        else
        {
            erroCriarAdm.SetActive(true); //Se um dos campos for vazio, exibe a mensagem de erro na tela
        }
    }
    public void LoginAdm() //Método para entrar na página de admin
    {
        gameControl.SetNomeAdmin(nomeAdmLogin.text); //Seta o nome do admin para autenticar
        gameControl.SetSenhaAdmin(senhaAdmLogin.text); //Seta a senha do admin para autenticar
        if (gameControl.Autenticar()) //Faz a autenticação
        {
            loginAdm.SetActive(false); //Troca de tela
            admin.SetActive(true); //Troca de tela
            ApagaErros(); //Apaga as mensagens de erros das telas
            ApagaTextos(); //Apaga os campos de texto
        }
        else
        {
            erroLoginAdm.SetActive(true); //Se os dados estiverem incorretos, exibe a mensagem de erro
        }
    }

    public void CriaJogador() //Método que chama o método que cria o jogador
    {
        gameControl.SetNomeJogador(nomeJogador.text); //Seta o nome do jogador
        gameControl.SetIdadeJogador(idadeJogador.text); //Seta a idade do jogador
        if (nomeJogador.text == "" || idadeJogador.text == "") //Verifica se um dos campos está vazio
        {
            erroCriarJogador.SetActive(true); //Exibe a mensagem de erro avisando que um dos campos está vazio
            erroCriarJogador2.SetActive(false); //Esconde as outras mensagens de erro
            erroCriarJogador3.SetActive(false); //Esconde as outras mensagens de erro
        }
        else
        {
            if (idadeJogador.text.Contains("-")) //Se a idade for negativa
            {
                erroCriarJogador3.SetActive(true); //Exibe a mensagem de erro avisando que a idade não pode ser negativa
                erroCriarJogador.SetActive(false); //Esconde as outras mensagens de erro
                erroCriarJogador2.SetActive(false); //Esconde as outras mensagens de erro
            }
            else
            {
                if (gameControl.ChecaSave()) //Verifica se já existe um jogador com o mesmo nome
                {
                    gameControl.CriarSave(); //Cria o jogador
                    CriaBotao(); //Cria um botão para acessar o jogador
                    CriaJogadorVoltar();
                }
                else
                {
                    erroCriarJogador2.SetActive(true); //Exibe a mensagem de erro avisando que já existe um jogador com o mesmo nome
                    erroCriarJogador.SetActive(false); //Esconde as outras mensagens de erro
                    erroCriarJogador3.SetActive(false); //Esconde as outras mensagens de erro
                }
            }
        }
    }
    public void CriaJogadorVoltar() //Método para sair da tela de criar jogador
    {
        criarJogador.SetActive(false); //Sai da tela de criar jogador
        ApagaErros(); //Apaga os erros das telas
        ApagaTextos(); //Apaga os campos de texto
        if (isAdmin)
        {
            admin.SetActive(true); //Se veio da página de admin, volta pra tela de admin
        }
        else
        {
            loginJogador.SetActive(true); //Se veio da página de login do jogador, volta para a página de login do jogador
        }
    }
    public void AdminSet(bool b) //Seta a variável que é utilizada no método acima
    {
        if (b)
        {
            isAdmin = true;
        }
        else
        {
            isAdmin = false;
        }
    }

    public void ExcluirJogador() //Método que chama o método de excluir o jogador
    {
        ExcluiBotao(); //Exclui o botão do jogador
        gameControl.Apagar(); //Apaga o save do jogador
        avisoExclusao.SetActive(false); //Fecha a tela de aviso de exclusão
        dadosJogador.SetActive(false); //Fecha a tela de dados do jogador
        admin.SetActive(true); //Abre a tela de admin
    }

    public void ApagaErros() //Apaga as mensagens de erro
    {
        erroCriarAdm.SetActive(false);
        erroCriarJogador.SetActive(false);
        erroCriarJogador2.SetActive(false);
        erroCriarJogador3.SetActive(false);
        erroLoginAdm.SetActive(false);
    }
    public void ApagaTextos() //Apaga os campos de texto
    {
        nomeAdmCriar.text = "";
        nomeAdmLogin.text = "";
        nomeJogador.text = "";
        senhaAdmCriar.text = "";
        senhaAdmLogin.text = "";
        idadeJogador.text = "";
    }

    public void MudaQualidade() //Altera a qualidade do jogo
    {
        QualitySettings.SetQualityLevel((int)squalidade.value, true); //Altera o valor da qualidade baseado no valor da posição do slider
        gameControl.qualidade = (int)squalidade.value; //Muda a variável que salva o valor de qualidade para quando o jogo for aberto de novo
    }

    public void CriaBotao() //Cria o botão correspondente ao novo jogador criado
    {
        GameObject go = Instantiate(prefabBotao) as GameObject; //Instancia o prefab do botão (na tela de jogador)
        go.transform.SetParent(content); //Coloca o botão criado dentro do campo de rolagem (na tela de jogador)
        go.GetComponentInChildren<Text>().text = nomeJogador.text; //Coloca o nome do jogador no texto do botão
        botoesSaves.Add(go.GetComponent<Button>()); //Salva o botão na lista para ele poder ser acessado depois
        //go.GetComponent<Button>().onClick.AddListener(() => LogarJogador(nomeJogador.text));
        GameObject go2 = Instantiate(prefabBotao2) as GameObject; //Instancia o prefab do botão (na tela de admin)
        go2.transform.SetParent(content2); //Coloca o botão criado dentro do campo de rolagem (na tela de admin)
        go2.GetComponentInChildren<Text>().text = nomeJogador.text; //Coloca o nome do jogador no texto do botão
        botoesSaves2.Add(go2.GetComponent<Button>()); //Salva o botão na lista para ele poder ser acessado depois
    }
    public void ExcluiBotao() //Exclui o botão do jogador que for excluido
    {
        foreach (Button b in botoesSaves) //Percorre todos os botões da lista
        {
            if (b.GetComponentInChildren<Text>().text.Equals(gameControl.GetNomeJogador())) //Verifica se o texto do botão corresponde ao nome do jogador (na tela de jogador)
            {
                Destroy(b.gameObject); //Destrói o botão
                botoesSaves.Remove(b); //Remove o botão da lista
                break; //Sai do laço para não gerar erro, pois houve uma remoção na lista
            }
        }
        foreach (Button b in botoesSaves2) //Percorre todos os botões da lista
        {
            if (b.GetComponentInChildren<Text>().text.Equals(gameControl.GetNomeJogador())) //Verifica se o texto do botão corresponde ao nome do jogador (na tela de admin)
            {
                Destroy(b.gameObject); //Destrói o botão
                botoesSaves2.Remove(b); //Remove o botão da lista
                break; //Sai do laço para não gerar erro, pois houve uma remoção na lista
            }
        }
    }

    public void SetFase(int f) //Seta a fase para ser exibida
    {
        fase = f; //Seta o valor
        ExibirDados(); //Troca os dados
    }

    /*
    public void SetSaveText()
    {
        tsave1.text = gameControl.FileToString(1);
        tsave2.text = gameControl.FileToString(2);
        tsave3.text = gameControl.FileToString(3);
    }

    public void SetPontosText()
    {
        tpontuacao.text = gameControl.PontuacaoToString(fase);
        tpontos.text = gameControl.PontosToString(fase);
    }
    public void Apagar()
    {
        gameControl.Apagar();
    }

    public void SetSave(int save)
    {
        gameControl.SetSave(save);
    }
    
    public void SetFase(int fase)
    {
        this.fase = fase;
    }

    public void AtivaBotoes()
    {
        for (int i = 0; i < botoes.Length; i++)
        {
            if (gameControl.GetFasesCompletas() >= i)
            {
                botoes[i].interactable = true;
            }
            else
            {
                botoes[i].interactable = false;
            }
        }
    }

    public void AtivaBotoes2()
    {
        for (int i = 0; i < botoes2.Length; i++)
        {
            if (gameControl.GetFasesCompletas() > i)
            {
                botoes2[i].interactable = true;
            }
            else
            {
                botoes2[i].interactable = false;
            }
        }
    }
    */

    // Start is called before the first frame update
    void Start()
    {
        gameControl = GameControl.gameControl; //Seta o gameControl
        squalidade.value = gameControl.qualidade; //Puxa o valor de qaulidade
        if (gameControl.VerificaAdmin()) //Verifia se existe admin
        {
            criarAdm.SetActive(false); //Se já existe, ele fecha a tela de admin
            menu.SetActive(true); //e abre o menu
        }
        gameControl.CarregarAdmin(); //Carrega o admin (se existir)
        foreach (string save in gameControl.GetSaves()) //percorre todos os saves
        {
            GameObject go = Instantiate(prefabBotao) as GameObject; //Instancia o botão prefab para cada jogador (na tela de jogador)
            go.transform.SetParent(content); //Coloca o botão no campo de rolagem (na tela de admin)
            go.GetComponentInChildren<Text>().text = save; //Coloca o nome do jogador no texto do botão
            botoesSaves.Add(go.GetComponent<Button>()); //Coloca o botão na lista
            //go.GetComponent<Button>().onClick.AddListener(() => LogarJogador(save));
            GameObject go2 = Instantiate(prefabBotao2) as GameObject; //Instancia o botão prefab para cada jogador (na tela de admin)
            go2.transform.SetParent(content2); //Coloca o botão no campo de rolagem (na tela de admin)
            go2.GetComponentInChildren<Text>().text = save; //Coloca o nome do jogador no texto do botão
            botoesSaves2.Add(go2.GetComponent<Button>()); //Coloca o botão na lista
        }
    }
}
