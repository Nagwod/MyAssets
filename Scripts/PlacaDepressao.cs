using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacaDepressao : MonoBehaviour
{
    public GameObject portao;
    private Vector3 posinic;
    public bool reverse;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            if (reverse) //Se começa aberto
            {
                if (portao.transform.position == posinic)
                {
                    portao.transform.position = new Vector3(portao.transform.position.x, portao.transform.position.y - 1, portao.transform.position.z); //Desce o portão
                }
                else
                {
                    portao.transform.position = new Vector3(portao.transform.position.x, portao.transform.position.y + 1, portao.transform.position.z); //Sobe o portão
                }
            }
            else
            {
                if (portao.transform.position == posinic)
                {
                    portao.transform.position = new Vector3(portao.transform.position.x, portao.transform.position.y + 1, portao.transform.position.z); //Sobe o portão
                }
                else
                {
                    portao.transform.position = new Vector3(portao.transform.position.x, portao.transform.position.y - 1, portao.transform.position.z); //Desce o portão
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
