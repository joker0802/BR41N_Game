using UnityEngine;
using UnityEngine.UI;


public class GameOverText : MonoBehaviour
{
    public GameObject Player;
    [SerializeField] Text gameOverText;
    // Update is called once per frame
    void Start()
    {
        gameOverText.text = "";
    }
    void Update()
    {
        if (Player.GetComponent<PlayerController>().isDestroyed == true)
        {
            gameOverText.text = "GAME OVER";
        }
    }
}
