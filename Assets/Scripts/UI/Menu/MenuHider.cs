using System;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace UI.Menu
{
    public class MenuHider : MonoBehaviour
    {
        [SerializeField] private AnimationCurve _animationCurve;
        [SerializeField] private float _animationSpeed;

        private RectTransform _rectTransform;
        private Coroutine _moveRoutine;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        public void DisplayHide(bool display)
        {
            if (_moveRoutine != null)
                StopCoroutine(_moveRoutine);

            _moveRoutine = StartCoroutine(Move(display));
        }

        private IEnumerator Move(bool display)
        {
            int directionModifier = display ? 1 : -1;
            
            float time = 0;
            Vector2 startPosition = _rectTransform.anchoredPosition;
            float endTime = _animationCurve.keys.Last().time;

            while (time < endTime)
            {
                float newX = _animationCurve.Evaluate(time);

                _rectTransform.anchoredPosition = new Vector2
                (
                    directionModifier * newX,
                    startPosition.y
                );

                time += Time.deltaTime * _animationSpeed;
                yield return null;
            }
        }
    }
}