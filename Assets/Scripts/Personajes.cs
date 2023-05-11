using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="NuevoPersonaje", menuName="Personaje")]
public class Personajes : ScriptableObject
{
    public GameObject PersonajeJugable;
    public Sprite imagen;
    public string nombre;

}
