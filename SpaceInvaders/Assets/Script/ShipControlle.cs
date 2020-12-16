using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControlle : MonoBehaviour {
    private new Rigidbody2D rigidbody;
    private Vector2 movement;
    private Vector2 movementX;
    public float speed = 1f;

    void Start() { // Se llama a Start antes de la primera actualización del cuadro
        rigidbody = GetComponent<Rigidbody2D>();
        int posicionX = Random.Range(-100, 100);
        Debug.Log("Posición inicial: " + posicionX);
        movement = new Vector2(posicionX, 0);
        rigidbody.AddForce(movement);
        // Debug.Log(x);
    }

    void Update() { // Update se llama una vez por frame
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        movement = new Vector2(moveHorizontal, moveVertical);
    }
    
    void FixedUpdate() { // FixedUpdate se llama en cada fixed frame-rate frame. (50 llamadas por segundo, por defecto)
        // Aplica la fuerza al Rigidbody2d
        rigidbody.AddForce(movement * speed * 5f);
    }
}
