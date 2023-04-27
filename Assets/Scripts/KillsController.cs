using UnityEngine;
using TMPro;

public class KillsController : MonoBehaviour
{
    public int kills = 0;
    public TextMeshProUGUI textMesh;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        textMesh.text = "Kills: 0";
    }

    void Update()
    {
        textMesh.text = "Kills: " + kills.ToString();
    }

    public void AddKill()
    {
        kills++;
    }
}