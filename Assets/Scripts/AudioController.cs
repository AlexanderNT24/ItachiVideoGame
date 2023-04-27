using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    private AudioSource audioSource;

    [SerializeField] private AudioClip colectar1;

    [SerializeField] private AudioClip colectar2;

    private PointController pointController;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        pointController = FindObjectOfType<PointController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pointController.SumarPuntos(5); 
            pointController.textMesh.text = pointController.puntos.ToString("e");
            audioSource.PlayOneShot(colectar2);
        }
    }

}
