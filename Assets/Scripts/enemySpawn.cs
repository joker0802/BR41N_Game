using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform poses;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <6; i++)
        {
            Transform pos = poses.GetChild(i).transform;
            Instantiate(enemyPrefab, pos.position, pos.rotation);
        }
    }
}
