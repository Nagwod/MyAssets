﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cai : MonoBehaviour
{
    Tatu t;
    [SerializeField] private Rigidbody tatu;
    [SerializeField] private TrailRenderer trail;
    [SerializeField] private bool buraco;
    private AudioSource source;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Tatu.vivo)
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
        Tatu.vivo = false;
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
        Tatu.vivo = true;
        ConfigGeral.mortesBuraco++;
        ConfigGeral.mortes++;
    }

    IEnumerator Espera() //Morte por queda
    {
        source.Play(0);
        Tatu.podeMover = false;
        Tatu.vivo = false;
        yield return new WaitForSeconds(1);
        trail.emitting = false;
        yield return new WaitForSeconds(0.2f);
        Physics.gravity = new Vector3(0, Physics.gravity.y, 0);
        Tatu.podeMover = false;
        tatu.velocity = new Vector3(0, 0, 0);
        tatu.transform.position = t.checkpoint;
        Tatu.vivo = true;
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
