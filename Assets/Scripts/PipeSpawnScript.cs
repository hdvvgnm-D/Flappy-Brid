using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PipeSpawnScript : MonoBehaviour
{
    ObjectPooler objectpooler;
    private float spawnSpeed=3;
    private float timer = 0;
    private float offset = 10;
    // Start is called before the first frame update
    void Start()
    {
        objectpooler = ObjectPooler.instance;
        pipespawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnSpeed) timer = timer + 1 * Time.deltaTime;
        else
        {
            pipespawn();
            timer = 0;
        }
    }
    private void pipespawn()
    {
        float highest = transform.position.y + offset;
        float lowest = transform.position.y - offset;
        objectpooler.SpawnFromPool("Pipe", new Vector3(transform.position.x, Random.Range(lowest, highest), 0), transform.rotation);
    }
}
