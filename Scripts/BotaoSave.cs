using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotaoSave : MonoBehaviour
{
    public void LogarJogador() //Ação do botão Prefab para entrar no perfil do jogador para jogar
    {
        GetComponentInParent<MenuControl>().LogarJogador(GetComponentInChildren<Text>().text); //Loga o jogador cujo nome está no texto
    }

    public void AcessarJogador() //Ação do botão Prefab para entrar no perfil do jogador para ver os dados salvos
    {
        GetComponentInParent<MenuControl>().AcessarDadosJogador(GetComponentInChildren<Text>().text); //Acessa o jogador cujo nome está no texto
    }
}
