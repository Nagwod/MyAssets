using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprint : MonoBehaviour
{
    [SerializeField] private Rigidbody player;
    [SerializeField] private bool forward, backward, right, left; //Direção do impulso
    [SerializeField] private float forca, limite;
    [SerializeField] private AudioSource source;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            source.Play();
        }
    }

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
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
