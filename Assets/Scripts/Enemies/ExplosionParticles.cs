using UnityEngine;

public class ExplosionParticles : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("Deactivate", 2f);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
