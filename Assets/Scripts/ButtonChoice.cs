using UnityEngine;

public class ButtonChoice : MonoBehaviour
{
    [SerializeField] private Figure _playerChoice;
    [SerializeField] private bool _isPlayerOne;
    private GameManager _gameManager;
    void Awake()
    {
        _gameManager = FindFirstObjectByType<GameManager>();
    }

    public void ChoiceButton()
    {
        _gameManager.Choice(_playerChoice, _isPlayerOne);
    }
}
