using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    public GameObject creditPanel, optionPanel;

    private void Awake()
    {
        
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Credits()
    {
        creditPanel.SetActive(true);
    }
    public void Options()
    {
        optionPanel.SetActive(true);
    }
    public void ExitCredits()
    {
            creditPanel.SetActive(false);
    }
    public void ExitOptions()
    {
        optionPanel.SetActive(false);
    }
    public void Exit()
    {
            Application.Quit();
    }
}
