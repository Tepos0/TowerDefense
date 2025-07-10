using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class InstantiatePoolObject : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab;
    private List<GameObject> _pool = new List<GameObject>();
    public GameObject GetObject()
    {
        foreach (var obj in _pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }
        var newObj = Instantiate(_prefab, transform);
        _pool.Add(newObj);
        return newObj;
    }
    public void InstantiateObject()
    {
        var newObj = Instantiate(_prefab);
        _pool.Add(newObj);
    }
    public void InstantiateObject(Transform target)
    {
        var obj = GetObject();
        obj.transform.SetPositionAndRotation(target.position, target.rotation);
        obj.SetActive(true);
    }
}
