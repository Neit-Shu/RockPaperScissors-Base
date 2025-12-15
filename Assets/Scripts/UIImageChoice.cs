using UnityEngine;
using UnityEngine.UI;
public class UIImageChoice : MonoBehaviour
{
    [SerializeField] private Sprite _rockImage;
    [SerializeField] private Sprite _scissorsImage;
    [SerializeField] private Sprite _paperImage;
    [SerializeField] private Image _playerOneSelectedImage;
    [SerializeField] private Image _playerTwoSelectedImage;
    private void SetSelectedImage(Figure figure, Image image)
    {
        switch (figure)
        {
            case Figure.ROCK:
                image.sprite = _rockImage;
                break;
            case Figure.SCISSORS:
                image.sprite = _scissorsImage;
                break;
            case Figure.PAPER:
                image.sprite = _paperImage;
                break;
        }
    }
    private void OnEnable()
    {
        ButtonChoice.SendChoice += OnChoice;
    }

    private void OnDisable()
    {
        ButtonChoice.SendChoice -= OnChoice;
    }
    private void OnChoice(Figure figure, bool isPlayerOne)
    {
        if (isPlayerOne)
        {
            SetSelectedImage(figure, _playerOneSelectedImage);
        }
        else
        {
            SetSelectedImage(figure, _playerTwoSelectedImage);
        }
    }
}
