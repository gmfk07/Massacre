using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageManager : MonoBehaviour
{
    public GameObject chatPanel, textObject;
    [SerializeField] private Color teenActionTextColor;
    [SerializeField] private Color killerActionTextColor;

    //Post a new message with given text, using appropriate coloring based on isTeenAction
    public void PostMessage(string text, bool isTeenAction)
    {
        Message newMessage = new Message();
        GameObject newTextObject = Instantiate(textObject, chatPanel.transform);

        newMessage.text = text;
        newMessage.textObject = newTextObject.GetComponent<Text>();
        newMessage.textObject.text = newMessage.text;
        newMessage.textObject.color = isTeenAction ? teenActionTextColor : killerActionTextColor;
    }
}

[System.Serializable]
public class Message
{
    public string text;
    public Text textObject;
}
