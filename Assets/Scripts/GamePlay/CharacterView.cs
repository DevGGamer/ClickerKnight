using UnityEngine;

[RequireComponent(typeof(CharacterAnimation))]
public class CharacterView : MonoBehaviour
{
    private CharacterAnimation _characterAnimation;

    private void Start()
    {
        _characterAnimation = GetComponent<CharacterAnimation>();
    }

    public void OnButtonClicked()
    {
        _characterAnimation.PlayAnimation();
    }
}
