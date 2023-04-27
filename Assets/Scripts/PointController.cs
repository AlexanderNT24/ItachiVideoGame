using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointController : MonoBehaviour
{
    public float puntos;

    public TextMeshProUGUI textMesh;

    private void Start(){
        textMesh = GetComponent<TextMeshProUGUI>();
    }
     

    private void Update(){
        textMesh.text= "Balas:"+puntos.ToString("0");
    }
      
    public void SumarPuntos(float puntosEntrada){
        puntos += puntosEntrada;
    }
}
