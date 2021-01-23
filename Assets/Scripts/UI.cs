using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static Text Wave, Credits;
    static Text Message;

    private void Start()
    {
        Credits = GameObject.Find("Credits").GetComponent<Text>();
        Wave = GameObject.Find("Wave").GetComponent<Text>();
        Message = GameObject.Find("Message").GetComponent<Text>();
    }

    public static string wave
    {
        get => Wave.text;
        set => Wave.text = $"Wave: {value}";
    }

    public static string credits
    {
        get => Credits.text;
        set => Credits.text = $"Credits: {value}";
    }

    public static void UpdateProgressState()
    {
        credits = GameProgress.Credits.ToString();
        wave = GameProgress.Wave.ToString();
    }

    public static void ShowMessage(string message)
    {
        Message.text = message;
    }

    public static IEnumerator StopShowMessage()
    {
        yield return new WaitForSeconds(2f);
        Message.text = null;
    }
}
