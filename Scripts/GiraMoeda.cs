using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiraMoeda : MonoBehaviour
{
    GameControl gameControl;
    public GameObject tatu; //Recebe o tatu
    private bool trigger;
    public int deteccao;

    IEnumerator Gira()
    {
        if (trigger && QualitySettings.GetQualityLevel()>1)
        {
            transform.Rotate(0, 0, 2);
            yield return new WaitForFixedUpdate();
        }
        else
        {
            yield return new WaitForSeconds(0.05f);
        }
        StartCoroutine(Gira());
    }

    // Start is called before the first frame update
    void Start()
    {
        gameControl = GameControl.gameControl;
        StartCoroutine(Gira());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, tatu.transform.position) < deteccao) //Controle de distância do tatu
        {
            trigger = true;
        }
        else
        {
            trigger = false;
        }
    }
}
