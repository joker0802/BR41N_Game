using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buffSpawn : MonoBehaviour
{
    public GameObject buffs;
    public Transform poses;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(newbuff());
    }
    IEnumerator newbuff()
    {
        while (true)
        {
            Transform pos = poses.GetChild(Random.Range(0,9)).transform;
            yield return new WaitForSeconds(10);
            Instantiate(buffs, pos.position, pos.rotation);
        }
    }
}
