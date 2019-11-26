using System.Collections; //Para utilizar corrotinas
using System.Collections.Generic; //Para utilizar listas
using UnityEngine; //Padrão
using UnityEngine.UI; //Para interface

public class MenuControl : MonoBehaviour
{
    GameControl gameControl; //Variável do tipo gamecontrol, para acessar os métodos de lá
    private int fase; //Variável para saber de qual fase os dados serão exibidos na tela de resultados das fases
    private bool botoesCarregados;
    [SerializeField] private Button[] botoes; //Botões para entrar nas fases
    [SerializeField] private Button[] botoes2; //Botões para acessar os resultados das fases
    [SerializeField] private InputField nomeJogador, idadeJogador, nomeAdmCriar, emailAdmCriar, senhaAdmCriar, nomeAdmLogin, senhaAdmLogin, emailAdmAlterar, senhaAdmAlterar; //Campos de texto do login do admin e do cirar admin
    [SerializeField] private GameObject criarAdm, menu, loginAdm, alterarAdmin, criarJogador, loginJogador, selecaoFases, dadosJogador, avisoExclusao;
    [SerializeField] private GameObject erroCriarAdm, erroCriarAdm2, erroLoginAdm, erroCriarJogador, erroCriarJogador2, erroCriarJogador3, naoAlteradoAdm, alteradoAdm, carregandoJogadores, carregandoJogador, carregandoDados; //Vários objetos das telas do menu
    [SerializeField] private GameObject prefabBotao; //Botão prefab para os jogadores que forem criados
    [SerializeField] private Transform content;//O campo de rolagem que tem os botões dos jogadores criados
    [SerializeField] private Text nomeAdminAlterar, emailAdminAlterar, nomeAdminPainel, nomeIdadeDados, faseDados, moedasDados, tempoDados, velocMedDados, mortesDados, mortesBuracoDados, mortesEspinhoDados, mortesParedeDados, mortesQuedaDados, batidasParedeDados, batidasArvoreDados; //Campos da tela de resultados
    [SerializeField] private List<Button> botoesSaves; //Lista para acessar os botões de jogadores criados na hora de excluir

    public void ExibirDados() //Método para exibir os resultados das fases na tela
    {
        if (gameControl.GetIdadeJogador() == "1") //Se a idade for igual a 1, exibe "ano" ao invés de "anos"
        {
            nomeIdadeDados.text = gameControl.GetNomeJogador() + ", " + gameControl.GetIdadeJogador() + " ano"; //Na tela de resultados
            //nomeIdadeExclusao.text = gameControl.GetNomeJogador() + ", " + gameControl.GetIdadeJogaor() + " ano"; //Na tela aviso de exclusão
        }
        else
        {
            nomeIdadeDados.text = gameControl.GetNomeJogador() + ", " + gameControl.GetIdadeJogador() + " anos"; //Na tela de resultados
            //nomeIdadeExclusao.text = gameControl.GetNomeJogador() + ", " + gameControl.GetIdadeJogaor() + " anos"; //Na tela aviso de exclusão
        }
        faseDados.text = "Fase " + fase + ":";
        moedasDados.text = "Moedas: " + gameControl.GetMoedas(fase - 1) + " (média: " + gameControl.mediaMoedas[fase - 1].ToString("F") + ")";
        tempoDados.text = "Tempo: " + gameControl.GetTempos(fase - 1) + " (média: " + gameControl.mediaTempos[fase - 1].ToString("F") + ")";
        velocMedDados.text = "Velocidade média: " + gameControl.GetVelocMedia(fase - 1).ToString("F") + " (média: " + gameControl.mediaVeloc[fase - 1].ToString("F") + ")" + " (Máx 15)";
        mortesDados.text = "Total de mortes: " + gameControl.GetMortes(fase - 1) + " (média: " + gameControl.mediaMortes[fase - 1] + ")";
        mortesBuracoDados.text = "Buracos: " + gameControl.GetMortesBuraco(fase - 1) + " (média: " + gameControl.mediaMorteBuraco[fase - 1].ToString("F") + ")";
        mortesEspinhoDados.text = "Espinhos: " + gameControl.GetMortesEspinho(fase - 1) + " (média: " + gameControl.mediaMorteEspinho[fase - 1].ToString("F") + ")";
        mortesParedeDados.text = "Paredes: " + gameControl.GetMortesParede(fase - 1) + " (média: " + gameControl.mediaMorteParede[fase - 1].ToString("F") + ")";
        mortesQuedaDados.text = "Quedas: " + gameControl.GetMortesQueda(fase - 1) + " (média: " + gameControl.mediaMorteQueda[fase - 1].ToString("F") + ")";
        batidasParedeDados.text = "Paredes: " + gameControl.GetBatidasParede(fase - 1) + " (média: " + gameControl.mediaBatidaParede[fase - 1].ToString("F") + ")";
        batidasArvoreDados.text = "Árvores: " + gameControl.GetBatidasArvore(fase - 1) + " (média: " + gameControl.mediaBatidaArvore[fase - 1].ToString("F") + ")";
    }

