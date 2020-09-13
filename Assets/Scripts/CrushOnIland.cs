using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushOnIland : MonoBehaviour
{
    public GameObject bigExplosionEffect;
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name);
        if (other.name == "ShipCollider")
        {
            GameObject ships = other.gameObject.transform.parent.gameObject;//.transform.parent.gameObject.transform.parent.gameObject;
            Instantiate(bigExplosionEffect, ships.transform.position, ships.transform.rotation);
            ships.GetComponent<PlayerController>().Speed = 0;
            ships.GetComponent<PlayerController>().rotSpeed = 0;
            ships.GetComponent<PlayerController>().isCrushed = true;
            ships.GetComponent<PlayerController>().Health = 0;//ships.GetComponent<PlayerController>().Health - 50;
        }
    }
}
