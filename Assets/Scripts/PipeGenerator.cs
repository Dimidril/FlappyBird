using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : ObjectPool
{
    [SerializeField] private GameObject _template;
    [SerializeField] private float _secondBetweenSpawn;
    [SerializeField] private float _maxSpawnPositionY, _minSpawnPositionY;

    private float _elapsedTime = 0;

    private void Start()
    {
        Initialize(_template);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if(_elapsedTime > _secondBetweenSpawn)
        {
            if(TryGetObject(out GameObject pipe))
            {
                _elapsedTime = 0;

                float spawnedPositionY = Random.Range(_minSpawnPositionY, _maxSpawnPositionY);
                Vector3 spawnPoint = new Vector3(transform.position.x, spawnedPositionY, transform.position.y);
                pipe.SetActive(true);
                pipe.transform.position = spawnPoint;

                DisableObjectAboardScreen();
            }
        }
    }
}