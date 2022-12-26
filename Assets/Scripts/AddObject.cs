using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddObject : MonoBehaviour
{
    private Button button;
    private ProgrammManager ProgrammManagerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        ProgrammManagerScript = FindObjectOfType<ProgrammManager>();

        button = GetComponent<Button>();
        button.onClick.AddListener(AddObjectFunction);
    }

    // Update is called once per frame
    void AddObjectFunction()
    {
        ProgrammManagerScript.ScrollView.SetActive(true);
    }
}