    public void AcessarDadosJogador() //Método para acessar a tela de dados do jogador
    {
        gameControl.RetreiveSaveData(gameControl.GetNomeAdmin() + "/" + gameControl.GetNomeJogador()); //Carrega o jogador
        menu.SetActive(false); //Troca de tela
        carregandoDados.SetActive(true);
        StartCoroutine(DatabaseDelay3()); //Corrotina é chamada para esperar pelos dados da nuvem
    }
    IEnumerator DatabaseDelay3()
    {
        while (gameControl.carregandoNuvem) //Espera os dados chegarem da nuvem
        {
            yield return new WaitForSeconds(0.1f);
        }
        gameControl.carregandoNuvem = true;
        foreach (Button b in botoes2)
        {
            var colors = b.colors;
            colors.normalColor = new Vector4(0.2f, 0.7f, 1, 1);
            colors.highlightedColor = new Vector4(0, 0.5f, 1, 1);
            colors.pressedColor = new Vector4(0, 0.5f, 1, 1);
            b.colors = colors;
            b.interactable = false; //Desativa os botões de fase
        }
        for (int i = 0; i <= 3; i++)
        {
            if (gameControl.GetFaseCompleta(i) == 1)
            {
                botoes2[i].interactable = true; //Ativa os botões das fases jogadas
            }
            if (gameControl.GetFaseCompleta(i) == 2)
            {
                botoes2[i].interactable = true; //Ativa os botões das fases jogadas
                var colors = botoes2[i].colors;
                colors.normalColor = new Vector4(0, 0.8f, 0.2f, 1);
                colors.highlightedColor = new Vector4(0, 0.7f, 0.2f, 1);
                colors.pressedColor = new Vector4(0, 0.7f, 0.2f, 1);
                botoes2[i].colors = colors;
            }
        }
        fase = 1; //Para entrar sem nenhuma fase selecionada
        ExibirDados(); //Para exibir os dados na tela
        carregandoDados.SetActive(false);
        dadosJogador.SetActive(true); //Troca de tela
    }

    public void TelaFases()
    {
        foreach (Button b in botoes)
        {
            var colors = b.colors;
            colors.normalColor = new Vector4(0.2f, 0.7f, 1, 1);
            colors.highlightedColor = new Vector4(0, 0.5f, 1, 1);
            colors.pressedColor = new Vector4(0, 0.5f, 1, 1);
            b.colors = colors;
            b.interactable = false; //Desativa os botões das fases
        }
        botoes[0].interactable = true;
        for (int i = 0; i <= 3; i++)
        {
            if (gameControl.GetFaseCompleta(i) > 1)
            {
                if (i<3)
                {
                    botoes[i + 1].interactable = true; //Ativa os botões das fases liberadas
                }
                var colors = botoes[i].colors;
                colors.normalColor = new Vector4(0, 0.8f, 0.2f, 1);
                colors.highlightedColor = new Vector4(0, 0.7f, 0.2f, 1);
                colors.pressedColor = new Vector4(0, 0.7f, 0.2f, 1);
                botoes[i].colors = colors;
            }
        }
    }

