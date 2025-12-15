using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static event Action<State> SendState;
    [SerializeField] private GameObject _endRoundPanel;
   
    private Figure _playerOneChoice = Figure.NONE;
    private bool _isPlayerOneSelected = false;
    private Figure _playerTwoChoice = Figure.NONE;
    private bool _isPlayerTwoSelected = false;
    private bool _isRoundFinished = false;
    public bool _isVersusAi { get; private set; } = true;
    [SerializeField] private GameObject _AIToggleButton;
    private TextMeshProUGUI _AIToggleButtonText;
    private void OnEnable()
    {
        ButtonChoice.SendChoice += OnChoice;
    }

    private void OnDisable()
    {
        ButtonChoice.SendChoice -= OnChoice;
    }
    private void Awake()
    {
        _AIToggleButtonText = _AIToggleButton.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        SetAiButtonText(_isVersusAi);

        StartGame();
    }

    public void StartGame()
    {
        _playerOneChoice = Figure.NONE;
        _isPlayerOneSelected = false;
        _playerTwoChoice = Figure.NONE;
        _isPlayerTwoSelected = false;

        _isRoundFinished = false;

        SendState?.Invoke(State.STARTROUND);
    }

    public void OnChoice(Figure choice, bool isPlayerOne)
    {
        if (_isRoundFinished)
        {
            return;
        }

        if (isPlayerOne)
        {
            _playerOneChoice = choice;

            _isPlayerOneSelected = true;           

           
        }
        else
        {
            _playerTwoChoice = choice;

            _isPlayerTwoSelected = true;
           
        }

        if (_isPlayerOneSelected && _isPlayerTwoSelected)
        {
            _isRoundFinished = true;

            DetermineWinner();
        }
    }

    private void DetermineWinner()
    {
        if (_playerOneChoice == _playerTwoChoice)
        {
            SendState?.Invoke(State.DRAW);
        }
        else if (_playerOneChoice == Figure.ROCK && _playerTwoChoice == Figure.SCISSORS ||
        _playerOneChoice == Figure.SCISSORS && _playerTwoChoice == Figure.PAPER ||
        _playerOneChoice == Figure.PAPER && _playerTwoChoice == Figure.ROCK)
        {
            SendState?.Invoke(State.PLAYER1WIN);
        }
        else
        {
            SendState?.Invoke(State.PLAYER2WIN);
        }

        _endRoundPanel.SetActive(true);
    }

    

    private void SetAiButtonText(bool state)
    {
        if (state)
        {
            _AIToggleButtonText.SetText("vs.\nœ ");
        }
        else
        {
            _AIToggleButtonText.SetText("vs.\n»„ÓÍ");
        }
    }

    public void AiButtonToggle()
    {
        _isVersusAi = !_isVersusAi;

        SetAiButtonText(_isVersusAi);
    }
}