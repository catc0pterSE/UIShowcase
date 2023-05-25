using System;
using UnityEngine;
using Utility.Extensions;
using Random = UnityEngine.Random;

namespace SceneObjects
{
    [RequireComponent(typeof(MeshRenderer))]
    public class Cube : MonoBehaviour
    {
        private readonly float _maxColor =255;
        
        private int _colorProperty;
        private MeshRenderer _meshRenderer;

        private void Awake()
        {
            _colorProperty = Shader.PropertyToID("_Color");
            _meshRenderer = GetComponent<MeshRenderer>();
        }
        
        public void SetAlphaLevel(float normalizedValue)
        {
            if (normalizedValue > 1 || normalizedValue < 0)
                throw new ArgumentException("Invalid normalized value");
            
            Color currentColor = _meshRenderer.material.GetColor(_colorProperty);
            Color newColor = new Color( currentColor.r, currentColor.g, currentColor.b, normalizedValue);
            SetColor(newColor);
        }

        private void SetColor(Color color)
        {
            MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
            materialPropertyBlock.SetColor(_colorProperty,color);
            _meshRenderer.SetPropertyBlock(materialPropertyBlock);
        }
    }
}