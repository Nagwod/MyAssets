using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detecao : MonoBehaviour
{
    //Script da fase do labirinto 3D para mudar a câmera

    public int area;
    public int posicao;
    public Camera cam;
    public GameObject luz;
    public GameObject mapa;
    public GameObject player;

    public void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            switch (area)
            {
                case 1:
                    if (cam.transform.position != new Vector3(6, 16, -11))
                    {
                        mapa.transform.rotation = Quaternion.identity;
                        player.transform.position = new Vector3(player.transform.position[0], 1, player.transform.position[2]);
                        switch (posicao)
                        {
                            case 3:
                                player.transform.position = new Vector3(3, 1, -4);
                                break;
                            case 6:
                                player.transform.position = new Vector3(7, 1, -1.5f);
                                break;
                        }
                    }
                    cam.transform.position = new Vector3(6, 16, -11);
                    cam.transform.rotation = Quaternion.identity;
                    cam.transform.Rotate(60, 0, 0);
                    luz.transform.rotation = Quaternion.identity;
                    luz.transform.Rotate(60, -45, 0);
                    Maze3D.controles = 0;
                    break;
                case 2:
                    if (cam.transform.position != new Vector3(6, 16, 11))
                    {
                        mapa.transform.rotation = Quaternion.identity;
                        mapa.transform.Rotate(90, 0, 0);
                        player.transform.position = new Vector3(player.transform.position[0], 1, player.transform.position[2]);
                        switch (posicao)
                        {
                            case 0:
                                player.transform.position = new Vector3(7, 1, 1.5f);
                                break;
                            case 2:
                                player.transform.position = new Vector3(1.5f, 1, 5);
                                break;
                            case 3:
                                player.transform.position = new Vector3(1.5f, 1, 7);
                                break;
                            case 4:
                                player.transform.position = new Vector3(4, 1, 9);
                                break;
                            case 5:
                                player.transform.position = new Vector3(9, 1, 4);
                                break;
                            case 6:
                                player.transform.position = new Vector3(8, 1, 5);
                                break;
                            case 7:
                                player.transform.position = new Vector3(4, 1, 5);
                                break;
                        }
                    }
                    cam.transform.position = new Vector3(6, 16, 11);
                    cam.transform.rotation = Quaternion.identity;
                    cam.transform.Rotate(60, 180, 0);
                    luz.transform.rotation = Quaternion.identity;
                    luz.transform.Rotate(120, 30, 0);
                    Maze3D.controles = 5;
                    break;
                case 3:
                    if (cam.transform.position != new Vector3(-11, 16, -6))
                    {
                        mapa.transform.rotation = Quaternion.identity;
                        mapa.transform.Rotate(0, 0, 90);
                        player.transform.position = new Vector3(player.transform.position[0], 1, player.transform.position[2]);
                        switch (posicao)
                        {
                            case 0:
                                player.transform.position = new Vector3(-8, 1, -2);
                                break;
                            case 1:
                                player.transform.position = new Vector3(-8, 1, -4);
                                break;
                            case 2:
                                player.transform.position = new Vector3(-8, 1, -6);
                                break;
                            case 3:
                                player.transform.position = new Vector3(-9, 1, -9);
                                break;
                            case 4:
                                player.transform.position = new Vector3(-7, 1, -1.5f);
                                break;
                            case 5:
                                player.transform.position = new Vector3(-5, 1, -1.5f);
                                break;
                        }
                        cam.transform.position = new Vector3(-11, 16, -6);
                        cam.transform.rotation = Quaternion.identity;
                        cam.transform.Rotate(60, 90, 0);
                        Maze3D.controles = 16;
                    }
                    luz.transform.rotation = Quaternion.identity;
                    luz.transform.Rotate(60, 45, 0);
                    break;
                case 4:
                    if (cam.transform.position != new Vector3(-6, 8, -6) && cam.transform.position != new Vector3(-11, 16, -6) && cam.transform.position != new Vector3(-5, 6, -4))
                    {
                        mapa.transform.rotation = Quaternion.identity;
                        player.transform.position = new Vector3(player.transform.position[0], 1, player.transform.position[2]);
                        switch (posicao)
                        {
                            case 0:
                                cam.transform.position = new Vector3(-6, 8, -6);
                                break;
                            case 1:
                                cam.transform.position = new Vector3(-11, 16, -6);
                                break;
                            case 2:
                                player.transform.position = new Vector3(-1.5f, 1, -3);
                                cam.transform.position = new Vector3(-11, 16, -6);
                                break;
                            case 3:
                                player.transform.position = new Vector3(-7, 1, -1.5f);
                                cam.transform.position = new Vector3(-11, 16, -6);
                                break;
                            case 4:
                                player.transform.position = new Vector3(-9, 1, -6);
                                cam.transform.position = new Vector3(-11, 16, -6);
                                break;
                            case 5:
                                player.transform.position = new Vector3(-9, 1, -8);
                                cam.transform.position = new Vector3(-11, 16, -6);
                                break;
                            case 6:
                                player.transform.position = new Vector3(-5, 1, -9);
                                cam.transform.position = new Vector3(-11, 16, -6);
                                break;
                            case 7:
                                player.transform.position = new Vector3(-4, 1, -6);
                                cam.transform.position = new Vector3(-11, 16, -6);
                                break;
                            case 8:
                                player.transform.position = new Vector3(-2, 1, -9);
                                cam.transform.position = new Vector3(-11, 16, -6);
                                break;
                            case 9:
                                cam.transform.position = new Vector3(-5, 6, -4);
                                break;
                        }
                        cam.transform.rotation = Quaternion.identity;
                        cam.transform.Rotate(60, 90, 0);
                        Maze3D.controles = 2;
                    }
                    luz.transform.rotation = Quaternion.identity;
                    luz.transform.Rotate(60, 45, 0);
                    break;
                case 5:
                    if (cam.transform.position != new Vector3(-6, 16, 11))
                    {
                        mapa.transform.rotation = Quaternion.identity;
                        mapa.transform.Rotate(90, 0, 0);
                        player.transform.position = new Vector3(player.transform.position[0], 1, player.transform.position[2]);
                        switch (posicao)
                        {
                            case 1:
                                player.transform.position = new Vector3(-9, 1, 2);
                                break;
                            case 2:
                                player.transform.position = new Vector3(-4, 1, 7);
                                break;
                            case 3:
                                player.transform.position = new Vector3(-7, 1, 1.5f);
                                break;
                            case 4:
                                player.transform.position = new Vector3(-1.5f, 1, 4);
                                break;
                            case 5:
                                player.transform.position = new Vector3(-2, 1, 7);
                                break;
                            case 6:
                                player.transform.position = new Vector3(-9, 1, 6);
                                break;
                        }
                    }
                    cam.transform.position = new Vector3(-6, 16, 11);
                    cam.transform.rotation = Quaternion.identity;
                    cam.transform.Rotate(60, 180, 0);
                    luz.transform.rotation = Quaternion.identity;
                    luz.transform.Rotate(60, -200, 0);
                    Maze3D.controles = 5;
                    break;
                case 6:
                    if (cam.transform.position != new Vector3(6, 16, -11))
                    {
                        mapa.transform.rotation = Quaternion.identity;
                        mapa.transform.Rotate(0, 0, -90);
                        player.transform.position = new Vector3(player.transform.position[0], 1, player.transform.position[2]);
                        switch (posicao)
                        {
                            case 0:
                                player.transform.position = new Vector3(8, 1, -2);
                                break;
                            case 1:
                                player.transform.position = new Vector3(8, 1, -4);
                                break;
                            case 2:
                                player.transform.position = new Vector3(8, 1, -6);
                                break;
                            case 3:
                                player.transform.position = new Vector3(9, 1, -9);
                                break;
                            case 4:
                                player.transform.position = new Vector3(4, 1, -1.5f);
                                break;
                            case 5:
                                player.transform.position = new Vector3(1.5f, 1, -3);
                                break;
                        }
                    }
                    cam.transform.position = new Vector3(6, 16, -11);
                    cam.transform.rotation = Quaternion.identity;
                    cam.transform.Rotate(60, 0, 0);
                    luz.transform.rotation = Quaternion.identity;
                    luz.transform.Rotate(60, -45, 0);
                    Maze3D.controles = 12;
                    break;
                case 7:
                    if (cam.transform.position != new Vector3(5, 6, 5) && cam.transform.position != new Vector3(7, 16, 11))
                    {
                        mapa.transform.rotation = Quaternion.identity;
                        player.transform.position = new Vector3(player.transform.position[0], 1, player.transform.position[2]);
                        switch (posicao)
                        {
                            case 0:
                                cam.transform.position = new Vector3(5, 6, 5);
                                break;
                            case 1:
                                cam.transform.position = new Vector3(7, 16, 11);
                                break;
                            case 2:
                                cam.transform.position = new Vector3(7, 16, 11);
                                break;
                            case 3:
                                cam.transform.position = new Vector3(7, 16, 11);
                                break;
                            case 4:
                                player.transform.position = new Vector3(1.5f, 1, 8);
                                cam.transform.position = new Vector3(7, 16, 11);
                                break;
                            case 5:
                                player.transform.position = new Vector3(4, 1, 7);
                                cam.transform.position = new Vector3(7, 16, 11);
                                break;
                            case 6:
                                player.transform.position = new Vector3(5, 1, 4);
                                cam.transform.position = new Vector3(7, 16, 11);
                                break;
                            case 7:
                                player.transform.position = new Vector3(8, 1, 2);
                                cam.transform.position = new Vector3(7, 16, 11);
                                break;
                            case 8:
                                player.transform.position = new Vector3(2, 1, 6);
                                cam.transform.position = new Vector3(7, 16, 11);
                                break;
                        }
                    }
                    cam.transform.rotation = Quaternion.identity;
                    cam.transform.Rotate(60, 180, 0);
                    luz.transform.rotation = Quaternion.identity;
                    luz.transform.Rotate(60, 200, 0);
                    Maze3D.controles = 3;
                    break;
                case 8:
                    if (cam.transform.position != new Vector3(6, 16, -11))
                    {
                        mapa.transform.rotation = Quaternion.identity;
                        mapa.transform.Rotate(-90, 0, 0);
                        player.transform.position = new Vector3(player.transform.position[0], 1, player.transform.position[2]);
                        switch (posicao)
                        {
                            case 1:
                                player.transform.position = new Vector3(3, 1, -8);
                                break;
                            case 2:
                                player.transform.position = new Vector3(5, 1, -6);
                                break;
                            case 3:
                                player.transform.position = new Vector3(7, 1, -6);
                                break;
                            case 4:
                                player.transform.position = new Vector3(9, 1, -4);
                                break;
                        }
                    }
                    cam.transform.position = new Vector3(6, 16, -11);
                    cam.transform.rotation = Quaternion.identity;
                    cam.transform.Rotate(60, 0, 0);
                    luz.transform.rotation = Quaternion.identity;
                    luz.transform.Rotate(60, -45, 0);
                    Maze3D.controles = 8;
                    break;
                case 9:
                    if (cam.transform.position != new Vector3(-6, 16, 11))
                    {
                        mapa.transform.rotation = Quaternion.identity;
                        mapa.transform.Rotate(0, 0, 90);
                        player.transform.position = new Vector3(player.transform.position[0], 1, player.transform.position[2]);
                        switch (posicao)
                        {
                            case 0:
                                player.transform.position = new Vector3(-6, 1, 3);
                                break;
                            case 1:
                                player.transform.position = new Vector3(-7, 1, 5);
                                break;
                            case 2:
                                player.transform.position = new Vector3(-9, 1, 8);
                                break;
                            case 3:
                                player.transform.position = new Vector3(-5, 1, 5);
                                break;
                            case 5:
                                player.transform.position = new Vector3(-1.5f, 1, 8);
                                break;
                        }
                    }
                    cam.transform.position = new Vector3(-6, 16, 11);
                    cam.transform.rotation = Quaternion.identity;
                    cam.transform.Rotate(60, 180, 0);
                    luz.transform.rotation = Quaternion.identity;
                    luz.transform.Rotate(60, -200, 0);
                    Maze3D.controles = 10;
                    break;
                case 10:
                    if (cam.transform.position != new Vector3(-6, 16, 11))
                    {
                        mapa.transform.rotation = Quaternion.identity;
                        player.transform.position = new Vector3(player.transform.position[0], 1, player.transform.position[2]);
                        switch (posicao)
                        {
                            case 2:
                                player.transform.position = new Vector3(-9, 1, 4);
                                break;
                            case 3:
                                player.transform.position = new Vector3(-9, 1, 8);
                                break;
                            case 4:
                                player.transform.position = new Vector3(-3, 1, 8);
                                break;
                        }
                    }
                    cam.transform.position = new Vector3(-6, 16, 11);
                    cam.transform.rotation = Quaternion.identity;
                    cam.transform.Rotate(60, 180, 0);
                    luz.transform.rotation = Quaternion.identity;
                    luz.transform.Rotate(60, -225, 0);
                    Maze3D.controles = 3;
                    break;
                case 11:
                    if (cam.transform.position != new Vector3(-6, 16, -11))
                    {
                        mapa.transform.rotation = Quaternion.identity;
                        mapa.transform.Rotate(-90, 0, 0);
                        player.transform.position = new Vector3(player.transform.position[0], 1, player.transform.position[2]);
                        switch (posicao)
                        {
                            case 1:
                                player.transform.position = new Vector3(-9, 1, -2);
                                break;
                            case 2:
                                player.transform.position = new Vector3(-5, 1, -6);
                                break;
                            case 3:
                                player.transform.position = new Vector3(-1.5f, 1, -4);
                                break;
                            case 4:
                                player.transform.position = new Vector3(-9, 1, -6);
                                break;
                            case 5:
                                player.transform.position = new Vector3(-2, 1, -7);
                                break;
                            case 6:
                                player.transform.position = new Vector3(-1.5f, 1, -9);
                                break;
                        }
                    }
                    cam.transform.position = new Vector3(-6, 16, -11);
                    cam.transform.rotation = Quaternion.identity;
                    cam.transform.Rotate(60, 0, 0);
                    luz.transform.rotation = Quaternion.identity;
                    luz.transform.Rotate(60, 45, 0);
                    Maze3D.controles = 8;
                    break;
                case 12:
                    if (cam.transform.position != new Vector3(8, 16, 11))
                    {
                        mapa.transform.rotation = Quaternion.identity;
                        mapa.transform.Rotate(0, 0, -90);
                        player.transform.position = new Vector3(player.transform.position[0], 1, player.transform.position[2]);
                        switch (posicao)
                        {
                            case 0:
                                player.transform.position = new Vector3(4, 1, 1.5f);
                                break;
                            case 1:
                                player.transform.position = new Vector3(6, 1, 3);
                                break;
                            case 3:
                                player.transform.position = new Vector3(9, 1, 1.5f);
                                break;
                            case 5:
                                player.transform.position = new Vector3(8, 1, 6);
                                break;
                            case 6:
                                player.transform.position = new Vector3(4, 1, 6);
                                break;
                            case 7:
                                player.transform.position = new Vector3(9, 1, 8);
                                break;
                        }
                    }
                    cam.transform.position = new Vector3(8, 16, 11);
                    cam.transform.rotation = Quaternion.identity;
                    cam.transform.Rotate(60, 180, 0);
                    luz.transform.rotation = Quaternion.identity;
                    luz.transform.Rotate(60, 200, 0);
                    Maze3D.controles = 9;
                    break;
                case 13:
                    if (cam.transform.position != new Vector3(7, 16, 11))
                    {
                        mapa.transform.rotation = Quaternion.identity;
                        mapa.transform.Rotate(180, 0, 0);
                        player.transform.position = new Vector3(player.transform.position[0], 1, player.transform.position[2]);
                        switch (posicao)
                        {
                            case 0:
                                player.transform.position = new Vector3(1.5f, 1, 7);
                                break;
                            case 2:
                                player.transform.position = new Vector3(4, 1, 3);
                                break;
                        }
                    }
                    cam.transform.position = new Vector3(7, 16, 11);
                    cam.transform.rotation = Quaternion.identity;
                    cam.transform.Rotate(60, 180, 0);
                    luz.transform.rotation = Quaternion.identity;
                    luz.transform.Rotate(60, 200, 0);
                    Maze3D.controles = 13;
                    break;
                case 14:
                    if (cam.transform.position != new Vector3(6, 16, -11) && cam.transform.position != new Vector3(5, 6, -4))
                    {
                        mapa.transform.rotation = Quaternion.identity;
                        mapa.transform.Rotate(90, 0, 0);
                        player.transform.position = new Vector3(player.transform.position[0], 1, player.transform.position[2]);
                        switch (posicao)
                        {
                            case 0:
                                cam.transform.position = new Vector3(6, 16, -11);
                                cam.transform.rotation = Quaternion.identity;
                                cam.transform.Rotate(60, 0, 0);
                                Maze3D.controles = 1;
                                break;
                            case 1:
                                player.transform.position = new Vector3(8, 1, -4);
                                cam.transform.position = new Vector3(6, 16, -11);
                                cam.transform.rotation = Quaternion.identity;
                                cam.transform.Rotate(60, 0, 0);
                                Maze3D.controles = 1;
                                break;
                            case 2:
                                player.transform.position = new Vector3(6, 1, -2);
                                cam.transform.position = new Vector3(6, 16, -11);
                                cam.transform.rotation = Quaternion.identity;
                                cam.transform.Rotate(60, 0, 0);
                                Maze3D.controles = 1;
                                break;
                            case 3:
                                cam.transform.position = new Vector3(5, 6, -4);
                                cam.transform.rotation = Quaternion.identity;
                                cam.transform.Rotate(60, -60, 0);
                                Maze3D.controles = 7;
                                break;
                            case 4:
                                player.transform.position = new Vector3(1, 1, -2);
                                cam.transform.position = new Vector3(5, 6, -4);
                                cam.transform.position = new Vector3(5, 6, -4);
                                cam.transform.rotation = Quaternion.identity;
                                cam.transform.Rotate(60, -60, 0);
                                Maze3D.controles = 7;
                                break;
                            case 5:
                                player.transform.position = new Vector3(6, 1, -7);
                                cam.transform.position = new Vector3(6, 16, -11);
                                cam.transform.rotation = Quaternion.identity;
                                cam.transform.Rotate(60, 0, 0);
                                Maze3D.controles = 1;
                                break;
                            case 6:
                                player.transform.position = new Vector3(4, 1, -6);
                                cam.transform.position = new Vector3(6, 16, -11);
                                cam.transform.rotation = Quaternion.identity;
                                cam.transform.Rotate(60, 0, 0);
                                Maze3D.controles = 1;
                                break;
                            case 7:
                                player.transform.position = new Vector3(1.5f, 1, -9);
                                cam.transform.position = new Vector3(6, 16, -11);
                                cam.transform.rotation = Quaternion.identity;
                                cam.transform.Rotate(60, 0, 0);
                                Maze3D.controles = 1;
                                break;
                        }
                        luz.transform.rotation = Quaternion.identity;
                        luz.transform.Rotate(60, -45, 0);
                    }
                    break;
                case 15:
                    if (cam.transform.position != new Vector3(11, 16, -6))
                    {
                        mapa.transform.rotation = Quaternion.identity;
                        mapa.transform.Rotate(0, 0, 90);
                        player.transform.position = new Vector3(player.transform.position[0], 1, player.transform.position[2]);
                        switch (posicao)
                        {
                            case 0:
                                player.transform.position = new Vector3(9, 1, -1.5f);
                                break;
                            case 1:
                                player.transform.position = new Vector3(9, 1, -6);
                                break;
                            case 2:
                                player.transform.position = new Vector3(8, 1, -5);
                                break;
                            case 3:
                                player.transform.position = new Vector3(8, 1, -9);
                                break;
                            case 4:
                                player.transform.position = new Vector3(6, 1, -7);
                                break;
                            case 5:
                                player.transform.position = new Vector3(7, 1, -2);
                                break;
                            case 6:
                                player.transform.position = new Vector3(3, 1, -4);
                                break;
                            case 8:
                                player.transform.position = new Vector3(1.5f, 1, -7);
                                break;
                        }
                    }
                    cam.transform.position = new Vector3(11, 16, -6);
                    cam.transform.rotation = Quaternion.identity;
                    cam.transform.Rotate(60, -90, 0);
                    luz.transform.rotation = Quaternion.identity;
                    luz.transform.Rotate(60, -45, 0);
                    Maze3D.controles = 11;
                    break;
                case 16:
                    if (cam.transform.position != new Vector3(8, 16, 11))
                    {
                        mapa.transform.rotation = Quaternion.identity;
                        mapa.transform.Rotate(0, 0, 90);
                        player.transform.position = new Vector3(player.transform.position[0], 1, player.transform.position[2]);
                        switch (posicao)
                        {
                            case 0:
                                player.transform.position = new Vector3(4, 1, 6);
                                break;
                            case 1:
                                player.transform.position = new Vector3(8, 1, 9);
                                break;
                            case 2:
                                player.transform.position = new Vector3(9, 1, 4);
                                break;
                            case 3:
                                player.transform.position = new Vector3(7, 1, 1.5f);
                                break;
                        }
                    }
                    cam.transform.position = new Vector3(8, 16, 11);
                    cam.transform.rotation = Quaternion.identity;
                    cam.transform.Rotate(60, 180, 0);
                    luz.transform.rotation = Quaternion.identity;
                    luz.transform.Rotate(120, 30, 0);
                    Maze3D.controles = 10;
                    break;
                case 17:
                    if (cam.transform.position != new Vector3(6, 16, 11) && cam.transform.position != new Vector3(5, 7, 4))
                    {
                        mapa.transform.rotation = Quaternion.identity;
                        mapa.transform.Rotate(-90, 0, 0);
                        player.transform.position = new Vector3(player.transform.position[0], 1, player.transform.position[2]);
                        switch (posicao)
                        {
                            case 0:
                                player.transform.position = new Vector3(8, 1, 4);
                                cam.transform.position = new Vector3(6, 16, 11);
                                cam.transform.rotation = Quaternion.identity;
                                cam.transform.Rotate(60, 180, 0);
                                Maze3D.controles = 4;
                                break;
                            case 1:
                                player.transform.position = new Vector3(6, 1, 2);
                                cam.transform.position = new Vector3(6, 16, 11);
                                cam.transform.rotation = Quaternion.identity;
                                cam.transform.Rotate(60, 180, 0);
                                Maze3D.controles = 4;
                                break;
                            case 2:
                                cam.transform.position = new Vector3(6, 16, 11);
                                cam.transform.rotation = Quaternion.identity;
                                cam.transform.Rotate(60, 180, 0);
                                Maze3D.controles = 4;
                                break;
                            case 3:
                                cam.transform.position = new Vector3(6, 16, 11);
                                cam.transform.rotation = Quaternion.identity;
                                cam.transform.Rotate(60, 180, 0);
                                Maze3D.controles = 4;
                                break;
                            case 4:
                                player.transform.position = new Vector3(1, 1, 2);
                                cam.transform.position = new Vector3(5, 7, 4);
                                cam.transform.rotation = Quaternion.identity;
                                cam.transform.Rotate(60, 250, 0);
                                Maze3D.controles = 6;
                                break;
                            case 5:
                                cam.transform.position = new Vector3(5, 7, 4);
                                cam.transform.rotation = Quaternion.identity;
                                cam.transform.Rotate(60, 250, 0);
                                Maze3D.controles = 6;
                                break;
                            case 6:
                                player.transform.position = new Vector3(1.5f, 1, 7);
                                cam.transform.position = new Vector3(6, 16, 11);
                                cam.transform.rotation = Quaternion.identity;
                                cam.transform.Rotate(60, 180, 0);
                                Maze3D.controles = 4;
                                break;
                            case 7:
                                player.transform.position = new Vector3(5, 1, 6);
                                cam.transform.position = new Vector3(6, 16, 11);
                                cam.transform.rotation = Quaternion.identity;
                                cam.transform.Rotate(60, 180, 0);
                                Maze3D.controles = 4;
                                break;
                            case 8:
                                player.transform.position = new Vector3(3, 1, 7);
                                cam.transform.position = new Vector3(6, 16, 11);
                                cam.transform.rotation = Quaternion.identity;
                                cam.transform.Rotate(60, 180, 0);
                                Maze3D.controles = 4;
                                break;
                        }
                        luz.transform.rotation = Quaternion.identity;
                        luz.transform.Rotate(60, -150, 0);
                    }
                    break;
                case 18:
                    if (cam.transform.position != new Vector3(6, 16, -11))
                    {
                        mapa.transform.rotation = Quaternion.identity;
                        mapa.transform.Rotate(180, 0, 0);
                        player.transform.position = new Vector3(player.transform.position[0], 1, player.transform.position[2]);
                        switch (posicao)
                        {
                            case 0:
                                player.transform.position = new Vector3(5, 1, -4);
                                break;
                            case 1:
                                player.transform.position = new Vector3(5, 1, -6);
                                break;
                            case 2:
                                player.transform.position = new Vector3(2, 1, -6);
                                break;
                            case 3:
                                player.transform.position = new Vector3(8, 1, -2);
                                break;
                        }
                    }
                    cam.transform.position = new Vector3(6, 16, -11);
                    cam.transform.rotation = Quaternion.identity;
                    cam.transform.Rotate(60, 0, 0);
                    luz.transform.rotation = Quaternion.identity;
                    luz.transform.Rotate(60, -45, 0);
                    Maze3D.controles = 14;
                    break;
                case 19:
                    if (cam.transform.position != new Vector3(-6, 16, 11))
                    {
                        mapa.transform.rotation = Quaternion.identity;
                        mapa.transform.Rotate(0, 0, -90);
                        player.transform.position = new Vector3(player.transform.position[0], 1, player.transform.position[2]);
                        switch (posicao)
                        {
                            case 1:
                                player.transform.position = new Vector3(-4, 1, 6);
                                break;
                            case 2:
                                player.transform.position = new Vector3(-8, 1, 9);
                                break;
                            case 3:
                                player.transform.position = new Vector3(-9, 1, 4);
                                break;
                            case 5:
                                player.transform.position = new Vector3(-1.5f, 1, 6);
                                break;
                        }
                    }
                    cam.transform.position = new Vector3(-6, 16, 11);
                    cam.transform.rotation = Quaternion.identity;
                    cam.transform.Rotate(60, 180, 0);
                    luz.transform.rotation = Quaternion.identity;
                    luz.transform.Rotate(60, -200, 0);
                    Maze3D.controles = 9;
                    break;
                case 20:
                    if (cam.transform.position != new Vector3(-6, 16, 11))
                    {
                        mapa.transform.rotation = Quaternion.identity;
                        mapa.transform.Rotate(-90, 0, 0);
                        player.transform.position = new Vector3(player.transform.position[0], 1, player.transform.position[2]);
                        switch (posicao)
                        {
                            case 1:
                                player.transform.position = new Vector3(-3, 1, 8);
                                break;
                            case 2:
                                player.transform.position = new Vector3(-3, 1, 8);
                                break;
                            case 3:
                                player.transform.position = new Vector3(-3, 1, 6);
                                break;
                            case 4:
                                player.transform.position = new Vector3(-3, 1, 6);
                                break;
                            case 6:
                                player.transform.position = new Vector3(-6, 1, 5);
                                break;
                            case 7:
                                player.transform.position = new Vector3(-9, 1, 8);
                                break;
                            case 8:
                                player.transform.position = new Vector3(-7, 1, 9);
                                break;
                            case 9:
                                player.transform.position = new Vector3(-7, 1, 2);
                                break;
                            case 11:
                                player.transform.position = new Vector3(-9, 1, 1.5f);
                                break;
                        }
                    }
                    cam.transform.position = new Vector3(-6, 16, 11);
                    cam.transform.rotation = Quaternion.identity;
                    cam.transform.Rotate(60, 180, 0);
                    luz.transform.rotation = Quaternion.identity;
                    luz.transform.Rotate(60, -200, 0);
                    Maze3D.controles = 4;
                    break;
                case 21:
                    if (cam.transform.position != new Vector3(-11, 16, -6))
                    {
                        mapa.transform.rotation = Quaternion.identity;
                        mapa.transform.Rotate(180, 0, 0);
                        player.transform.position = new Vector3(player.transform.position[0], 1, player.transform.position[2]);
                        switch (posicao)
                        {
                            case 0:
                                player.transform.position = new Vector3(-1.5f, 1, -6);
                                break;
                            case 1:
                                player.transform.position = new Vector3(-9, 1, -8);
                                break;
                            case 2:
                                player.transform.position = new Vector3(-4, 1, -9);
                                break;
                            case 3:
                                player.transform.position = new Vector3(-9, 1, -2);
                                break;
                            case 4:
                                player.transform.position = new Vector3(-9, 1, -1.5f);
                                break;
                        }
                        cam.transform.position = new Vector3(-11, 16, -6);
                        cam.transform.rotation = Quaternion.identity;
                        cam.transform.Rotate(60, 90, 0);
                        Maze3D.controles = 15;
                    }
                    luz.transform.rotation = Quaternion.identity;
                    luz.transform.Rotate(60, 45, 0);
                    break;
                case 22:
                    if (cam.transform.position != new Vector3(-6, 16, -11))
                    {
                        mapa.transform.rotation = Quaternion.identity;
                        mapa.transform.Rotate(0, 0, -90);
                        player.transform.position = new Vector3(player.transform.position[0], 1, player.transform.position[2]);
                        switch (posicao)
                        {
                            case 0:
                                player.transform.position = new Vector3(-8, 1, -3);
                                break;
                            case 1:
                                player.transform.position = new Vector3(-3, 1, -4);
                                break;
                            case 2:
                                player.transform.position = new Vector3(-6, 1, -5);
                                break;
                            case 3:
                                player.transform.position = new Vector3(-8, 1, -7);
                                break;
                            case 4:
                                player.transform.position = new Vector3(-8, 1, -7);
                                break;
                            case 5:
                                player.transform.position = new Vector3(-8, 1, -9);
                                break;
                            case 6:
                                player.transform.position = new Vector3(-1.5f, 1, -3);
                                break;
                        }
                        cam.transform.position = new Vector3(-6, 16, -11);
                        cam.transform.rotation = Quaternion.identity;
                        cam.transform.Rotate(60, 0, 0);
                        Maze3D.controles = 12;
                    }
                    luz.transform.rotation = Quaternion.identity;
                    luz.transform.Rotate(60, 45, 0);
                    break;
                case 23:
                    if (cam.transform.position != new Vector3(-6, 16, -11))
                    {
                        mapa.transform.rotation = Quaternion.identity;
                        mapa.transform.Rotate(90, 0, 0);
                        player.transform.position = new Vector3(player.transform.position[0], 1, player.transform.position[2]);
                        switch (posicao)
                        {
                            case 0:
                                player.transform.position = new Vector3(-2, 1, -9);
                                break;
                            case 1:
                                player.transform.position = new Vector3(-4, 1, -9);
                                break;
                            case 2:
                                player.transform.position = new Vector3(-4, 1, -5);
                                break;
                            case 3:
                                player.transform.position = new Vector3(-2, 1, -5);
                                break;
                            case 6:
                                player.transform.position = new Vector3(-6, 1, -8);
                                break;
                            case 7:
                                player.transform.position = new Vector3(-9, 1, -8);
                                break;
                            case 8:
                                player.transform.position = new Vector3(-6, 1, -5);
                                break;
                            case 9:
                                player.transform.position = new Vector3(-8, 1, -3);
                                break;
                        }
                    }
                    cam.transform.position = new Vector3(-6, 16, -11);
                    cam.transform.rotation = Quaternion.identity;
                    cam.transform.Rotate(60, 0, 0);
                    luz.transform.rotation = Quaternion.identity;
                    luz.transform.Rotate(60, 45, 0);
                    Maze3D.controles = 1;
                    break;
                case 24:
                    if (cam.transform.position != new Vector3(-6, 16, 11))
                    {
                        mapa.transform.rotation = Quaternion.identity;
                        mapa.transform.Rotate(180, 0, 0);
                        player.transform.position = new Vector3(player.transform.position[0], 1, player.transform.position[2]);
                        switch (posicao)
                        {
                            case 1:
                                player.transform.position = new Vector3(-1.5f, 1, 3);
                                break;
                            case 2:
                                player.transform.position = new Vector3(-2, 1, 7);
                                break;
                            case 3:
                                player.transform.position = new Vector3(-3, 1, 7);
                                break;
                            case 4:
                                player.transform.position = new Vector3(-5, 1, 9);
                                break;
                            case 5:
                                player.transform.position = new Vector3(-8, 1, 9);
                                break;
                            case 6:
                                player.transform.position = new Vector3(-8, 1, 5);
                                break;
                        }
                    }
                    cam.transform.position = new Vector3(-6, 16, 11);
                    cam.transform.rotation = Quaternion.identity;
                    cam.transform.Rotate(60, 180, 0);
                    luz.transform.rotation = Quaternion.identity;
                    luz.transform.Rotate(60, -225, 0);
                    Maze3D.controles = 13;
                    break;
            }
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
