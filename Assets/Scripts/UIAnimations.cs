using UnityEngine;

public class UIAnimations : MonoBehaviour
{
    [Header("Player ONE animators")]
    [SerializeField] private Animator _playerOneSelectedImageAnimator;
    [SerializeField] private Animator _playerOneChoiceAnimator;
    [Header("Player TWO animators")]
    [SerializeField] private Animator _playerTwoSelectedImageAnimator;
    [SerializeField] private Animator _playerTwoChoiceAnimator;

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
}
