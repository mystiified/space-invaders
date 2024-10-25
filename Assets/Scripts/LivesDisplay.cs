using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    
    TMPro.TextMeshProUGUI livesText;
    private void Start()
    {
        livesText = GetComponent<TMPro.TextMeshProUGUI>();
    }


    void Update()
    {
        livesText.text = "Lives : " + (GameManager.Instance.lives + 1);
    }
}
