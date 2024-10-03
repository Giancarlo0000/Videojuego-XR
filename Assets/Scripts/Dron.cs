using UnityEngine;

public class Dron : MonoBehaviour
{
    [SerializeField] private GameObject Projectile = null;
    private GameObject _player;

    private void Start() 
    {
        _player = GameObject.FindWithTag("Player");
        LookAtPlayer();
        InvokeRepeating("InstantiateProjectiles", 2f, 2f);
    }

    private void LookAtPlayer(){
        gameObject.transform.LookAt(_player.transform.position);
    }

    private void InstantiateProjectiles(){
        Instantiate(Projectile, transform.position, Quaternion.identity);
    }
}
