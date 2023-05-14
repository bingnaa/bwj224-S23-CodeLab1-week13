using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CorrectClick : MonoBehaviour, IPointerClickHandler
{
    public GameObject mathGame;
    private void Start()
    {
        mathGame = GameObject.FindWithTag("GameController");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("UI object clicked: " + gameObject.name);
        mathGame.GetComponent<WooMath>().ClearRound();
        mathGame.GetComponent<WooMath>().LoadRound();
    }
}