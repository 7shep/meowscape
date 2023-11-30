using UnityEngine;
using UnityEngine.UI;
public class SelectionManager : MonoBehaviour
{

    public GameObject interaction_Info_UI;
    Text interaction_text;

    private void Start()
    {
        if (interaction_Info_UI != null)
        {
            interaction_text = interaction_Info_UI.GetComponent<Text>();
            if (interaction_text == null)
            {
                Debug.LogError("Text component not found on interaction_Info_UI GameObject!");
            }
        }
        else
        {
            Debug.LogError("interaction_Info_UI reference is not set!");
        }
    }


    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selectionTransform = hit.transform;

            if (selectionTransform.GetComponent<InteractableObject>())
            {
                interaction_text.text = selectionTransform.GetComponent<InteractableObject>().GetItemName();
                interaction_Info_UI.SetActive(true);
            }
            else
            {
                interaction_Info_UI.SetActive(false);
            }

        }
    }
}