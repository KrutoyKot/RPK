using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField]private Text coinText;
    
    public int coinCounter;

    private void Update()
    {
        if (panel.activeSelf == true)
        {
            coinText.text = coinCounter.ToString();
        }
    }
}
