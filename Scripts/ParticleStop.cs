using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleStop : MonoBehaviour
{
    private ParticleSystem ps;
    [SerializeField] private int e;
    [SerializeField] private float tempo;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    IEnumerator StopParticle()
    {
        yield return new WaitForSeconds(tempo);
        var em = ps.emission;
        em.rateOverTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (ps.emission.rateOverTime.constant.Equals(e))
        {
            StartCoroutine(StopParticle());
        }
    }
}
