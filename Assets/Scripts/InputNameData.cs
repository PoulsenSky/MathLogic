using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputNameData : MonoBehaviour
{

    public Text namePlayer;
    public InputField inputName;
    public string myName;
    public Button Proceed;

    //Declaring Input Name Text
    public void Start()
    {
        Proceed.interactable = false;
        inputName.onValueChanged.AddListener(ConfirmPlayerName);
    }

    //Making sure if name has been input or otherwise
    public void ConfirmPlayerName(string valueSet) {
        bool isInputValid = !string.IsNullOrEmpty(valueSet);
        Proceed.interactable = isInputValid;
    }

    //Updating Name Input
    /*
    public void NameUpdate(Text theNamePlayer)
    {
        theNamePlayer.text = PlayerPrefs.GetString("user_name");
        if(!string.IsNullOrEmpty(inputName.text)) {
            theNamePlayer.text = inputName.text;
            PlayerPrefs.SetString("user_name", theNamePlayer.text);
            PlayerPrefs.Save();
            Debug.Log("Your name is "+theNamePlayer.text);
        }
    } */

    public void NameUpdate()
    {
        namePlayer.text = PlayerPrefs.GetString("user_name");
        if(!string.IsNullOrEmpty(inputName.text)) {
            namePlayer.text = inputName.text;
            PlayerPrefs.SetString("user_name", namePlayer.text);
            PlayerPrefs.Save();
            Debug.Log("Your name is "+namePlayer.text);
        }
    }
}
