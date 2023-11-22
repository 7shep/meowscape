using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{

    public GameObject interaction_Info_UI;
    Text interactionText;

    // Start is called before the first frame update
    void Start()
    {
        interactionText = interaction_Info_UI.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit))
        {
            var selectionTransform = hit.transform;
            if(selectionTransform.GetComponent<InteractableObjects>())
            {
                interactionText.text = selectionTransform.GetComponent<InteractableObjects>().GetItemName();
                interaction_Info_UI.SetActive(true);
            }
            else // If there is a hit, but w/o an interactable script
            {
                interaction_Info_UI.SetActive(false);
            }
        }
        else // no hit at all!
        {
            interaction_Info_UI.SetActive(false);
        }
    }
}
