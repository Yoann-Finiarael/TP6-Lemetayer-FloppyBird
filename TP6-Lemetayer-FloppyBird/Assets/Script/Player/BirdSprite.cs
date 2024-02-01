using UnityEngine;

public class BirdSprite : MonoBehaviour
{
    [SerializeField] private BirdBehaviour _player;

    [SerializeField] private Sprite _spriteAlive;
    [SerializeField] private Sprite _spriteDead;

    private SpriteRenderer _sr;

    // Start is called before the first frame update
    private void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        SwitchAlive();

        _player.OnDeathEvent += SwitchDead;
    }

    private void SwitchAlive()
    {
        _sr.sprite = _spriteAlive;

        _player.OnJumpEvent -= SwitchAlive;
    }

    private void SwitchDead()
    {
        _sr.sprite = _spriteDead;

        // Switches back the alive skin when the player restarts
        _player.OnJumpEvent += SwitchAlive;
    }
}
