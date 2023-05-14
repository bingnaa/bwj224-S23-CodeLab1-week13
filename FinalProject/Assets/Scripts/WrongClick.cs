using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class WrongClick : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("UI object clicked: " + gameObject.name);

        // Perform additional actions when the UI object is clicked
        GameManager.instance.MinusP();
        Debug.Log("Lives: " + GameManager.instance.lives);
        SceneManager.LoadScene("LOBBY");
    }
}
