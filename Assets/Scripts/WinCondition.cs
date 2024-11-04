using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    [SerializeField] private int EnemiesToDestroy = 20;
    [SerializeField] private TextMeshProUGUI RemainingEnemiesUI = null;
    [SerializeField] private float TimeLimit = 45f;
    [SerializeField] private bool IsTimeLevel = false;
    [SerializeField] private GameObject TimeIcon = null;
    [SerializeField] private GameObject EnemiesIcon = null;
    private int _remainingEnemies = 0;
    private float _remainingTime = 0f;

    private void Awake()
    {
        _remainingEnemies = EnemiesToDestroy;
        if (IsTimeLevel)
        {
            _remainingTime = TimeLimit;
        }
    }

    private void Update()
    {
        if (IsTimeLevel)
        {
            TimeIcon.SetActive(true);
            _remainingTime -= Time.deltaTime;
            RemainingEnemiesUI.text = "" + Mathf.Max(0, Mathf.Ceil(_remainingTime)); //Tiempo

            if (_remainingTime <= 0)
            {
                RemainingEnemiesUI.text = "Victoria: Tiempo completado.";
                StartCoroutine(GoToMenuAfterDelay(3f));
            }
        }
        else
        {
            EnemiesIcon.SetActive(true);
            if (_remainingEnemies > 0)
            {
                RemainingEnemiesUI.text = "" + _remainingEnemies; //Enemigos
            }
            else
            {
                RemainingEnemiesUI.text = "Victoria: Todos los enemigos destruidos.";
                StartCoroutine(GoToMenuAfterDelay(3f));
            }
        }

    }

    public void EnemyDestroyed()
    {
        if (!IsTimeLevel)
        {
            _remainingEnemies--;
            if (_remainingEnemies <= 0)
            {
                print("Win");
            }
        }
    }

    /*private IEnumerator ReloadScene(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }*/

    private IEnumerator GoToMenuAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("MainMenu");
    }
}
