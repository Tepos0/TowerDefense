using System.Buffers.Text;
using UnityEngine;
using UnityEngine.Events;

public class ClickRayCast : MonoBehaviour
{
    [SerializeField]
    private float _rayCastDistance = 100f;
    [SerializeField]
    private LayerMask _raycastLayerMask;
    [SerializeField]
    private string _coinTag = "Coin";
    [SerializeField]
    private UnityEvent <Transform> _onCoinPressed;
    private bool _isActive = false;
    public void SetActive(bool isActive)
    {
        _isActive = isActive;
    }
    private void Update()
    {
        if (!_isActive) return;
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, _rayCastDistance, _raycastLayerMask))
            {
                if (hit.collider.CompareTag(_coinTag))
                {
                    PressCoin(hit.collider.GetComponent<Coin>());
                }
            }
        }
    }
    private void PressCoin(Coin coin)
    {
        coin.Collect();
        _onCoinPressed?.Invoke(coin.transform);
    }
}
