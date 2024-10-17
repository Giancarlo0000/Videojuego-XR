using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    [SerializeField] private int EnemiesToDestroy = 20;
    [SerializeField] private TextMeshProUGUI RemainingEnemiesUI = null;
    private int _remainingEnemies = 0;

    private void Awake()
    {
        _remainingEnemies = EnemiesToDestroy;
    }

    private void Update()
    {
        if (_remainingEnemies > 0)
        {
            RemainingEnemiesUI.text = "Remaining Enemies: " + _remainingEnemies;
        }
        else
        {
            RemainingEnemiesUI.text = "Victoria";
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            StartCoroutine(ReloadScene(3f));
        }
        
    }

    public void EnemyDestroyed()
    {
        _remainingEnemies--;

        if (_remainingEnemies <= 0)
        {
            print("Win");
        }
    }

    private IEnumerator ReloadScene(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
