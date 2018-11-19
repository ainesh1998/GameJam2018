using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    bool gameHasEnded = false;
    public float delay;

    public void gameWin() {
        if (gameHasEnded == false) {
            gameHasEnded = true;
            Debug.Log("You have won!");
        }

    }

    public void gameLost()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("You have lost.");
            //restart();
            Debug.Log("Respawning");
            Invoke("restart",delay);
        }

    }

    void restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
