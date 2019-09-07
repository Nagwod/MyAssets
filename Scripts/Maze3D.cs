using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze3D : MonoBehaviour
{
    //Script da fase do labirinto 3D

    public float velocRotacao;
    public float rotacao;
    public Quaternion a;
    static public int controles;

    // Start is called before the first frame update
    void Start()
    {
        velocRotacao = 0.5f;
        rotacao = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        a = transform.rotation;

        switch (controles)
        {
            case 0:
                if (Input.GetKey("w") && transform.rotation[0] < rotacao)
                {
                    transform.Rotate(velocRotacao, 0, 0);
                }
                if (Input.GetKey("a") && transform.rotation[2] < rotacao)
                {
                    transform.Rotate(0, 0, velocRotacao);
                }
                if (Input.GetKey("s") && transform.rotation[0] > -rotacao)
                {
                    transform.Rotate(-velocRotacao, 0, 0);
                }
                if (Input.GetKey("d") && transform.rotation[2] > -rotacao)
                {
                    transform.Rotate(0, 0, -velocRotacao);
                }
                /*if (Input.GetKey("e") && transform.rotation[1] > -rotacao)
                {
                    transform.Rotate(0, -velocRotacao, 0);
                }
                if (Input.GetKey("q") && transform.rotation[1] < rotacao)
                {
                    transform.Rotate(0, velocRotacao, 0);
                }*/
                break;
            case 1:
                if (Input.GetKey("w") && transform.rotation[0] < (rotacao + 0.70711f))
                {
                    transform.Rotate(velocRotacao, 0, 0);
                }
                if (Input.GetKey("a") && transform.rotation[1] < rotacao)
                {
                    transform.Rotate(0, velocRotacao, 0);
                }
                if (Input.GetKey("s") && transform.rotation[0] > -rotacao + 0.70711f)
                {
                    transform.Rotate(-velocRotacao, 0, 0);
                }
                if (Input.GetKey("d") && transform.rotation[1] > -rotacao)
                {
                    transform.Rotate(0, -velocRotacao, 0);
                }
                break;
            case 2:
                if (Input.GetKey("a") && transform.rotation[0] < rotacao)
                {
                    transform.Rotate(velocRotacao, 0, 0);
                }
                if (Input.GetKey("s") && transform.rotation[2] < rotacao)
                {
                    transform.Rotate(0, 0, velocRotacao);
                }
                if (Input.GetKey("d") && transform.rotation[0] > -rotacao)
                {
                    transform.Rotate(-velocRotacao, 0, 0);
                }
                if (Input.GetKey("w") && transform.rotation[2] > -rotacao)
                {
                    transform.Rotate(0, 0, -velocRotacao);
                }
                break;
            case 3:
                if (Input.GetKey("s") && transform.rotation[0] < rotacao)
                {
                    transform.Rotate(velocRotacao, 0, 0);
                }
                if (Input.GetKey("d") && transform.rotation[2] < rotacao)
                {
                    transform.Rotate(0, 0, velocRotacao);
                }
                if (Input.GetKey("w") && transform.rotation[0] > -rotacao)
                {
                    transform.Rotate(-velocRotacao, 0, 0);
                }
                if (Input.GetKey("a") && transform.rotation[2] > -rotacao)
                {
                    transform.Rotate(0, 0, -velocRotacao);
                }
                break;
            case 4:
                if (Input.GetKey("s") && transform.rotation[0] < (rotacao - 0.70711f))
                {
                    transform.Rotate(velocRotacao, 0, 0);
                }
                if (Input.GetKey("a") && transform.rotation[1] < rotacao)
                {
                    transform.Rotate(0, velocRotacao, 0);
                }
                if (Input.GetKey("w") && transform.rotation[0] > -rotacao - 0.70711f)
                {
                    transform.Rotate(-velocRotacao, 0, 0);
                }
                if (Input.GetKey("d") && transform.rotation[1] > -rotacao)
                {
                    transform.Rotate(0, -velocRotacao, 0);
                }
                break;
            case 5:
                if (Input.GetKey("s") && transform.rotation[0] < (rotacao + 0.70711f))
                {
                    transform.Rotate(velocRotacao, 0, 0);
                }
                if (Input.GetKey("d") && transform.rotation[1] < rotacao)
                {
                    transform.Rotate(0, velocRotacao, 0);
                }
                if (Input.GetKey("w") && transform.rotation[0] > -rotacao + 0.70711f)
                {
                    transform.Rotate(-velocRotacao, 0, 0);
                }
                if (Input.GetKey("a") && transform.rotation[1] > -rotacao)
                {
                    transform.Rotate(0, -velocRotacao, 0);
                }
                break;
            case 6:
                if (Input.GetKey("d") && transform.rotation[0] < (rotacao - 0.70711f))
                {
                    transform.Rotate(velocRotacao, 0, 0);
                }
                if (Input.GetKey("s") && transform.rotation[1] < rotacao)
                {
                    transform.Rotate(0, velocRotacao, 0);
                }
                if (Input.GetKey("a") && transform.rotation[0] > -rotacao - 0.70711f)
                {
                    transform.Rotate(-velocRotacao, 0, 0);
                }
                if (Input.GetKey("w") && transform.rotation[1] > -rotacao)
                {
                    transform.Rotate(0, -velocRotacao, 0);
                }
                break;
            case 7:
                if (Input.GetKey("d") && transform.rotation[0] < (rotacao + 0.70711f))
                {
                    transform.Rotate(velocRotacao, 0, 0);
                }
                if (Input.GetKey("w") && transform.rotation[1] < rotacao)
                {
                    transform.Rotate(0, velocRotacao, 0);
                }
                if (Input.GetKey("a") && transform.rotation[0] > -rotacao + 0.70711f)
                {
                    transform.Rotate(-velocRotacao, 0, 0);
                }
                if (Input.GetKey("s") && transform.rotation[1] > -rotacao)
                {
                    transform.Rotate(0, -velocRotacao, 0);
                }
                break;
            case 8:
                if (Input.GetKey("w") && transform.rotation[0] < (rotacao - 0.70711f))
                {
                    transform.Rotate(velocRotacao, 0, 0);
                }
                if (Input.GetKey("d") && transform.rotation[1] < rotacao)
                {
                    transform.Rotate(0, velocRotacao, 0);
                }
                if (Input.GetKey("s") && transform.rotation[0] > -rotacao - 0.70711f)
                {
                    transform.Rotate(-velocRotacao, 0, 0);
                }
                if (Input.GetKey("a") && transform.rotation[1] > -rotacao)
                {
                    transform.Rotate(0, -velocRotacao, 0);
                }
                break;
            case 9:
                if (Input.GetKey("s") && transform.rotation[0] < rotacao)
                {
                    transform.Rotate(0, velocRotacao, 0);
                }
                if (Input.GetKey("d") && transform.rotation[2] < rotacao - 0.70711f)
                {
                    transform.Rotate(0, 0, velocRotacao);
                }
                if (Input.GetKey("w") && transform.rotation[0] > -rotacao)
                {
                    transform.Rotate(0, -velocRotacao, 0);
                }
                if (Input.GetKey("a") && transform.rotation[2] > -rotacao - 0.70711f)
                {
                    transform.Rotate(0, 0, -velocRotacao);
                }
                break;
            case 10:
                if (Input.GetKey("w") && transform.rotation[1] < rotacao)
                {
                    transform.Rotate(0, velocRotacao, 0);
                }
                if (Input.GetKey("d") && transform.rotation[2] < rotacao + 0.70711f)
                {
                    transform.Rotate(0, 0, velocRotacao);
                }
                if (Input.GetKey("s") && transform.rotation[1] > -rotacao)
                {
                    transform.Rotate(0, -velocRotacao, 0);
                }
                if (Input.GetKey("a") && transform.rotation[2] > -rotacao + 0.70711f)
                {
                    transform.Rotate(0, 0, -velocRotacao);
                }
                break;
            case 11:
                if (Input.GetKey("a") && transform.rotation[1] < rotacao)
                {
                    transform.Rotate(0, velocRotacao, 0);
                }
                if (Input.GetKey("w") && transform.rotation[2] < rotacao + 0.70711f)
                {
                    transform.Rotate(0, 0, velocRotacao);
                }
                if (Input.GetKey("d") && transform.rotation[1] > -rotacao)
                {
                    transform.Rotate(0, -velocRotacao, 0);
                }
                if (Input.GetKey("s") && transform.rotation[2] > -rotacao + 0.70711f)
                {
                    transform.Rotate(0, 0, -velocRotacao);
                }
                break;
            case 12:
                if (Input.GetKey("w") && transform.rotation[0] < rotacao)
                {
                    transform.Rotate(0, velocRotacao, 0);
                }
                if (Input.GetKey("a") && transform.rotation[2] < rotacao - 0.70711f)
                {
                    transform.Rotate(0, 0, velocRotacao);
                }
                if (Input.GetKey("s") && transform.rotation[0] > -rotacao)
                {
                    transform.Rotate(0, -velocRotacao, 0);
                }
                if (Input.GetKey("d") && transform.rotation[2] > -rotacao - 0.70711f)
                {
                    transform.Rotate(0, 0, -velocRotacao);
                }
                break;
            case 13:
                if (Input.GetKey("s") && transform.rotation[3] >  -rotacao)
                {
                    transform.Rotate(velocRotacao, 0, 0);
                }
                if (Input.GetKey("a") && transform.rotation[1] > -rotacao)
                {
                    transform.Rotate(0, 0, velocRotacao);
                }
                if (Input.GetKey("w") && transform.rotation[3] < rotacao)
                {
                    transform.Rotate(-velocRotacao, 0, 0);
                }
                if (Input.GetKey("d") && transform.rotation[1] < rotacao)
                {
                    transform.Rotate(0, 0, -velocRotacao);
                }
                break;
            case 14:
                if (Input.GetKey("w") && transform.rotation[3] > -rotacao)
                {
                    transform.Rotate(velocRotacao, 0, 0);
                }
                if (Input.GetKey("d") && transform.rotation[1] > -rotacao)
                {
                    transform.Rotate(0, 0, velocRotacao);
                }
                if (Input.GetKey("s") && transform.rotation[3] < rotacao)
                {
                    transform.Rotate(-velocRotacao, 0, 0);
                }
                if (Input.GetKey("a") && transform.rotation[1] < rotacao)
                {
                    transform.Rotate(0, 0, -velocRotacao);
                }
                break;
            case 15:
                if (Input.GetKey("a") && transform.rotation[3] > -rotacao)
                {
                    transform.Rotate(velocRotacao, 0, 0);
                }
                if (Input.GetKey("w") && transform.rotation[1] > -rotacao)
                {
                    transform.Rotate(0, 0, velocRotacao);
                }
                if (Input.GetKey("d") && transform.rotation[3] < rotacao)
                {
                    transform.Rotate(-velocRotacao, 0, 0);
                }
                if (Input.GetKey("s") && transform.rotation[1] < rotacao)
                {
                    transform.Rotate(0, 0, -velocRotacao);
                }
                break;
            case 16:
                if (Input.GetKey("d") && transform.rotation[1] < rotacao)
                {
                    transform.Rotate(0, velocRotacao, 0);
                }
                if (Input.GetKey("s") && transform.rotation[2] < rotacao + 0.70711f)
                {
                    transform.Rotate(0, 0, velocRotacao);
                }
                if (Input.GetKey("a") && transform.rotation[1] > -rotacao)
                {
                    transform.Rotate(0, -velocRotacao, 0);
                }
                if (Input.GetKey("w") && transform.rotation[2] > -rotacao + 0.70711f)
                {
                    transform.Rotate(0, 0, -velocRotacao);
                }
                break;
        }
    }
}
