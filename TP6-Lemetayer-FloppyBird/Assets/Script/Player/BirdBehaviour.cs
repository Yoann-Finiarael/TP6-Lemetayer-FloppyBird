using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdBehaviour : MonoBehaviour
{
    public event Action OnJumpEvent;

    public event Action OnPipeEvent;

    public event Action OnDeathEvent;

    public int Score { get; private set; }

    [SerializeField] private float _jumpStrength = 10;

    private Rigidbody2D _rb;

    private Vector3 _initPos;

    /// <summary>
    /// Called when the start of the action "Jump" is performed
    /// </summary>
    /// <param name="context"></param>
    public void OnJump()
    {
        OnJumpEvent?.Invoke();

        _rb.velocity = Vector2.up * _jumpStrength;
    }

    /// <summary>
    /// Allows the player to move. Still restrain them from moving horizontally
    /// </summary>
    public void StartMoving()
    {
        _rb.constraints = RigidbodyConstraints2D.FreezePositionX;
    }

    /// <summary>
    /// Prevents the player from moving
    /// </summary>
    public void StopMoving()
    {
        _rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    /// <summary>
    /// Resets the player's position and score
    /// </summary>
    public void ResetPlayer()
    {
        transform.position = _initPos;
        Score = 0;
    }

    // Start is called before the first frame update
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Makes the player turn depending on their upward momentum
        transform.rotation = Quaternion.Euler(0, 0, _rb.velocity.y * 3);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnDeathEvent?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Score++;
        OnPipeEvent?.Invoke();
    }
}
