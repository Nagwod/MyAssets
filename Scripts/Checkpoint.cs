using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    Tatu t; //Variável do tipo tatu
    public GameObject tatu; //Recebe o tatu
    public ParticleSystem p1, p2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            t.checkpoint = new Vector3(transform.position.x, transform.position.y + 4, transform.position.z);
            p1.Emit(100);
            p2.Emit(100);
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        t = tatu.GetComponent<Tatu>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
