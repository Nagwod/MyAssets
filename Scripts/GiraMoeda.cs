using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiraMoeda : MonoBehaviour
{
    public GameObject tatu; //Recebe o tatu
    private bool trigger;
    public int deteccao;

    IEnumerator Gira()
    {
        if (trigger)
        {
            transform.Rotate(0, 0, 2);
        }
        yield return new WaitForFixedUpdate();
        StartCoroutine(Gira());
    }

    // Start is called before the first frame update
    void Start()
    {
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
