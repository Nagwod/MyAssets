using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chave : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private GameObject portao;
    [SerializeField] private ParticleSystem ps;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            source.Play();
            var em = ps.emission;
            em.rateOverTime = 30;
            Destroy(portao); //Deleta o portão
            transform.position = new Vector3(transform.position.x, transform.position.y-100, transform.position.z);
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject); //Deleta a chave
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
