using UnityEngine;

public class BirdSound : MonoBehaviour
{
    [SerializeField] private BirdBehaviour _player;

    [SerializeField] private AudioClip _sourceJump;
    [SerializeField] private AudioClip _sourcePipe;
    [SerializeField] private AudioClip _sourceDeath;

    private AudioSource _source;

    // Start function, called before the first frame of the game
    private void Start()
    {
        _source = GetComponent<AudioSource>();

        _player.OnJumpEvent += PlayJumpSound;
        _player.OnPipeEvent += PlayPipeSound;
        _player.OnDeathEvent += PlayDeathSound;
    }

    private void PlayJumpSound()
    {
        _source.PlayOneShot(_sourceJump);
    }

    private void PlayPipeSound()
    {
        _source.PlayOneShot(_sourcePipe);
    }

    private void PlayDeathSound()
    {
        _source.PlayOneShot(_sourceDeath);
    }
}