    public void LogarJogador(string nomeJogador) //Método para entrar na tela de fases para jogar
    {
        gameControl.SetNomeJogador("");  //Seta o nome do jogador para acessar seus dados
        gameControl.RetreiveSaveData(gameControl.GetNomeAdmin() + "/" + nomeJogador); //Carrega o jogador
        StartCoroutine(DatabaseDelay2(nomeJogador)); //Corrotina é chamada para esperar pelos dados da nuvem
    }
    IEnumerator DatabaseDelay2(string nome)
    {
        loginJogador.SetActive(false);
        carregandoJogador.SetActive(true); //Aparece a tela de carregamento
        while (gameControl.carregandoNuvem) //Espera os dados chegarem da nuvem
        {
            yield return new WaitForSeconds(0.1f);
        }
        gameControl.carregandoNuvem = true;
        carregandoJogador.SetActive(false);
        menu.SetActive(true); //Troca de tela
    }

    public void CriaAdm() //Método para chamar o método de criar o admin
    {
        if (nomeAdmCriar.text.Equals("") || emailAdmCriar.text.Equals("") || senhaAdmCriar.text.Equals("")) //Se nenhum dos campos for vazio, ele permite que seja criado
        {
            erroCriarAdm2.SetActive(false);
            erroCriarAdm.SetActive(true); //Se um dos campos for vazio, exibe a mensagem de erro na tela
        }
        else
        {
            if (!gameControl.VerificaAdmin(nomeAdmCriar.text))
            {
                gameControl.SetNomeAdmin(nomeAdmCriar.text); //Seta o nome do admin para criá-lo
                gameControl.SetEmailAdmin(emailAdmCriar.text); //Seta o nome do admin para criá-lo
                gameControl.SetSenhaAdmin(senhaAdmCriar.text); //Seta a senha do admin para criá-lo
                gameControl.SetSaves(new List<string>());
                gameControl.CriarAdmin(); //Cria o admin
                criarAdm.SetActive(false); //Troca de tela
                loginAdm.SetActive(true); //Troca de tela
                ApagaErros(); //Apaga as mensagens de erros das telas
                ApagaTextos(); //Apaga os campos de texto
            }
            else
            {
                erroCriarAdm.SetActive(false);
                erroCriarAdm2.SetActive(true); //Se já existir um adm com o mesmo nome, exibe a mensagem de texto na tela
            }
        }
    }
    public void LoginAdm() //Método para entrar na página de admin
    {
        gameControl.SetNomeAdmin(nomeAdmLogin.text); //Seta o nome do admin para autenticar
        gameControl.SetSenhaAdmin(senhaAdmLogin.text); //Seta a senha do admin para autenticar
        if (gameControl.Autenticar()) //Faz a autenticação
        {
            gameControl.CarregarAdmin();
            gameControl.MediaSaves();
            loginAdm.SetActive(false);
            carregandoJogadores.SetActive(true);
            CarregaBotoes();
            ApagaErros(); //Apaga as mensagens de erros das telas
            ApagaTextos(); //Apaga os campos de texto
            gameControl.logado = true;
            botoesCarregados = true;
        }
        else
        {
            erroLoginAdm.SetActive(true); //Se os dados estiverem incorretos, exibe a mensagem de erro
        }
    }

