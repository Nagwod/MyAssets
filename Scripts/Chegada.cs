using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chegada : MonoBehaviour
{
    [SerializeField] private ParticleSystem p1, p2;
    [SerializeField] private AudioSource a1, a2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var em1 = p1.emission;
            var em2 = p2.emission;
            a1.Play();
            a2.Play();
            em1.rateOverTime = 50;
            em2.rateOverTime = 50;
            Destroy(this);
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
