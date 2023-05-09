using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Pool;

public class PoolManager : Singleton<PoolManager>
{
    [System.Serializable]
    public class Pool
    {
        public string name;
        public Transform prefab;
        public int size;
        public Transform objParent;
    }

    public List<Pool> Pools;

    Dictionary<string, Queue<Transform>> poolsDict;

    private void Start()
    {
        poolsDict= new Dictionary<string, Queue<Transform>>();

        foreach(Pool pool in Pools)
        {
            Queue<Transform> objectPool = new Queue<Transform>();

            for(int i=0 ; i<pool.size; i++)
            {
                Transform obj = Instantiate(pool.prefab);
                obj.transform.SetParent(pool.objParent);
                obj.gameObject.SetActive(false);

                objectPool.Enqueue(obj);
            }

            poolsDict.Add(pool.name, objectPool);
        }
    }

    public Transform SpawnPool(string name, Vector3 position, Quaternion rotation)
    {
        //Lấy ra phần tử đầu tiên của queue và loại bỏ phần tử này ra khỏi queue
        Transform objSpawn = poolsDict[name].Dequeue();

        objSpawn.gameObject.SetActive(true);
        objSpawn.SetPositionAndRotation(position, rotation);

        poolsDict[name].Enqueue(objSpawn);

        return objSpawn;
    }
    public T SpawnPool<T>(string name, Vector3 position, Quaternion rotation) where T : MonoBehaviour
    {
        //Lấy ra phần tử đầu tiên của queue và loại bỏ phần tử này ra khỏi queue
        Transform objSpawn = poolsDict[name].Dequeue();

        objSpawn.gameObject.SetActive(true);
        objSpawn.SetPositionAndRotation(position, rotation);

        poolsDict[name].Enqueue(objSpawn);

        return objSpawn.GetComponent<T>();
    }
}
   
