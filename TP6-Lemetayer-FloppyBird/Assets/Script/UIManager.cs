using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private BirdBehaviour _player;

    [Header("UI Elements")]
    [SerializeField] private GameObject _panelStart;
    [SerializeField] private GameObject _panelInGame;
    [SerializeField] private GameObject _panelEnd;

    [SerializeField] private TextMeshProUGUI _scoreDisplay;
    [SerializeField] private TextMeshProUGUI _scoreEndDisplay;

    public void StartDisplay()
    {
        _panelStart.SetActive(false);
        _panelInGame.SetActive(true);
    }

    public void EndDisplay()
    {
        _panelInGame.SetActive(false);
        _panelEnd.SetActive(true);

        _scoreEndDisplay.SetText(_scoreDisplay.text);
    }

    public void ResetDisplay()
    {
        _panelStart.SetActive(true);
        _panelInGame.SetActive(false);
        _panelEnd.SetActive(false);

        _scoreDisplay.SetText("0");
    }

    // Start is called before the first frame update
    private void Start()
    {
        _player.OnPipeEvent += UpdateScore;

        ResetDisplay();
    }

    private void UpdateScore()
    {
        _scoreDisplay.SetText(_player.Score.ToString());
    }
}
