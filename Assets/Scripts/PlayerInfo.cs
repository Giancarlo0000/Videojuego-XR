using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    private float healthPlayer = 110f;
    [SerializeField] TextMeshProUGUI hpPlayerUI = null;
    [SerializeField] Image BlackScreen = null;
    
    private void Awake() {
        hpPlayerUI = hpPlayerUI.GetComponent<TextMeshProUGUI>();
        //healthPlayer = GameManager.Instance.healthPlayer;
        GameManager.Instance.healthPlayer = healthPlayer;
    }

    private void Start()
    {
        StartCoroutine(FadeBlackScreen());
    }

    private void Update(){
        hpPlayerUI.text = "Life:  " + GameManager.Instance.healthPlayer;

        if (GameManager.Instance.healthPlayer <= 0){
            hpPlayerUI.text = "Derrota";
            DestroyEnemies();
            StartCoroutine(ReloadScene(5f));
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
        //GameManager.Instance.healthPlayer = 100f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