    public void AlterarAdm() //Alterar dados do admin
    {
        if (emailAdmAlterar.text.Equals("") && senhaAdmAlterar.text.Equals("")) //Se os campos forem vazios, não altera nada
        {
            ApagaErros();
            naoAlteradoAdm.SetActive(true);
        }
        else
        {
            if (emailAdmAlterar.text != "") //Se o email não for vazio, altera o email
            {
                gameControl.SetEmailAdmin(emailAdmAlterar.text);
            }
            if (senhaAdmAlterar.text != "") //Se a senha não for vazio, altera a senha
            {
                gameControl.SetSenhaAdmin(senhaAdmAlterar.text);
            }
            gameControl.AlterarAdmin();
            ApagaErros();
            alteradoAdm.SetActive(true);
        }
    }

    public void ExcluirAdm() //Método que chama o método de excluir o admin
    {
        gameControl.ExcluirAdmin(); //Apaga o admin
    }

    public void CriaJogador() //Método que chama o método que cria o jogador
    {
        gameControl.SetNomeJogador(nomeJogador.text); //Seta o nome do jogador
        gameControl.SetIdadeJogador(idadeJogador.text); //Seta a idade do jogador
        if (nomeJogador.text == "" || idadeJogador.text == "") //Verifica se um dos campos está vazio
        {
            ApagaErros(); //Esconde as outras mensagens de erro
            erroCriarJogador.SetActive(true); //Exibe a mensagem de erro avisando que um dos campos está vazio
        }
        else
        {
            if (idadeJogador.text.Contains("-")) //Se a idade for negativa
            {
                ApagaErros(); //Esconde as outras mensagens de erro
                erroCriarJogador3.SetActive(true); //Exibe a mensagem de erro avisando que a idade não pode ser negativa
            }
            else
            {
                if (gameControl.ChecaSave()) //Verifica se já existe um jogador com o mesmo nome
                {
                    gameControl.CriarSave();
                    CriaBotao(); //Cria um botão para acessar o jogador
                    criarJogador.SetActive(false);
                    loginJogador.SetActive(true);
                    ApagaErros();
                    ApagaTextos();
                }
                else
                {
                    ApagaErros(); //Esconde as outras mensagens de erro
                    erroCriarJogador2.SetActive(true); //Exibe a mensagem de erro avisando que já existe um jogador com o mesmo nome
                }
            }
        }
    }

    public void ApagaErros() //Apaga as mensagens de erro
    {
        erroCriarAdm.SetActive(false);
        erroCriarJogador.SetActive(false);
        erroCriarJogador2.SetActive(false);
        erroCriarJogador3.SetActive(false);
        erroLoginAdm.SetActive(false);
        naoAlteradoAdm.SetActive(false);
        alteradoAdm.SetActive(false);
    }
    public void ApagaTextos() //Apaga os campos de texto
    {
        nomeAdmCriar.text = "";
        emailAdmCriar.text = "";
        senhaAdmCriar.text = "";
        nomeAdmLogin.text = "";
        senhaAdmLogin.text = "";
        emailAdminAlterar.text = "";
        senhaAdmAlterar.text = "";
        nomeJogador.text = "";
        idadeJogador.text = "";
    }

    public void Logout()
    {
        gameControl.logado = false;
    }

