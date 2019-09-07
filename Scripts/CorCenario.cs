using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorCenario : MonoBehaviour
{
    public Material[] grama;
    public Material[] borda;
    private Color[] cor = new Color[10];
    private Color[] corRastro = new Color[7];
    public TrailRenderer trail;

    private void OnTriggerEnter(Collider other)
    {
        Tatu.podeMover = false;
        int index = Random.Range(0, cor.Length);
        for (int i = 0; i < grama.Length; i++)
        {
            grama[i].color = cor[index];
        }
        index = Random.Range(0, cor.Length);
        for (int i = 0; i < borda.Length; i++)
        {
            borda[i].color = cor[index];
        }
        index = Random.Range(0, corRastro.Length);
        trail.startColor = corRastro[index];
        trail.endColor = corRastro[index];
    }

    /*
    IEnumerator TrocaCor()
    {
        int index = Random.Range(0, cor.Length);
        for (int i=0;i<grama.Length;i++)
        {
            grama[i].color = cor[index];
        }
        index = Random.Range(0, cor.Length);
        for (int i = 0; i < borda.Length; i++)
        {
            borda[i].color = cor[index];
        }
        yield return (new WaitForSeconds(1));
        StartCoroutine(TrocaCor());
    }*/

    // Start is called before the first frame update
    void Start()
    {
        cor[0] = new Vector4(0.905f, 0.905f, 0.905f, 1);
        cor[1] = new Vector4(0.110582f, 0.3314357f, 0.6698113f, 1);
        cor[2] = new Vector4(0.2729178f, 0.7264151f, 0.1610449f, 1);
        cor[3] = new Vector4(0.6320754f, 0.06857423f, 0.06857423f, 1);
        cor[4] = new Vector4(0.7830189f, 0.3582681f, 0.7574474f, 1);
        cor[5] = new Vector4(0.4214578f, 0.7264151f, 0.6964432f, 1);
        cor[6] = new Vector4(0.8113208f, 0.4997171f, 0.08802067f, 1);
        cor[7] = new Vector4(0.5022805f, 0.1927287f, 0.5754717f, 1);
        cor[8] = new Vector4(0.735849f, 0.7333123f, 0.1423104f, 1);
        cor[9] = new Vector4(0.4150943f, 0.4150943f, 0.4150943f, 1);
        corRastro[0] = new Vector4(1, 1, 1, 1);
        corRastro[1] = new Vector4(1, 1, 0, 1);
        corRastro[2] = new Vector4(1, 0, 1, 1);
        corRastro[3] = new Vector4(1, 0, 0, 1);
        corRastro[4] = new Vector4(0, 1, 1, 1);
        corRastro[5] = new Vector4(0, 1, 0, 1);
        corRastro[6] = new Vector4(0, 0, 1, 1);
        //StartCoroutine(TrocaCor());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
