using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }
    #region Singleton  
    public static ObjectPooler instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
    public List<Pool> pools;

    public Dictionary<string, Queue<GameObject>> poolDictionary;
    // Start is called before the first frame update
    void Start()
    {
        poolDictionary= new Dictionary<string, Queue<GameObject>>();
        foreach(Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for(int i=0;i<pool.size ;i++ )
            {
                GameObject obj=Instantiate(pool.prefab);
                objectPool.Enqueue(obj);
                obj.SetActive(false);
            }
            poolDictionary.Add(pool.tag, objectPool);
            Debug.Log("The tag of " + pool.tag + " has been add");
        }
    }
    public GameObject SpawnFromPool(string tag,Vector3 position,Quaternion rotation)
    {
        if( !poolDictionary.ContainsKey(tag) )
        {
            Debug.LogWarning("Pool with tag " + tag + " dosn't exit");
            return null;
        }
        GameObject pipeToSpawn = poolDictionary[tag].Dequeue();
        pipeToSpawn.SetActive(true);
        pipeToSpawn.transform.position = position;
        pipeToSpawn.transform.rotation = rotation;
        poolDictionary[tag].Enqueue(pipeToSpawn);
        return pipeToSpawn;
    }
    
}
