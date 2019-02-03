using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAround : MonoBehaviour
{
    public float speed = 500f;
    public float force =5f;
    public Rigidbody rb;
    public int coins = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // Hace mover al objecto en los ejes X, Z
        float InputX = Input.GetAxis("Horizontal");
        float InputZ = Input.GetAxis("Vertical");

        float moveX = InputX * speed * Time.deltaTime;
        float moveZ= InputZ * speed * Time.deltaTime;

        //transform.Translate(moveX, 0f, moveZ);
        rb.AddForce(moveX, 0, moveZ);

        // Al apachar la techa "espacio" el objeto va a saltar
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.005f)
            Saltar();
    }

    private void Saltar()
    {
        rb.AddForce(Vector3.up * force, ForceMode.Impulse);    
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Coins : " + coins);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Osbtaculo"))
        {
            transform.position = new Vector3(-9.501f, 0.491f, 11.989f);
        }

        // player.transform.position = respawnPoint.transform.position;
    } 
}
