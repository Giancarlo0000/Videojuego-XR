using System.Linq;
using UnityEngine;

public class AimingSystem : MonoBehaviour
{
    [SerializeField] private Camera vrCamera;
    [SerializeField] private GameObject aimingPrefab;
    [SerializeField] private Vector2 moveAiming = Vector2.zero;

    private Canvas _canvas;
    private GameObject _currentTarget;
    private GameObject _targetIndicator;

    private void Awake()
    {
        _canvas = GetComponent<Canvas>();
    }

    private void Start()
    {
        _targetIndicator = Instantiate(aimingPrefab, _canvas.transform);
        _targetIndicator.SetActive(false);
    }

    private void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        _currentTarget = null;

        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(vrCamera);

        var visibleEnemies = enemies.Where(e => GeometryUtility.TestPlanesAABB(planes, e.GetComponent<Collider>().bounds)).ToArray();

        if (visibleEnemies.Length > 0)
        {
            _currentTarget = visibleEnemies.OrderBy(e => Vector3.Distance(transform.position, e.transform.position)).FirstOrDefault();

            if (_currentTarget != null)
            {
                Vector3 screenPos = vrCamera.WorldToScreenPoint(_currentTarget.transform.position);

                RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvas.GetComponent<RectTransform>(), screenPos, vrCamera, out Vector2 localPoint);

                _targetIndicator.GetComponent<RectTransform>().localPosition = localPoint + moveAiming;
                _targetIndicator.SetActive(true);
            }
        }
        else
        {
            _targetIndicator.SetActive(false);
        }
    }
}
