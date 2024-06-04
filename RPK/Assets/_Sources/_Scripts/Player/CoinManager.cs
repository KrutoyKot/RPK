using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField]private Text _coinText;
    
    public int coinCounter;

    private void Update()
    {
        if (panel.activeSelf == true)
        {
            _coinText.text = coinCounter.ToString();
        }
    }
}
