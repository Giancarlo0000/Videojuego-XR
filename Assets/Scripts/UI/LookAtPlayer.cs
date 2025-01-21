using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private Transform _player = null;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (_player != null)
        {
            Vector3 direction = _player.position - transform.position;
            direction.y = 0f;
            transform.rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y + 180, 0f);
        }
    }
}
