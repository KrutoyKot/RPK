using UnityEngine;

public class PanelControll : MonoBehaviour
{
    [SerializeField] private GameObject panelInventory;
    [SerializeField] private GameObject panelMagic;
    [SerializeField] private GameObject panelInfo;

    private bool isPanel;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPanel == false)
        {
            panelInventory.SetActive(true);
            isPanel = true;
            return;
        }
        PanelActive();
    }
    private void PanelActive()
    {
        if (isPanel && Input.GetKeyDown(KeyCode.Alpha1))
        {
            panelInfo.SetActive(false);
            panelMagic.SetActive(false);
        }
        else if (isPanel && Input.GetKeyDown(KeyCode.Alpha2))
        {
            panelInfo.SetActive(false);
            panelMagic.SetActive(true);
        }
        else if (isPanel && Input.GetKeyDown(KeyCode.Alpha3))
        {
            panelInfo.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.E) && isPanel)
        {
            panelInventory.SetActive(false);
            panelInfo.SetActive(false);
            panelMagic.SetActive(false);
            isPanel = false;
        }
    }
}
