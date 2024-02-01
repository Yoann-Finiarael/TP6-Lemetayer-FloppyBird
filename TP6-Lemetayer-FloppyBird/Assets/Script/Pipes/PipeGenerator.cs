using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _prefabPipe;

    [Header("Spawn Time")]
    [SerializeField] private float _spawnTimer = 2;
    [SerializeField] private float _spawnTimerDecrease = 0.05f;

    [Header("Pipe Speed")]
    [SerializeField] private float _pipeSpeed = 5;
    [SerializeField] private float _pipeSpeedIncrease = 0.5f;

    [Header("Pipe Height Offset")]
    [SerializeField] private float _pipeHeightOffset = 1;
    [SerializeField] private float _pipeHeightOffsetIncrease = 0.5f;

    private List<Pipe> _pipePool;

    /// <summary>
    /// Starts the spawn of Pipes
    /// </summary>
    public void StartSpawn()
    {
        StartCoroutine(SpawnPipe());
    }

    /// <summary>
    /// Stops the spawn of Pipes, and Unuses all Pipes
    /// </summary>
    public void StopPipes()
    {
        StopAllCoroutines();

        for (int i = 0; i < _pipePool.Count; i++)
        {
            _pipePool[i].ManualUnuse();
        }
    }

    /// <summary>
    /// Takes back all created pipes
    /// </summary>
    public void ResetPipes()
    {
        for (int i = 0; i < _pipePool.Count; i++)
        {
            _pipePool[i].transform.position = transform.position;
        }
    }

    // Start function, called before the first frame of the game
    private void Start()
    {
        _pipePool = new List<Pipe>();
    }

    private IEnumerator SpawnPipe()
    {
        Vector3 pipeHeight = transform.position + new Vector3(0f, Random.Range(_pipeHeightOffset * -1, _pipeHeightOffset), 0f); // Offsets the pipe's position randomly within _pipeHeightOffset

        GetAvailablePipe().InitPipe(pipeHeight, _pipeSpeed);

        yield return new WaitForSeconds(_spawnTimer);

        IncreaseDifficulty();
        StartCoroutine(SpawnPipe());
    }

    private void IncreaseDifficulty()
    {
        _spawnTimer -= _spawnTimerDecrease;
        _pipeSpeed += _pipeSpeedIncrease;
        _pipeHeightOffset += _pipeHeightOffsetIncrease;
    }

    private Pipe GetAvailablePipe()
    {
        for (int i = 0; i < _pipePool.Count; i++)
        {
            if (!_pipePool[i].InUse)
            {
                return _pipePool[i];
            }
        }

        // If no available pipes were found
        return CreateNewPipe();
    }

    private Pipe CreateNewPipe()
    {
        Pipe pipe = Instantiate(_prefabPipe, transform).GetComponent<Pipe>();

        _pipePool.Add(pipe);

        return pipe;
    }
}
