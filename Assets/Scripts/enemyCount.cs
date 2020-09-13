using UnityEngine;
using UnityEngine.UI;

public class enemyCount : MonoBehaviour
{
    //public GameObject enemy;
    [SerializeField] Text enemyCounter;

    bool killedAllEnemies = false;

    private int count = 0;
    // Update is called once per frame
    void Start()
    {
        //enemyCounter.text = "Destroy enemy ships: " + count.ToString();
    }
    void Update()
    {
        //enemyCounter.text = "Destroy enemy ships: " + count.ToString();
    }
}
