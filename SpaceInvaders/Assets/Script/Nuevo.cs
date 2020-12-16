using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuevo : MonoBehaviour {

    [Header("Valores principales")]
    public string myName;
    
    [Header("Variables numéricas")]
    [Range(1, 6)]
    public int numero;
    [Range(0.2f, 0.8f)]
    public float valor;

    void Start() {
        // Inicialización de la clase
        Debug.Log("I am alive and my name is " + myName);
    }

    void Update() {
        // Actualización de cada Frame
    }
}
