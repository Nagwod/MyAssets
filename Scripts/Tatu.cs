using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tatu : MonoBehaviour
{
    [SerializeField] private Rigidbody rigid;
    [SerializeField] private Camera cam;
    [SerializeField] private Camera mapa;
    [SerializeField] private GameObject marcador;
    [SerializeField] private TrailRenderer trail;
    [SerializeField] private float velocidadex, velocidadez;
    [SerializeField] private float inclinaX, inclinaY;
    [SerializeField] private Vector3 velocidade;
    [SerializeField] private int altcam, altMinimapa, altMarcador;
    public Vector3 checkpoint;
    static public bool podeMover;
    private AudioSource source;
    private readonly int andar = 20, correr = 25;
    private readonly float max = 0.6f;
    

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

        if (transform.position.y < -200)
        {
            transform.position = checkpoint;
        }

        if (Time.timeScale != 0 && podeMover)
        {
            if (Input.acceleration.x != 0 || Input.acceleration.y != 0)
            {
                inclinaX = -Input.acceleration.x;
                inclinaY = -Input.acceleration.y - 0.2f;
                if (inclinaX >= max)
                {
                    inclinaX = max;
                    velocidadex = inclinaX * correr;
                }
                else
                {
                    if (inclinaX <= -max)
                    {
                        inclinaX = -max;
                        velocidadex = inclinaX * correr;
                    }
                    else
                    {
                        velocidadex = inclinaX * andar;
                    }
                }
                if (inclinaY >= max)
                {
                    inclinaY = max;
                    velocidadez = inclinaY * correr;
                }
                else
                {
                    if (inclinaY <= -max)
                    {
                        inclinaY = -max;
                        velocidadez = inclinaY * correr;
                    }
                    else
                    {
                        velocidadez = inclinaY * andar;
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
