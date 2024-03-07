using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyJournal : MonoBehaviour
{
    public static DontDestroyJournal Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
}
