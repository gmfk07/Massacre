using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageManager : MonoBehaviour
{
    public GameObject chatPanel, textObject;

    public void Update()
    {
        if (Input.GetButtonDown("Jump"))
            PostMessage(Random.Range(0, 10).ToString());
    }

    //Post a new message with given text
    public void PostMessage(string text)
    {
        Message newMessage = new Message();
        GameObject newTextObject = Instantiate(textObject, chatPanel.transform);

        newMessage.text = text;
        newMessage.textObject = newTextObject.GetComponent<Text>();
        newMessage.textObject.text = newMessage.text;
    }
}

[System.Serializable]
public class Message
{
    public string text;
    public Text textObject;
}
