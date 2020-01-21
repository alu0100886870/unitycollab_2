using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Otorgavida : MonoBehaviour
{
    public int cantidadVida = 5;
    public GameObject personaje;
    public float distancia;
    private bool gastado = false;
    public Material material_gastado;
    Renderer m_ObjectRenderer;
    public float timer = 0f;
    private float distanciaMinAct = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        changePosition();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        int seconds = (int)timer % 60;

        if (seconds >= 5)
        {
            changePosition();
            seconds = 0;
            timer = 0;
        }
    }

    private void FixedUpdate()
    {
        distancia = Vector3.Distance(personaje.transform.position, this.transform.position);
        if (distancia < distanciaMinAct)
        {
            if (!gastado)
            {
                gastado = true;
                m_ObjectRenderer = this.GetComponentInChildren<Renderer>();
                m_ObjectRenderer.material = material_gastado;
                CharacterStatus status = (CharacterStatus)personaje.GetComponent(typeof(CharacterStatus));
                status.sumarVida(cantidadVida);
            }
        }
    }

    private void changePosition()
    {
        float randomX = Random.Range(-3f, 3f);
        float randomZ = Random.Range(-3f, 3f);
        transform.position = new Vector3(randomX, transform.position.y, randomZ);
    }
}
