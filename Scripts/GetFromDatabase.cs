using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using UnityEngine.UI;

public class GetFromDatabase : MonoBehaviour
{
    GameControl gameControl; //Variável do tipo gamecontrol, para acessar os métodos de lá
    Save cloudSave;
    public Text txt1, txt2, txt3, txt4;

    public void RetreiveSaveData()
    {

        RestClient.Get<Save>("https://db-tbp.firebaseio.com/" + "jTeste" + "/" + "jPlayer1" + ".json").Then(response => {
            cloudSave = response;
            txt1.text = cloudSave.nome;
            txt2.text = cloudSave.idade;
            txt3.text = ""+cloudSave.moedas[0];
            txt4.text = ""+cloudSave.tempos[0];

        });

    }
    // Start is called before the first frame update
    void Start()
    {
        gameControl = GameControl.gameControl;
        RetreiveSaveData();
    }
}
