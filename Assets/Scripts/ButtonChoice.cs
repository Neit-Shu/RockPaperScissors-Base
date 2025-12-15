using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonChoice : MonoBehaviour
{
    public static event Action<Figure, bool> SendChoice;
    [SerializeField] private Figure _buttonChoice;
    [SerializeField] private bool _isPlayerOne;
    private Button _button;
    private GameManager _gameManagerScript;
    private void Awake()
    {
        _button = GetComponent<Button>();
        _gameManagerScript = FindFirstObjectByType<GameManager>(FindObjectsInactive.Include);                                   

        if (_gameManagerScript == null)
        {
            throw new Exception("GameManager component was missing on the " + gameObject.name);      
        }
    }

    

    private void OnEnable()
    {
        _button.onClick.AddListener(ChoiceSelected);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ChoiceSelected);
    }

    private void ChoiceSelected()
    {
        SendChoice?.Invoke(this._buttonChoice, this._isPlayerOne);
        if (_gameManagerScript._isVersusAi)
        {
            Figure rFigure = (Figure)UnityEngine.Random.Range(0, 3);
            SendChoice?.Invoke(rFigure, false);
        }
    }
}