using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour
{
    public void GoBackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
