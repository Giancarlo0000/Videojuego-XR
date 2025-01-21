using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private Button Jugar = null;
    [SerializeField] private Button Tutorial = null;
    [SerializeField] private Button[] LevelButtons = null;


    private void Start()
    {
        Jugar.onClick.AddListener(StartButton);
        Tutorial.onClick.AddListener(TutorialButton);

        for (int i = 0; i < LevelButtons.Length; i++)
        {
            int index = i + 1;
            LevelButtons[i].onClick.AddListener(() => LoadScene($"Level{index:00}"));
        }
    }

    private void StartButton()
    {
        SceneManager.LoadScene("Endless");
    }
    private void TutorialButton()
    {
        SceneManager.LoadScene("Tutorial");
    }

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
