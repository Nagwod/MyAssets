using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espinho : MonoBehaviour
{
    public int pulo;
    public float timer;
    Tatu t;
    public Rigidbody player;
    private AudioSource source;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        source.Play(0);
        player.AddForce(Vector3.up * pulo, ForceMode.Impulse); //Dá um pulo
        Physics.gravity = new Vector3(0, Physics.gravity.y, 0);
        Tatu.podeMover = false;
        yield return new WaitForSeconds(timer);
        player.velocity = new Vector3(0, 0, 0); //Para o tatu
        player.transform.position = t.checkpoint; //Volta pro checkpoint
    }

    // Start is called before the first frame update
    void Start()
    {
        t = player.GetComponent<Tatu>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
