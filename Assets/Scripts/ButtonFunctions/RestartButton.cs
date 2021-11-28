using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }
}
