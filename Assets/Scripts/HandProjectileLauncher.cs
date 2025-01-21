using UnityEngine;
public class HandProjectileLauncher : MonoBehaviour
{
    [SerializeField] private string EnergyBallTag = "EnergyBall";
    [SerializeField] private Transform SpawnPointRightHand;
    [SerializeField] private AudioSource AudioRightHand = null;
    [SerializeField] private Transform SpawnPointLeftHand;
    [SerializeField] private AudioSource AudioLeftHand = null;
    [SerializeField] private GameObject WatchUI;

    private bool _isRightTriggerPressed = false;
    private bool _isLeftTriggerPressed = false;
    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            WatchUI.SetActive(!WatchUI.activeSelf);
        }

        float rightTriggerValue = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch);
        if (rightTriggerValue > 0.1f && !_isRightTriggerPressed)
        {
            Shoot(SpawnPointRightHand, AudioRightHand);
            _isRightTriggerPressed = true;
        }
        else if(rightTriggerValue <= 0.1f)
        {
            _isRightTriggerPressed = false;
        }

        float leftTriggerValue = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.LTouch);

        if (leftTriggerValue > 0.1f && !_isLeftTriggerPressed)
        {
            Shoot(SpawnPointLeftHand, AudioLeftHand);
            _isLeftTriggerPressed = true;
        }
        else if(leftTriggerValue <= 0.1f)
        {
            _isLeftTriggerPressed = false;
        }
    }

    private void Shoot(Transform spawnPoint, AudioSource audioSource)
    {
        GameObject projectile = ObjectPooling.Instance.SpawnFromPool(EnergyBallTag, spawnPoint.position, Quaternion.identity);

        if (projectile != null)
        {
            Vector3 direction = spawnPoint.forward;

            Rigidbody rigidbody = projectile.GetComponent<Rigidbody>();

            if (rigidbody != null)
            {
                rigidbody.velocity = direction * 10f;
            }

            if (audioSource != null)
            {
                audioSource.Play();
            }
        } 
    }
}
