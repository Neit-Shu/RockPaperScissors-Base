using UnityEngine;

public class UIAnimations : MonoBehaviour
{
    [SerializeField] private Animator _playerOneChoiceAnimator;
    [SerializeField] private Animator _playerOneSelectedImageAnimator;
    [SerializeField] private Animator _playerTwoChoiceAnimator;
    [SerializeField] private Animator _playerTwoSelectedImageAnimator;
    private void OnEnable()
    {
        GameManager.SendState += OnState;
    }

    private void OnDisable()
    {
        GameManager.SendState -= OnState;
    }
    private void OnState(State state)
    {
        PlayAnimation(state);
    }
    private void PlayAnimation(State state)
    {
        if (state == State.STARTROUND)
        {
            _playerOneChoiceAnimator.Play("PlayerOneChoiceMoveForward");
            _playerTwoChoiceAnimator.Play("PlayerTwoChoiceMoveForward");
            _playerOneSelectedImageAnimator.Play("PlayerOneSelectedImageMoveBackward");
            _playerTwoSelectedImageAnimator.Play("PlayerTwoSelectedImageMoveBackward");
        }
        else
        {
            _playerOneChoiceAnimator.Play("PlayerOneChoiceMoveBackward");
            _playerTwoChoiceAnimator.Play("PlayerTwoChoiceMoveBackward");
            _playerOneSelectedImageAnimator.Play("PlayerOneSelectedImageMoveForward");
            _playerTwoSelectedImageAnimator.Play("PlayerTwoSelectedImageMoveForward");
        }
    }
}