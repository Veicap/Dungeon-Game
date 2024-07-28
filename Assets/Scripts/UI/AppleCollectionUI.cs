using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AppleCollectionUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI numberOfAppleText;

    private void Update()
    {
        numberOfAppleText.text = ItemCollectedManager.Instance.GetNumberOfAppleCollected().ToString();
    }
}
