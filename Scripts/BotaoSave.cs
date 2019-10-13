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
}
