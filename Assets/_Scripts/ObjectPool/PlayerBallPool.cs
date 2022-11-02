using System.Collections.Generic;
using UnityEngine;

//������� ������� ����� ���������, �� ���������� ��-�� Instantinate, ���� �������������� ���� ������. 
// ������� ������ PlayerBallPool : ObjectPool<PlayerBall>

// ������ ������� �� ����� �������, �� �.�. ���� ��������� �� 18 - ��� ������� ��������� ����� ����������

public class PlayerBallPool : MonoBehaviour
{
    private Queue<PlayerBall> _poolObjects;
    private void Awake()
    {
        _poolObjects = new Queue<PlayerBall>();
    }
    public PlayerBall Spawn(PlayerBall poolObject, Transform spawnPosition, Quaternion quaternion)
    {
        if (_poolObjects.Count <= 0)
            AddToPool(poolObject, spawnPosition, quaternion);

        var newPoolObject = GetObjectFromPool();
        newPoolObject.transform.position = spawnPosition.position;
        newPoolObject.gameObject.SetActive(true);
        return newPoolObject;
    }
    private void AddToPool(PlayerBall newPoolObject, Transform spawnPosition, Quaternion quaternion)
    {
        var poolObject = Instantiate(newPoolObject, spawnPosition.position, quaternion);
        _poolObjects.Enqueue(poolObject);
    }
    private PlayerBall GetObjectFromPool()
    {
        var poolObject = _poolObjects.Dequeue();
        return poolObject;
    }
    public void Despawn(PlayerBall poolObject)
    {
        poolObject.gameObject.SetActive(false);
        _poolObjects.Enqueue(poolObject);
    }
}

/*
public abstract class ObjectPool<TPropertyType> : MonoBehaviour 
    where TPropertyType : MonoBehaviour
{
    private Queue<TPropertyType> _poolObjects;
    private void Awake()
    {
        _poolObjects = new Queue<TPropertyType>();
    }
    public TPropertyType Spawn(TPropertyType poolObject,Transform spawnPosition, Quaternion quaternion )
    {
        if( _poolObjects.Count <=0 )
            AddToPool(poolObject, spawnPosition, quaternion);

        var newPoolObject = GetObjectFromPool();
        return newPoolObject;
    }
    private void AddToPool(TPropertyType newPoolObject, Transform spawnPosition, Quaternion quaternion)
    {
        var poolObject = Instantiate(newPoolObject, spawnPosition.position, quaternion);
        _poolObjects.Enqueue(poolObject);
    }
    private TPropertyType GetObjectFromPool()
    {
        var poolObject = _poolObjects.Dequeue();
        poolObject.gameObject.SetActive(true);
        return poolObject;
    }
    public void Despawn(TPropertyType poolObject)
    {
        poolObject.gameObject.SetActive(false);
        _poolObjects.Enqueue(poolObject);
    }
}
*/