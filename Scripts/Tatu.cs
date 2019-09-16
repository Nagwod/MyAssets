using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tatu : MonoBehaviour
{
    public Rigidbody rigid;
    public Camera cam;
    public Camera mapa;
    public GameObject marcador;
    public TrailRenderer trail;
    public float velocidadex, velocidadez;
    public Vector3 velocidade;
    public int altcam, altMinimapa, altMarcador;
    private AudioSource source;
    static public bool podeMover;
    public float x, y;
    private readonly int andar = 20, correr = 25;
    private readonly float max = 0.6f;
    public Vector3 checkpoint;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Parede"))
        {
            ConfigGeral.batidasParedes++;
        }
        if (collision.transform.CompareTag("Arvore"))
        {
            ConfigGeral.batidasArvores++;
        }
        if (collision.transform.CompareTag("Chao"))
        {
                podeMover = true;
                trail.emitting = true;
        }
    }

    public void SomMoeda() //Método chamado na classe Moeda
    {
        source.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0, Physics.gravity.y, 0);
        checkpoint = new Vector3(0, 5, 0);
        podeMover = false;
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        cam.transform.position = new Vector3(transform.position[0], transform.position[1] + altcam, transform.position[2]); //Controla a posição da câmera para acompanhar o tatu de cima
        mapa.transform.position = new Vector3(transform.position[0], altMinimapa, transform.position[2]);
        marcador.transform.position = new Vector3(transform.position[0], altMarcador, transform.position[2]);

        if (transform.position.y < -100)
        {
            transform.position = checkpoint;
        }

        if (Time.timeScale != 0 && podeMover)
        {
            if (Input.acceleration.x != 0 || Input.acceleration.y != 0)
            {
                x = -Input.acceleration.x;
                y = -Input.acceleration.y - 0.2f;
                if (x >= max)
                {
                    x = max;
                    velocidadex = x * correr;
                }
                else
                {
                    if (x <= -max)
                    {
                        x = -max;
                        velocidadex = x * correr;
                    }
                    else
                    {
                        velocidadex = x * andar;
                    }
                }
                if (y >= max)
                {
                    y = max;
                    velocidadez = y * correr;
                }
                else
                {
                    if (y <= -max)
                    {
                        y = -max;
                        velocidadez = y * correr;
                    }
                    else
                    {
                        velocidadez = y * andar;
                    }
                }
                Physics.gravity = new Vector3(velocidadex, Physics.gravity.y, velocidadez);
                //tatu.velocity = new Vector3(velocidadex, tatu.velocity.y, velocidadez);
            }

            if (Input.GetKey("up") && rigid.velocity.z > -5)
            {
                rigid.velocity = new Vector3(rigid.velocity.x, rigid.velocity.y, rigid.velocity.z - 0.4f);
            }
            if (Input.GetKey("down") && rigid.velocity.z < 5)
            {
                rigid.velocity = new Vector3(rigid.velocity.x, rigid.velocity.y, rigid.velocity.z + 0.4f);
            }
            if (Input.GetKey("right") && rigid.velocity.x > -5)
            {
                rigid.velocity = new Vector3(rigid.velocity.x - 0.4f, rigid.velocity.y, rigid.velocity.z);
            }
            if (Input.GetKey("left") && rigid.velocity.x < 5)
            {
                rigid.velocity = new Vector3(rigid.velocity.x + 0.4f, rigid.velocity.y, rigid.velocity.z);
            }

            velocidade = rigid.velocity;

            //float h = Input.GetAxis("Horizontal");
            //float v = Input.GetAxis("Vertical");
            //Physics.gravity = new Vector3(-h*5, Physics.gravity.y, -v*5);
        }
    }
}
