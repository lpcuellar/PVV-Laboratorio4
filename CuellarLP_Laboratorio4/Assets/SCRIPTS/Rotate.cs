using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{   
    public float speed = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //  Hace rotar los objetos sobre su propio eje
        transform.Rotate(Vector3.up, speed * 5 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "JUGADOR")
        {
            other.GetComponent<MoveAround>().coins++;
            Destroy(gameObject);
        }
    }
}
