using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hpPlayerUI = null;
    [SerializeField] private Image BlackScreen = null;
    
    private void Awake() {
        hpPlayerUI = hpPlayerUI.GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        StartCoroutine(FadeBlackScreen());
    }

    private void Update(){
        hpPlayerUI.text = GameManager.Instance.healthPlayer + "%";

        if (GameManager.Instance.healthPlayer <= 0){
            hpPlayerUI.text = "Has sido derrotado";
            DestroyEnemies();
            StartCoroutine(BackToMenu(5f));
        }
    }

    private void DestroyEnemies(){
        GameObject[] spawners = GameObject.FindGameObjectsWithTag("Spawner");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] enemiesProjectiles = GameObject.FindGameObjectsWithTag("EnemyProjectile");

        foreach (GameObject spawner in spawners){
            Destroy(spawner);
        }
        foreach (GameObject enemy in enemies){
            Destroy(enemy);
        }
        foreach (GameObject enemyProjectile in enemiesProjectiles)
        {
            Destroy(enemyProjectile);
        }
    }

    private IEnumerator ReloadScene(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

private IEnumerator BackToMenu(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("MainMenu");
    }

    private IEnumerator FadeBlackScreen()
    {
        float duration = 1f;
        float elapsedTime = 0f;
        Color screenColor = BlackScreen.color;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(1 - (elapsedTime / duration));
            BlackScreen.color = new Color(screenColor.r, screenColor.g, screenColor.b, alpha);
            yield return null;
        }
    }
}
