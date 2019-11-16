using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    [SerializeField] private Slider squalidade, svolume; //O slider que altera a qualidade do jogo

    public void MudaQualidade() //Altera a qualidade do jogo
    {
        QualitySettings.SetQualityLevel((int)squalidade.value, true); //Altera o valor da qualidade baseado no valor da posição do slider
    }
    public void MudaVolume() //Altera a qualidade do jogo
    {
        AudioListener.volume = svolume.value / 10;
    }

    public void Pausar()
    {
        Time.timeScale = 0;
    }

    public void Despausar()
    {
        Time.timeScale = 1;
    }

    public void Reiniciar()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void CarregaCena(string cena)
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(cena);
    }
    
    public void Fechar()
    {
        Application.Quit();
    }

    void Start()
    {
        squalidade.value = QualitySettings.GetQualityLevel();
        svolume.value = AudioListener.volume * 10;
    }
}
