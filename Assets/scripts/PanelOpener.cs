using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PanelOpener : MonoBehaviour
{
    public GameObject panelOrCanvas; //panel OR canvas GameObject that will be opened/closed
    public static bool paused = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Start()
    {
        yield return null;
        if (panelOrCanvas != null) //hide panel/canvas on game start
        {
            panelOrCanvas.SetActive(false);
        }

    }

    public void ToggleVisibility()
    {
        if (panelOrCanvas != null)
        {
            //Debug.Log("Toggled!");
            panelOrCanvas.SetActive(!panelOrCanvas.activeSelf); //toggle visibility of the panel

            if (panelOrCanvas.activeSelf)
            { //pause game if panel is open
                Time.timeScale = 0f;
                paused = true;
            }
            else
            {
                Time.timeScale = 1f;
                paused = false;
            }
        }

        /*if (panelOrCanvas != null)
        {
            bool newState = !panelOrCanvas.activeSelf;
            panelOrCanvas.SetActive(newState);

            if (newState) // force UI refresh when showing
            {
                Canvas.ForceUpdateCanvases();
                LayoutRebuilder.ForceRebuildLayoutImmediate(
                    panelOrCanvas.GetComponent<RectTransform>()
                );
            }

            Debug.Log("Toggled! Active: " + newState);
        }*/

    }
}
