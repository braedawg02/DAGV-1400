using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class GameConsole : MonoBehaviour
{
    public GameObject console;
    protected TMP_InputField inputField;
    
    // Start is called before the first frame update
    void Start()
    {
        console.SetActive(false);
        inputField.Select();
      
        
    }
    protected TMP_InputField.EditState KeyPressed(Event evt)
    {
        if (evt.keyCode == KeyCode.Return)
        {
            Debug.Log("Enter key pressed");
            return TMP_InputField.EditState.Finish;
        }
        return TMP_InputField.EditState.Continue;
    }
    void LockInput(InputField input)
    {
		if (input.text.Length > 0) 
		{
			Debug.Log("Text has been entered");
		}
		else if (input.text.Length == 0) 
		{
			Debug.Log("Main Input Empty");
		}
	}
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.BackQuote))
        {
            console.SetActive(!console.activeSelf);
            Debug.Log("Console Opened");
        }
    }
}
