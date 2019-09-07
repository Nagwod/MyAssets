using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    GameControl gameControl;
    public Text tsave1, tsave2, tsave3;
    public Text tpontuacao, tpontos;
    public int fase;
    public Button[] botoes;
    public Button[] botoes2;
    public InputField nomeAdmCriar, senhaAdmCriar, nomeAdmLogin, senhaAdmLogin;
    public InputField nomeJogador, idadeJogador;
    public GameObject criarAdm, menu, loginAdm, admin, criarJogador, loginJogador;
    public GameObject erroCriarAdm, erroLoginAdm, erroCriarJogador, erroCriarJogador2;
    private bool isAdmin;

    public void CriaAdm()
    {
        gameControl.SetNomeAdmin(nomeAdmCriar.text);
        gameControl.SetSenhaAdmin(senhaAdmCriar.text);
        gameControl.CriarAdmin();
        if (gameControl.VerificaAdmin())
        {
            criarAdm.SetActive(false);
            menu.SetActive(true);
            ApagaErros();
            ApagaTextos();
        }
        else
        {
            erroCriarAdm.SetActive(true);
        }
    }
    public void LoginAdm()
    {
        gameControl.SetNomeAdmin(nomeAdmLogin.text);
        gameControl.SetSenhaAdmin(senhaAdmLogin.text);
        if (gameControl.Autenticar())
        {
            loginAdm.SetActive(false);
            admin.SetActive(true);
            ApagaErros();
            ApagaTextos();
        }
        else
        {
            erroLoginAdm.SetActive(true);
        }
    }

    public void CriaJogador()
    {
        gameControl.SetNomeJogador(nomeJogador.text);
        gameControl.SetIdadeJogador(idadeJogador.text);
        if (nomeJogador.text == "" || idadeJogador.text == "")
        {
            erroCriarJogador.SetActive(true);
            erroCriarJogador2.SetActive(false);
        }
        else
        {
            erroCriarJogador.SetActive(false);
            if (gameControl.ChecaSave())
            {
                gameControl.CriarSave();
                CriaJogadorVoltar();
            }
            else
            {
                erroCriarJogador2.SetActive(true);
            }
        }
    }
    public void CriaJogadorVoltar()
    {
        criarJogador.SetActive(false);
        ApagaErros();
        ApagaTextos();
        if (isAdmin)
        {
            admin.SetActive(true);
        }
        else
        {
            loginJogador.SetActive(true);
        }
    }

    public void AdminSet(bool b)
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

    public void ApagaErros()
    {
        erroCriarAdm.SetActive(false);
        erroCriarJogador.SetActive(false);
        erroCriarJogador2.SetActive(false);
        erroLoginAdm.SetActive(false);
    }
    public void ApagaTextos()
    {
        nomeAdmCriar.text = "";
        nomeAdmLogin.text = "";
        nomeJogador.text = "";
        senhaAdmCriar.text = "";
        senhaAdmLogin.text = "";
        idadeJogador.text = "";
    }

    public void SetSaveText()
    {
        //tsave1.text = gameControl.FileToString(1);
        //tsave2.text = gameControl.FileToString(2);
        //tsave3.text = gameControl.FileToString(3);
    }

    public void SetPontosText()
    {
        //tpontuacao.text = gameControl.PontuacaoToString(fase);
        //tpontos.text = gameControl.PontosToString(fase);
    }

    public void Load()
    {
        //gameControl.Load();
    }

    public void Apagar()
    {
        gameControl.Apagar();
    }

    public void SetSave(int save)
    {
        //gameControl.SetSave(save);
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

    // Start is called before the first frame update
    void Start()
    {
        gameControl = GameControl.gameControl;
        if (gameControl.VerificaAdmin())
        {
            criarAdm.SetActive(false);
            menu.SetActive(true);
        }
    }
}
