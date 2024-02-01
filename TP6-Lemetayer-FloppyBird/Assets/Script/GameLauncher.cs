using UnityEngine;

public class GameLauncher : MonoBehaviour
{
    [SerializeField] private UIManager _ui;
    [SerializeField] private BirdBehaviour _player;
    [SerializeField] private PipeGenerator _pipeGenerator;

    // Start is called before the first frame update
    private void Start()
    {
        _player.OnJumpEvent += StartGame;
        _player.OnDeathEvent += StopGame;
    }

    private void StartGame()
    {
        _ui.StartDisplay();
        _player.StartMoving();
        _pipeGenerator.StartSpawn();

        _player.OnJumpEvent -= StartGame;
    }

    private void StopGame()
    {
        _ui.EndDisplay();
        _player.StopMoving();
        _pipeGenerator.StopPipes();

        _player.OnJumpEvent += ResetGame;
    }

    private void ResetGame()
    {
        _ui.ResetDisplay();
        _player.ResetPlayer();
        _pipeGenerator.ResetPipes();

        _player.OnJumpEvent -= ResetGame;
        _player.OnJumpEvent += StartGame;
    }
}
