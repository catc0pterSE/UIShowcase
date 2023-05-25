using System;
using System.Collections.Generic;
using ObjectSpawning;
using SceneObjects;
using UnityEngine;
using UnityEngine.UI;
using Utility.Extensions;

namespace UI.Menu
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] LayoutGroup _objectCardsParent;

        private readonly List<ObjectCard> _selectedObjectCards = new List<ObjectCard>();

        private ObjectCard[] _objectCards;

        public void Initialize(GameObjectFactory gameObjectFactory, Cube[] objects)
        {
            InitializeObjectCards(objects, gameObjectFactory);
        }

        private void OnDestroy() =>
            _objectCards.Map(objectCard => objectCard.SelectedStatusChanged -= OnObjectCardSelectedStatusChanged);

        public void SetAllCardsSelected(bool value) =>
            _objectCards.Map(objectCard => objectCard.SetSelected(value));

        public void SetSelectedCardsActive(bool value) =>
            _selectedObjectCards.Map(objectCard => objectCard.SetActive(value));

        public void SetSelectedCardsAlphaLevel(float percentValue) =>
            _selectedObjectCards.Map(objectCard => objectCard.SetAlphaLevel(percentValue));

        private void InitializeObjectCards(Cube[] objects, GameObjectFactory gameObjectFactory)
        {
            _objectCards = new ObjectCard[objects.Length];

            for (int i = 0; i < objects.Length; i++)
            {
                ObjectCard objectCard = gameObjectFactory.CreateObjectCard(_objectCardsParent);
                objectCard.Initialize(objects[i]);
                objectCard.SelectedStatusChanged += OnObjectCardSelectedStatusChanged;
                _objectCards[i] = objectCard;
            }
        }

        private void OnObjectCardSelectedStatusChanged(ObjectCard objectCard, bool status)
        {
            if (status == true)
                AddSelectedObjectCard(objectCard);
            else
                RemoveSelectedObjectCard(objectCard);
        }

        private void AddSelectedObjectCard(ObjectCard objectCard)
        {
            if (_selectedObjectCards.Contains(objectCard))
                return;

            _selectedObjectCards.Add(objectCard);
        }

        private void RemoveSelectedObjectCard(ObjectCard objectCard)
        {
            if (_selectedObjectCards.Contains(objectCard) == false)
                return;

            _selectedObjectCards.Remove(objectCard);
        }
    }
}