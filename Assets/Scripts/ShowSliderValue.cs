// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using TMPro;
using UnityEngine;
using MixedReality.Toolkit.UX;

namespace Microsoft.MixedReality.Toolkit.Examples.Demos
{
    public class ShowSliderValue : MonoBehaviour
    {
        [SerializeField]
        private TextMeshPro textMesh = null;

        public void OnSliderUpdated(SliderEventData eventData)
        {
            if (textMesh == null)
            {
                textMesh = GetComponent<TextMeshPro>();
            }

            if (textMesh != null)
            {
                textMesh.text = $"{eventData.NewValue}";
            }
        }
    }
}
