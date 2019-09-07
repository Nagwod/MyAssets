using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    //Script da bola na fase do labirinto 3D

    Vector3 posAnt;

    public void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "TiltMaze")
        {
            Physics.gravity = new Vector3(0, -300, 0);
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "TiltMaze")
        {
            Physics.gravity = new Vector3(0, -59.81f, 0);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0.01f,0);
    }
}
