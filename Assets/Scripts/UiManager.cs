using UnityEngine;
using System.Collections.Generic;
public class UiManager : MonoBehaviour
{
    [SerializeField]
    private List<Animator> _buttonList;
    [SerializeField]
    private string _appearAnimationName = "UiObjectAppear";
    [SerializeField]
    private string _dissapearAnimationName = "UiObjectDisappear";
    public void ShowButton()
    {
        foreach (Animator button in _buttonList)
        {
            button.Play(_appearAnimationName);
        }
    }
    public void HideButton()
    {
        foreach (Animator button in _buttonList)
        {
            button.Play(_dissapearAnimationName);
        }
    }
}
