using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolim : MonoBehaviour
{
    public Rigidbody player;
    public int potencia; //Força do pulo
    public AudioClip[] som; //Vetor de sons
    public AudioSource source;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int index = Random.Range(0, som.Length); //Escolhe um som aleatório
            source.clip = som[index]; //Passa o som pro controlador
            source.Play(0); //Toca o som
            player.AddForce(Vector3.up * potencia, ForceMode.Impulse); //Pula
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
