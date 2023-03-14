using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour, IManager
{
    public void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Update()
    {
        var quitButtonESC = Input.GetKey(KeyCode.Escape) ? 1 : 0;
        if (quitButtonESC != 0)
        {
            ExitGame();
        }
    }

    public void ExitGame()
    {
        Debug.Log("���� ���������");
        Application.Quit();
    }
}
