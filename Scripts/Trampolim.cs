using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolim : MonoBehaviour
{
    [SerializeField] private Rigidbody player;
    [SerializeField] private int potencia; //Força do pulo
    [SerializeField] private AudioClip[] som; //Vetor de sons
    [SerializeField] private AudioSource source;

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

}
