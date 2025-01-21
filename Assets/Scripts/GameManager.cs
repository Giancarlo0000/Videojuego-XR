using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set; }
    public float healthPlayer = 100f; 
    private void Awake() {
        if (Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
