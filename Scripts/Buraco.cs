using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buraco : MonoBehaviour
{
    [SerializeField] private Vector3 checkpoint;
    [SerializeField] private float timer;
    [SerializeField] private Rigidbody tatu;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(timer);
        tatu.velocity = new Vector3(0, 0, 0);
        tatu.transform.position = checkpoint;

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
