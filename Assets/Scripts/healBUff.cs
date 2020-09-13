using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healBUff : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "ShipCollider")
        {
            //Debug.Log(other.name);
            GameObject ships = other.gameObject.transform.parent.gameObject;
            //Debug.Log(other.name);
            if (ships.name == "Player")
            {
                ships.GetComponent<PlayerController>().Health += 50;
            }
            Destroy(gameObject);
        }
    }
}
