using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public GameObject prefab { get; }
    public Transform prefabParent { get; }

    private List<GameObject> poolList;

    public Pool(GameObject _prefab, int _count, Transform _prefabParent)
    {
        prefab = _prefab;
        prefabParent = _prefabParent;
        
        CreatePool(_count);
    }

    private void CreatePool(int _count)
    {
        poolList = new List<GameObject>();

        for (int i = 0; i < _count; i++)
        {
            CreateObject();
        }
    }

    private GameObject CreateObject(bool isActive = false)
    {
        var currentObject = Instantiate(this.prefab, this.prefabParent);
        currentObject.SetActive(isActive);
        poolList.Add(currentObject);

        return currentObject;
    }

    private bool HasFreeElement(out GameObject element)
    {
        foreach (var item in poolList)
        {
            if (!item.activeInHierarchy)
            {
                element = item;
                item.SetActive(true);

                return true;
            }
        }

        element = null;

        return false;
    }

    public GameObject GetFreeElement()
    {
        if (HasFreeElement(out var element))
            return element;

        return CreateObject(true);
    }

    public bool HasActiveElement()
    {
        foreach (var item in poolList)
        {
            if (item.gameObject.activeInHierarchy)
                return true;
        }

        return false;
    }

    public void DeactivateAllElements()
    {
        foreach (var item in poolList)
            item.gameObject.SetActive(false);
    }
}
