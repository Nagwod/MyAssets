using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacaDepressao : MonoBehaviour
{
    public GameObject portao, cadeado;
    private Vector3 posinic;
    public bool reverse;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if (reverse) //Se começa aberto
            {
                if (portao.transform.position == posinic)
                {
                    portao.transform.position = new Vector3(portao.transform.position.x, portao.transform.position.y - 2, portao.transform.position.z); //Desce o portão
                    cadeado.transform.position = new Vector3(cadeado.transform.position.x, cadeado.transform.position.y - 20, cadeado.transform.position.z);
                }
                else
                {
                    portao.transform.position = new Vector3(portao.transform.position.x, portao.transform.position.y + 2, portao.transform.position.z); //Sobe o portão
                    cadeado.transform.position = new Vector3(cadeado.transform.position.x, cadeado.transform.position.y + 20, cadeado.transform.position.z);
                }
            }
            else
            {
                if (portao.transform.position == posinic)
                {
                    portao.transform.position = new Vector3(portao.transform.position.x, portao.transform.position.y + 2, portao.transform.position.z); //Sobe o portão
                    cadeado.transform.position = new Vector3(cadeado.transform.position.x, cadeado.transform.position.y + 20, cadeado.transform.position.z);
                }
                else
                {
                    portao.transform.position = new Vector3(portao.transform.position.x, portao.transform.position.y - 2, portao.transform.position.z); //Desce o portão
                    cadeado.transform.position = new Vector3(cadeado.transform.position.x, cadeado.transform.position.y - 20, cadeado.transform.position.z);
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        posinic = portao.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
