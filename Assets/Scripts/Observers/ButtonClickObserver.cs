using System;
using Zenject;

public class ButtonClickObserver : IInitializable, IDisposable
{
    private ClickButton _clickButton;
    private CharacterView _characterView;

    [Inject]
    private void Construct(ClickButton clickButton, CharacterView characterView)
    {
        _clickButton = clickButton;
        _characterView = characterView;
    }

    public void Initialize()
    {
        _clickButton.Clicked += OnButtonClick;
    }

    public void Dispose()
    {
        _clickButton.Clicked -= OnButtonClick;
    }

    private void OnButtonClick()
    {
        _characterView.OnButtonClicked();
    }
}
