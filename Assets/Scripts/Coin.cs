using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private string _appearAnimationName = "CoinAppear";
    [SerializeField]
    private string _dissapearAnimationName = "CoinDisappear";
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private float _timeToDissapear = 3f;
    [SerializeField]
    private UnityEvent _onCoinCollected;
    private Collider _collider;
    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }
    private void OnEnable()
    {
        StartCoroutine(AppearCoroutine());
    }
    private void ODisable()
    {
        StopAllCoroutines();
    }
    public void Collect()
    {
        StartCoroutine(AppearCoroutine());
        _onCoinCollected?.Invoke();
    }
    private IEnumerator AppearCoroutine()
    {
        _animator.Play(_appearAnimationName);
        yield return new WaitForSeconds(_timeToDissapear);
        StartCoroutine(DisappearCoroutine());
    }
    private IEnumerator DisappearCoroutine()
    {
        _collider.enabled = false;
        _animator.Play(_dissapearAnimationName);
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);
        gameObject.SetActive(false);
    }
}