    public void CarregaBotoes() //Carrega os botões dos jogadores
    {
        nomeAdminPainel.text = gameControl.GetNomeAdmin();
        if (!botoesCarregados)
        {
            for (int i = 0; i <= botoesSaves.Capacity; i++)
            {
                ExcluiBotao();
            }
            StartCoroutine(DatabaseDelay()); //Corrotina é chamada para esperar pelos dados da nuvem
        }
    }
    IEnumerator DatabaseDelay()
    {
        string nomeant;
        foreach (string save in gameControl.GetSaves()) //percorre todos os saves
        {
            nomeant = gameControl.nomeDB;
            gameControl.GetNomeDB(save);
            while (gameControl.carregandoNuvem) //Espera os dados chegarem da nuvem
            {
                yield return new WaitForSeconds(0.1f);
            }
            gameControl.carregandoNuvem = true;
            GameObject go = Instantiate(prefabBotao) as GameObject; //Instancia o botão prefab para cada jogador (na tela de jogador)
            go.transform.SetParent(content); //Coloca o botão no campo de rolagem (na tela de admin)
            go.GetComponentInChildren<Text>().text = gameControl.nomeDB; //Coloca o nome do jogador no texto do botão
            botoesSaves.Add(go.GetComponent<Button>()); //Coloca o botão na lista
        }
        foreach (Button b in botoesSaves) //Percorre todos os botões da lista
        {
            if (b.GetComponentInChildren<Text>().text == "") //Verifica se o texto do botão corresponde ao nome do jogador (na tela de jogador)
            {
                Destroy(b.gameObject); //Destrói o botão
            }
        }
        carregandoJogadores.SetActive(false);
        loginJogador.SetActive(true);
    }

    public void CriaBotao() //Cria o botão correspondente ao novo jogador criado
    {
        GameObject go = Instantiate(prefabBotao) as GameObject; //Instancia o prefab do botão (na tela de jogador)
        go.transform.SetParent(content); //Coloca o botão criado dentro do campo de rolagem (na tela de jogador)
        go.GetComponentInChildren<Text>().text = nomeJogador.text; //Coloca o nome do jogador no texto do botão
        botoesSaves.Add(go.GetComponent<Button>()); //Salva o botão na lista para ele poder ser acessado depois
        //go.GetComponent<Button>().onClick.AddListener(() => LogarJogador(nomeJogador.text));
    }
    public void ExcluiBotao() //Exclui o botão do jogador que for excluido
    {
        foreach (Button b in botoesSaves) //Percorre todos os botões da lista
        {
            if (b.GetComponentInChildren<Text>().text != "Criar Novo Jogador") //Verifica se o texto do botão corresponde ao nome do jogador (na tela de jogador)
            {
                Destroy(b.gameObject); //Destrói o botão
                botoesSaves.Remove(b); //Remove o botão da lista
                break;
            }
        }
    }

    public void SetFase(int f) //Seta a fase para ser exibida
    {
        fase = f; //Seta o valor
        ExibirDados(); //Troca os dados
    }

    public void SetNomeAdmAlterar() //Coloca os textos do nome e email na tela de alterar
    {
        nomeAdminAlterar.text = "Nome: " + gameControl.GetNomeAdmin();
        emailAdminAlterar.text = "E-mail: " + gameControl.GetEmailAdmin();
    }

    public void BotoesCarregadosTrue() //Evita ter que carregar os botões se já estiverem carregados
    {
        botoesCarregados = true;
    }

    public void MenuToSaves() //Se os botoes estiverem carregados, volta sem carregar
    {
        if (botoesCarregados)
        {
            carregandoJogadores.SetActive(false);
            loginJogador.SetActive(true);
        }
    }

    /*
    public void ExcluirJogador() //Método que chama o método de excluir o jogador
    {
        ExcluiBotao(); //Exclui o botão do jogador
        gameControl.Apagar(); //Apaga o save do jogador
        avisoExclusao.SetActive(false); //Fecha a tela de aviso de exclusão
        dadosJogador.SetActive(false); //Fecha a tela de dados do jogador
        loginJogador.SetActive(true); //Abre a tela de admin
    }
    */

    // Start is called before the first frame update
    void Start()
    {
        gameControl = GameControl.gameControl; //Seta o gameControl
        botoesCarregados = false;
        //Screen.orientation = ScreenOrientation.AutoRotation;
        if (gameControl.logado) //Verifia se existe admin logado
        {
            loginAdm.SetActive(false); //Se já existe, ele fecha a tela de admin
            menu.SetActive(true); //e abre o menu
            gameControl.CarregarAdmin(); //Carrega o admin (se existir)
        }
    }
}
