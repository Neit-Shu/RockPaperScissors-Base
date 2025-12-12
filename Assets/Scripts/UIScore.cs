using UnityEngine;
using TMPro;

public class UIScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _playerOneScoreText;
    [SerializeField] private TextMeshProUGUI _playerTwoScoreText;
    [SerializeField] private TextMeshProUGUI _endRoundMessageText;
    private int _playerOneCurrentScore = 0;
    private int _playerTwoCurrentScore = 0;
    [TextArea(minLines: 2, maxLines: 4)]
    [SerializeField] private string _gameContinueMessageText = "<color=green>Нажмите на экран для продолжения.</color>";
    private void OnEnable()
    {
        GameManager.SendState += OnState;
    }

    private void OnDisable()
    {
        GameManager.SendState -= OnState;
    }
    private void Awake()
    {
        SetScoreText(_playerOneScoreText, _playerOneCurrentScore, _playerTwoCurrentScore);
        SetScoreText(_playerTwoScoreText, _playerTwoCurrentScore, _playerOneCurrentScore);
    }
    private void OnState(State state)
    {
        if (state == State.PLAYER1WIN)
        {
            _playerOneCurrentScore++;
            _endRoundMessageText.SetText("<color=white>Игрок 1 выиграл!</color>\n \n " + _gameContinueMessageText);
        }
        else if (state == State.PLAYER2WIN)
        {
            _playerTwoCurrentScore++;
            _endRoundMessageText.SetText("<color=black>Игрок 2 выиграл!</color>\n \n " + _gameContinueMessageText);
        }
        else if (state == State.DRAW)
        {
            _endRoundMessageText.SetText("<color=red>Ничья!</color>\n \n " + _gameContinueMessageText);
        }
        else
        {
            _endRoundMessageText.SetText("");
        }

        SetScoreText(_playerOneScoreText, _playerOneCurrentScore, _playerTwoCurrentScore);
        SetScoreText(_playerTwoScoreText, _playerTwoCurrentScore, _playerOneCurrentScore);
    }
    private void SetScoreText(TextMeshProUGUI text, int player1Score, int player2Score)
    {
        text.SetText($"{player1Score} / {player2Score}");
    }
}

