using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tatu : MonoBehaviour
{
    public Rigidbody tatu;
    public Camera cam;
    public Camera mapa;
    public GameObject marcador;
    public float velocidadex, velocidadez;
    public Vector3 velocidade;
    public int altcam, altMinimapa, altMarcador;
    private AudioSource source;
    static public bool podeMover;
    public float x, y;
    private readonly int andar = 20, correr = 25;
    private readonly float max = 0.6f;
    public Vector3 checkpoint;

    public void SomMoeda() //Método chamado na classe Moeda
    {
        source.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0, Physics.gravity.y, 0);
        checkpoint = new Vector3(0, 0, 0);
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
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name); //Qando cair abaixo de -100, reinicia a cena
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

            if (Input.GetKey("up") && tatu.velocity.z > -5)
            {
                tatu.velocity = new Vector3(tatu.velocity.x, tatu.velocity.y, tatu.velocity.z - 0.4f);
            }
            if (Input.GetKey("down") && tatu.velocity.z < 5)
            {
                tatu.velocity = new Vector3(tatu.velocity.x, tatu.velocity.y, tatu.velocity.z + 0.4f);
            }
            if (Input.GetKey("right") && tatu.velocity.x > -5)
            {
                tatu.velocity = new Vector3(tatu.velocity.x - 0.4f, tatu.velocity.y, tatu.velocity.z);
            }
            if (Input.GetKey("left") && tatu.velocity.x < 5)
            {
                tatu.velocity = new Vector3(tatu.velocity.x + 0.4f, tatu.velocity.y, tatu.velocity.z);
            }

            velocidade = tatu.velocity;

            //float h = Input.GetAxis("Horizontal");
            //float v = Input.GetAxis("Vertical");
            //Physics.gravity = new Vector3(-h*5, Physics.gravity.y, -v*5);
        }
    }
}
