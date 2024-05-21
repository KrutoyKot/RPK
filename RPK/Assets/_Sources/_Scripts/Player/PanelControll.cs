using UnityEngine;

public class PanelControll : MonoBehaviour
{
    [SerializeField] private GameObject panelInventory;
    [SerializeField] private GameObject panelMagic;
    [SerializeField] private GameObject panelInfo;

    private bool isPanel = true;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            panelInventory.SetActive(true);
            isPanel = true;
        }
        PanelActive();
    }
    private void PanelActive()
    {
        if(isPanel && Input.GetKeyDown(KeyCode.Alpha1))
        {
            panelInventory.SetActive(true);
            isPanel = false;
        }
        else if(isPanel && Input.GetKeyDown(KeyCode.Alpha2))
        {
            panelMagic.SetActive(true);
            isPanel = false;
        }        
        else if(isPanel && Input.GetKeyDown(KeyCode.Alpha3))
        {
            panelInfo.SetActive(true);
            isPanel = false;
        }   
    }
}
