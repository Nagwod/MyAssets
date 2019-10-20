using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cai : MonoBehaviour
{
    Tatu t;
    public Rigidbody tatu;
    private AudioSource source;
    public TrailRenderer trail;
    public bool buraco;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Tatu.podeMover)
        {
            if (buraco) //Verifica se é buraco ou não
            {
                StartCoroutine(Gira());
            }
            else
            {
                StartCoroutine(Espera());
            }
        }
    }

    IEnumerator Gira() //Morte em buraco
    {
        trail.emitting = false;
        Physics.gravity = new Vector3(0, Physics.gravity.y, 0);
        tatu.velocity = new Vector3(0, -2, 0);
        tatu.transform.position = new Vector3(transform.position.x, transform.position.y+1, transform.position.z);
        Tatu.podeMover = false;
        yield return new WaitForSeconds(0.1f);
        source.Play(0);
        tatu.velocity = new Vector3(1, tatu.velocity.y, 1);
        yield return new WaitForSeconds(0.2f);
        tatu.velocity = new Vector3(1, tatu.velocity.y, -1);
        yield return new WaitForSeconds(0.2f);
        tatu.velocity = new Vector3(-1, tatu.velocity.y, -1);
        yield return new WaitForSeconds(0.2f);
        tatu.velocity = new Vector3(-1, tatu.velocity.y, 1);
        yield return new WaitForSeconds(0.2f);
        tatu.velocity = new Vector3(1, tatu.velocity.y, 1);
        yield return new WaitForSeconds(0.2f);
        tatu.velocity = new Vector3(0, 0, 0);
        tatu.transform.position = t.checkpoint;
        ConfigGeral.mortesBuraco++;
        ConfigGeral.mortes++;
    }

    IEnumerator Espera() //Morte por queda
    {
        source.Play(0);
        Tatu.podeMover = false;
        yield return new WaitForSeconds(1);
        trail.emitting = false;
        yield return new WaitForSeconds(0.2f);
        Physics.gravity = new Vector3(0, Physics.gravity.y, 0);
        Tatu.podeMover = false;
        tatu.velocity = new Vector3(0, 0, 0);
        tatu.transform.position = t.checkpoint;
        ConfigGeral.mortesQueda++;
        ConfigGeral.mortes++;
    }

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        t = tatu.GetComponent<Tatu>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
