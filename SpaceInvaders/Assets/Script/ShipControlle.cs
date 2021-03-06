﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControlle : MonoBehaviour {
    private new Rigidbody2D rigidbody;
    private Vector2 movement;
    private int posicionX;
    public AudioSource shootingSound; //Declaramos la nueva variable de fuente de sonido

    [Range(1,2)]
    public float speed = 1f;

    void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
        // Posición inicial de la nave
        posicionX = Random.Range(-50, 50);
        movement = new Vector2(posicionX, 0);
        rigidbody.AddForce(movement);
    }
    void Update() {
        // Se obtienen datos de los input horizontal y vertical
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        movement = new Vector2(moveHorizontal, moveVertical);

        StartCoroutine(Fade());
        
        if (Input.GetKey(KeyCode.Space))
        {
            shootingSound.Play();
        }
    }
    void FixedUpdate() { // FixedUpdate se llama en cada fixed frame-rate frame. (50 llamadas por segundo, por defecto)
        // Aplica la fuerza al Rigidbody2d
        rigidbody.AddForce(movement * speed * 5f);
    }

    IEnumerator Fade() {
        
        yield return new WaitForSeconds(.1f);
    }
}
