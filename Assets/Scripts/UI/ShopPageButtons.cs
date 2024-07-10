using UnityEngine;

public class ShopPageButtons : MonoBehaviour
{
    [SerializeField] private ShopPage[] _shopPages;
    private int _selectedPageIndex = 0;

    private void Start()
    {
        _shopPages[_selectedPageIndex].OpenPage();
    }

    public void OpenPage(int index)
    {
        if (index >= _shopPages.Length)
            return;

        if (_selectedPageIndex == index)
            return;

        _shopPages[_selectedPageIndex].ClosePage();
        _selectedPageIndex = index;
        _shopPages[_selectedPageIndex].OpenPage();
    }
}
