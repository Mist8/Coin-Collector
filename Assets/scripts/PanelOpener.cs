using UnityEngine;

public class PanelOpener : MonoBehaviour
{
    public GameObject panelOrCanvas; //panel OR canvas GameObject that will be opened/closed

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (panelOrCanvas != null) //hide panel/canvas on game start
        {
            panelOrCanvas.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    //targetCanvasOrPanel.activeSelf: active status
    
    public void ToggleVisibility()
    {
        if (panelOrCanvas != null)
        {
            panelOrCanvas.SetActive(!panelOrCanvas.activeSelf); //toggle visibility of the panel
        }
    }
}
