using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacaDepressao : MonoBehaviour
{
    [SerializeField] private GameObject portao, cadeado;
    [SerializeField] private bool reverse;
    [SerializeField] private AudioClip somAbre, somFecha;
    private AudioSource source;
    private Vector3 posinic;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if (reverse) //Se começa aberto
            {
                if (portao.transform.position == posinic)
                {
                    portao.transform.position = new Vector3(portao.transform.position.x, portao.transform.position.y - 2, portao.transform.position.z); //Desce o portão
                    cadeado.transform.position = new Vector3(cadeado.transform.position.x, cadeado.transform.position.y - 100, cadeado.transform.position.z);
                    source.clip = somFecha; //Passa o som pro controlador
                    source.Play(0); //Toca o som
                }
                else
                {
                    portao.transform.position = new Vector3(portao.transform.position.x, portao.transform.position.y + 2, portao.transform.position.z); //Sobe o portão
                    cadeado.transform.position = new Vector3(cadeado.transform.position.x, cadeado.transform.position.y + 100, cadeado.transform.position.z);
                    source.clip = somAbre; //Passa o som pro controlador
                    source.Play(0); //Toca o som
                }
            }
            else
            {
                if (portao.transform.position == posinic)
                {
                    portao.transform.position = new Vector3(portao.transform.position.x, portao.transform.position.y + 2, portao.transform.position.z); //Sobe o portão
                    cadeado.transform.position = new Vector3(cadeado.transform.position.x, cadeado.transform.position.y + 100, cadeado.transform.position.z);
                    source.clip = somAbre; //Passa o som pro controlador
                    source.Play(0); //Toca o som
                }
                else
                {
                    portao.transform.position = new Vector3(portao.transform.position.x, portao.transform.position.y - 2, portao.transform.position.z); //Desce o portão
                    cadeado.transform.position = new Vector3(cadeado.transform.position.x, cadeado.transform.position.y - 100, cadeado.transform.position.z);
                    source.clip = somFecha; //Passa o som pro controlador
                    source.Play(0); //Toca o som
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        posinic = portao.transform.position;
        source = GetComponent<AudioSource>();
    }
    
}
