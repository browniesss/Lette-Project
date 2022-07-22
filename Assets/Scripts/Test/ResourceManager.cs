using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public T Load<T>(string path) where T : Object
    {
        if (typeof(T) == typeof(GameObject))
        {
            string name = path;
            int index = name.LastIndexOf('/');
            if (index >= 0)
                name = name.Substring(index + 1);

            GameObject go = GameMG.ObjManager.GetOriginal(name);
            if (go != null)
                return go as T;
        }
        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject original = Load<GameObject>($"Prefabs/{path}");

        if (original == null)
        {
            Debug.Log($"Failed to load prefab : {path}");
            return null;
        }

        if (original.GetComponent<Poolable>() != null)
        {
            return GameMG.ObjManager.Pop(original, parent).gameObject;
        }

        GameObject go = Object.Instantiate(original, parent);
        go.name = original.name;
        return go;
    }

    //��巹������ �ٲ�ߴ�
    //public GameObject Instantiate(string path, Transform parent = null)
    //{
    //  //  GameObject original = Load<GameObject>($"Prefabs/{path}");

    //    if (original == null)
    //    {
    //        Debug.Log($"Failed to load prefab : {path}");
    //        return null;
    //    }

    //    if (original.GetComponent<Poolable>() != null)
    //    {
    //        return GameMG.ObjManager.Pop(original, parent).gameObject;
    //    }

    //    GameObject go = Object.Instantiate(original, parent);
    //    go.name = original.name;
    //    return go;
    //}

    public void Destroy(GameObject go)
    {
        if (go == null)
            return;

        Poolable poolable = go.GetComponent<Poolable>();
        if (poolable != null)
        {
            GameMG.ObjManager.Push(poolable);
            return;
        }

        Object.Destroy(go);
    }
}
