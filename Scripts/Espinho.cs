using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espinho : MonoBehaviour
{
    Tatu t;
    [SerializeField] private Rigidbody tatu;
    [SerializeField] private int pulo;
    [SerializeField] private float timer;
    [SerializeField] private TrailRenderer trail;
    private AudioSource source;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player") && Tatu.podeMover)
        {
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        source.Play(0);
        tatu.AddForce(Vector3.up * pulo, ForceMode.Impulse); //Dá um pulo
        Physics.gravity = new Vector3(0, Physics.gravity.y, 0);
        Tatu.podeMover = false;
        trail.emitting = false;
        yield return new WaitForSeconds(timer);
        tatu.velocity = new Vector3(0, 0, 0); //Para o tatu
        tatu.transform.position = t.checkpoint; //Volta pro checkpoint
        ConfigGeral.mortesEspinho++;
        ConfigGeral.mortes++;
    }

    // Start is called before the first frame update
    void Start()
    {
        t = tatu.GetComponent<Tatu>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
