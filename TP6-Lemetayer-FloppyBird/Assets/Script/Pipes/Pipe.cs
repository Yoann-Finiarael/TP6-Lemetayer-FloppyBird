using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public bool InUse { get; private set; }

    [SerializeField] private float _unuseTime = 5;

    private float _speed = 5;

    /// <summary>
    /// Properly sets up a Pipe. Make sure to only call pipe that are not in use yet
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="speed"></param>
    public void InitPipe(Vector3 pos, float speed)
    {
        transform.position = pos;
        _speed = speed;
        InUse = true;

        StartCoroutine(AutoUnuse());
    }

    /// <summary>
    /// Immediatly Unuses the Pipe
    /// </summary>
    public void ManualUnuse()
    {
        InUse = false;
        StopAllCoroutines();
    }

    // Update function, called once every frame
    private void Update()
    {
        if (InUse)
        {
            transform.position = transform.position + (Vector3.left * _speed * Time.deltaTime);
        }
    }

    /// <summary>
    /// Automatically unuses the Pipe after a set amount of time
    /// </summary>
    /// <returns></returns>
    private IEnumerator AutoUnuse()
    {
        yield return new WaitForSeconds(_unuseTime);

        InUse = false;

        yield return null;
    }
}
