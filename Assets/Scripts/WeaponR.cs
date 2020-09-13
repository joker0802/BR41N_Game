using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponR : MonoBehaviour
{
    public GameObject cannonBall;
    public Transform[] cannonPos;
    public float fireForce = 10;

    //public bool isPlayer = false;
    private bool reloading = false;

    void Awake()
    {
        StartCoroutine(waitReload());
    }
    void FixedUpdate()
    {
        int layerMask = 1 << 9 | 1 << 10;
        RaycastHit hit;
        if (gameObject.tag == "RightCannon")
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(new Vector3(1, -0.3f, 0)), out hit, Mathf.Infinity, layerMask) 
                || Physics.Raycast(transform.position, transform.TransformDirection(new Vector3(1, -0.2f, 0)), out hit, Mathf.Infinity, layerMask)
                || Physics.Raycast(transform.position, transform.TransformDirection(new Vector3(1, -0.1f, 0)), out hit, Mathf.Infinity, layerMask))
            {
                //Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(1, -0.3f, 0)) * hit.distance, Color.red);
                if (reloading == false)
                {
                    fireWeapon(true);
                    reloading = true;
                }
            }
        }
        else
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(new Vector3(-1, -0.3f, 0)), out hit, Mathf.Infinity, layerMask) 
                || Physics.Raycast(transform.position, transform.TransformDirection(new Vector3(-1, -0.2f, 0)), out hit, Mathf.Infinity, layerMask)
                || Physics.Raycast(transform.position, transform.TransformDirection(new Vector3(-1, 0.1f, 0)), out hit, Mathf.Infinity, layerMask))
            {
                if (reloading == false)
                {
                    fireWeapon(false);
                    reloading = true;
                }
            }
        }
        
    }

    void fireWeapon(bool rightSide)
    {
        foreach (Transform cannon in cannonPos)
        {
            GameObject Ball = Instantiate(cannonBall, cannon.position, cannon.rotation);
            Rigidbody rb = Ball.GetComponent<Rigidbody>();
            fireForce = Random.Range(35f, 65f);
            if (rightSide)
            {
                rb.AddForce(Ball.transform.right * fireForce, ForceMode.VelocityChange);
            }
            else
            {
                rb.AddForce(-Ball.transform.right * fireForce, ForceMode.VelocityChange);
            }
        }
    }
    IEnumerator waitReload()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3, 6));
            reloading = false;
            //Debug.Log(reloading);
        }
    }
}
