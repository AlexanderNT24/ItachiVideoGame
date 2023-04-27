using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifesController : MonoBehaviour
{
    public int vidas = 2;
    public TextMeshProUGUI textMesh;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        textMesh.text = "Vidas: 2";
    }

    void Update()
    {
        textMesh.text = "Vidas: " + vidas.ToString();
    }

    public void RestLife()
    {
        vidas--;
    }
}
