using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprint : MonoBehaviour
{
    public Rigidbody player;
    public bool forward, backward, right, left; //Direção do impulso
    public float forca;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (forward)
            {
                player.velocity = new Vector3(player.velocity.x, player.velocity.y, player.velocity.z - forca);
            }
            if (backward)
            {
                player.velocity = new Vector3(player.velocity.x, player.velocity.y, player.velocity.z + forca);
            }
            if (right)
            {
                player.velocity = new Vector3(player.velocity.x - forca, player.velocity.y, player.velocity.z);
            }
            if (left)
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
