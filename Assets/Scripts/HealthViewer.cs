using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthViewer : MonoBehaviour
{
    private int healthPoint;
    public GameObject Player;

    [SerializeField] Text healthPointText;
    // Start is called before the first frame update
    void Start()
    {
        healthPoint = Player.GetComponent<PlayerController>().Health;
        healthPointText.text = "HP: " + healthPoint.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        healthPoint = Player.GetComponent<PlayerController>().Health;
        healthPointText.text = "HP: " + healthPoint.ToString();
    }
}
