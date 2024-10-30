using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemi : MonoBehaviour
{
    [SerializeField] private GameObject[] enemiPrefab;
    [SerializeField] private Transform[] spawnPlace;
    [SerializeField] private float _minimumSpawnTime;
    [SerializeField] private float _maximumSpawnTime;
    [SerializeField] private float maxEnemi;
    
    private float totalEnemi = 0; 
    private float _timeUntilSpawn;

    // Start is called before the first frame update
    void Start()
    {
        SetTimeUntilSpawn();
    }

    // Update is called once per frame
    void Update()
    {

        _timeUntilSpawn -= Time.deltaTime;

        if ( _timeUntilSpawn <= 0 && totalEnemi <= maxEnemi) 
        {
            Instantiate(enemiPrefab[Random.Range(0,enemiPrefab.Length)], spawnPlace[Random.Range(0,spawnPlace.Length)].transform.position ,Quaternion.identity );
            SetTimeUntilSpawn() ;
            totalEnemi++;
        }
    }

    private void SetTimeUntilSpawn()
    {
        _timeUntilSpawn = Random.Range(_minimumSpawnTime, _maximumSpawnTime);
    }
}
