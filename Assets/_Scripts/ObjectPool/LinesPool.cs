using System.Collections.Generic;
using UnityEngine;

public class LinesPool : MonoBehaviour
{
    private Queue<Line> _poolObjects;
    private void Awake()
    {
        _poolObjects = new Queue<Line>();
    }
    public Line Spawn(Line poolObject, Vector2 spawnPosition, Quaternion quaternion)
    {
        if (_poolObjects.Count <= 0)
            AddToPool(poolObject, spawnPosition, quaternion);

        var newPoolObject = GetObjectFromPool();
        newPoolObject.transform.position = spawnPosition;
        newPoolObject.IsDespawned = false;

        return newPoolObject;
    }
    private void AddToPool(Line newPoolObject, Vector2 spawnPosition, Quaternion quaternion)
    {
        var poolObject = Instantiate(newPoolObject, spawnPosition, quaternion);
        _poolObjects.Enqueue(poolObject);
    }
    private Line GetObjectFromPool()
    {
        var poolObject = _poolObjects.Dequeue();
        poolObject.gameObject.SetActive(true);
        return poolObject;
    }
    public void Despawn(Line poolObject)
    {
        if (poolObject.IsDespawned) return;

        poolObject.IsDespawned = true;
        poolObject.gameObject.SetActive(false);
        _poolObjects.Enqueue(poolObject);
    }
}
