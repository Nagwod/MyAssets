using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rachado : MonoBehaviour
{
    private Vector3 posinic;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            StartCoroutine(Quebra());
        }
    }

    IEnumerator Quebra()
    {
        yield return new WaitForSeconds(2);
        transform.position = new Vector3(500, 500, 500); //Esconde
        yield return new WaitForSeconds(6);
        transform.position = posinic; //Volta pro lugar
    }

    // Start is called before the first frame update
    void Start()
    {
        posinic = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
