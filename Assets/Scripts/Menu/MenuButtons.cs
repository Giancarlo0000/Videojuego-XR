using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private Button Jugar = null;
    [SerializeField] private Button Tutorial = null;
    [SerializeField] private Button Level01 = null;
    [SerializeField] private Button Level02 = null;
    [SerializeField] private Button Level03 = null;
    [SerializeField] private Button Level04 = null;
    [SerializeField] private Button Level05 = null;
    [SerializeField] private Button Level06 = null;
    [SerializeField] private Button Level07 = null;
    [SerializeField] private Button Level08 = null;


    private void Start()
    {
        Jugar.onClick.AddListener(StartButton);
        Tutorial.onClick.AddListener(TutorialButton);
        Level01.onClick.AddListener(Level01Button);
        Level02.onClick.AddListener(Level02Button);
        Level03.onClick.AddListener(Level03Button);
        Level04.onClick.AddListener(Level04Button);
        Level05.onClick.AddListener(Level05Button);
        Level06.onClick.AddListener(Level06Button);
        Level07.onClick.AddListener(Level07Button);
        Level08.onClick.AddListener(Level08Button);
    }

    private void StartButton()
    {
        SceneManager.LoadScene("MainGame");
    }
    private void TutorialButton()
    {
        SceneManager.LoadScene("Tutorial");
    }

    private void Level01Button()
    {
        SceneManager.LoadScene("Level01");
    }

    private void Level02Button()
    {
        SceneManager.LoadScene("Level02");
    }

    private void Level03Button()
    {
        SceneManager.LoadScene("Level03");
    }

    private void Level04Button()
    {
        SceneManager.LoadScene("Level04");
    }

    private void Level05Button()
    {
        SceneManager.LoadScene("Level05");
    }

    private void Level06Button()
    {
        SceneManager.LoadScene("Level06");
    }
    private void Level07Button()
    {
        SceneManager.LoadScene("Level07");
    }
    private void Level08Button()
    {
        SceneManager.LoadScene("Level08");
    }
}
