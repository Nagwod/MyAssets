using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprint : MonoBehaviour
{
    public Rigidbody player;
    public bool forward, backward, right, left; //Direção do impulso
    public float forca, limite;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (forward && player.velocity.z > -limite)
            {
                player.velocity = new Vector3(player.velocity.x, player.velocity.y, player.velocity.z - forca);
            }
            if (backward && player.velocity.z < limite)
            {
                player.velocity = new Vector3(player.velocity.x, player.velocity.y, player.velocity.z + forca);
            }
            if (right && player.velocity.x > -limite)
            {
                player.velocity = new Vector3(player.velocity.x - forca, player.velocity.y, player.velocity.z);
            }
            if (left && player.velocity.x < limite)
            {
                player.velocity = new Vector3(player.velocity.x + forca, player.velocity.y, player.velocity.z);
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
