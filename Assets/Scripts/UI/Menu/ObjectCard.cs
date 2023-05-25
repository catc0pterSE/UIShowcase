using System;
using SceneObjects;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Menu
{
    public class ObjectCard : MonoBehaviour
    {
        [SerializeField] private Toggle _selectedToggle;
        [SerializeField] private Toggle _objectActiveToggle;
        [SerializeField] private Image _selectedFrame;
        [SerializeField] private Image _selectedCheckImage;

        private Cube _object;

        public void Initialize(Cube @object, bool selected = false, bool active = true)
        {
            _object = @object;
            SetSelected(selected);
            SetActive(active);
        }

        public event Action<ObjectCard, bool> SelectedStatusChanged;

        public void SetSelected(bool value) =>
            _selectedToggle.isOn = value;

        public void SetActive(bool value) =>
            _objectActiveToggle.isOn = value;

        public void SetAlphaLevel(float percentValue) =>
            _object.SetAlphaLevel(percentValue);

        private void OnEnable()
        {
            _selectedToggle.onValueChanged.AddListener(OnSelectedValueChanged);
            _objectActiveToggle.onValueChanged.AddListener(OnActiveValueChanged);
        }

        private void OnDisable()
        {
            _selectedToggle.onValueChanged.RemoveListener(OnSelectedValueChanged);
            _objectActiveToggle.onValueChanged.RemoveListener(OnActiveValueChanged);
        }

        private void OnSelectedValueChanged(bool value)
        {
            _selectedFrame.gameObject.SetActive(value);
            _selectedCheckImage.gameObject.SetActive(value);
            SelectedStatusChanged?.Invoke(this, value);
        }

        private void OnActiveValueChanged(bool value)
        {
            _object.gameObject.SetActive(value);
        }
    }
}