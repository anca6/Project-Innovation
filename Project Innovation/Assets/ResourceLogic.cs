using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Resource : MonoBehaviour
{
    [SerializeField]
    GameManager gameManager;

    [SerializeField]
    ResourceManager resourceManager;

    [SerializeField]
    LandmarkManager landmarkManager;

    void Start()
    {
        // Add an EventTrigger component to the resource object
        EventTrigger eventTrigger = gameObject.AddComponent<EventTrigger>();

        // Create a new entry for the click event
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;

        // Add a callback for the click event
        entry.callback.AddListener((eventData) => { OnClick(); });

        // Add the entry to the event trigger
        eventTrigger.triggers.Add(entry);
    }

    public void OnClick()
    {
        if (landmarkManager != null && landmarkManager.canClick)
        {
                resourceManager.AddElixir(1);
                Debug.Log("RESOURCE ADDED");

                gameObject.SetActive(false);

        }
    }
}