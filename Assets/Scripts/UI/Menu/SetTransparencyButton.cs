using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Menu
{
    [RequireComponent(typeof(CanvasGroup))]
    [RequireComponent(typeof(Button))]
    public class SetTransparencyButton : MonoBehaviour
    {
        [SerializeField, Range(0, 1)] private float _alphaPercentValue;
        [SerializeField] private Menu _menu;

        private Button _button;

        private void Awake()
        {
            GetComponent<CanvasGroup>().alpha = _alphaPercentValue;
            _button = GetComponent<Button>();
        }

        private void OnEnable() =>
            _button.onClick.AddListener(OnButtonClick);

        private void OnDisable() =>
            _button.onClick.RemoveListener(OnButtonClick);

        private void OnButtonClick() =>
            _menu.SetSelectedCardsAlphaLevel(_alphaPercentValue);
    }
}