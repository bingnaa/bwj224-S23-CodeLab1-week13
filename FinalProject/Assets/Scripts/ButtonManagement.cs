using System.Collections;
using System.Collections.Generic;
using BrewedInk.CRT;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManagement : MonoBehaviour
{
    public Text title;
    // Start is called before the first frame update
    public Button left;
    public Button right;
    public RawImage backG;

    public Button mathGame;
    public Button englishGame;

    public CRTDataObject scary;

    public AudioSource changeHorror;

    public LocationScriptableObject currentLocation;
    
    void Start()
    {
        TextAsset fileText = Resources.Load<TextAsset>("Data");
        
        Debug.Log(fileText.text);
        
        UpdateLocation();
        
        if (GameManager.instance.lives == 1)
        {
            backG.texture = GameManager.instance.ghost.texture;
        }
        if (GameManager.instance.lives <= 0)
        {
            changeHorror.clip = GameManager.instance.horrorSound;
            changeHorror.Play();

            Camera.main.GetComponent<CRTCameraBehaviour>().startConfig = scary;
        }
    }

    void UpdateLocation()
    {
        title.text = currentLocation.locationName;
        left.gameObject.GetComponentInChildren<Text>().text = currentLocation.left.name;
        right.gameObject.GetComponentInChildren<Text>().text = currentLocation.right.name;

        backG.texture = currentLocation.backdrop.texture;

        if (currentLocation.name == mathGame.gameObject.tag && !GameManager.instance.hasMathed)
        {
            mathGame.gameObject.SetActive(true);
        }
        else
        {
            mathGame.gameObject.SetActive(false);
        }
        
        if (currentLocation.name == englishGame.gameObject.tag && !GameManager.instance.hasEnglished)
        {
            englishGame.gameObject.SetActive(true);
        }
        else
        {
            englishGame.gameObject.SetActive(false);
        }
    }

    public void MoveDirection(int dir)
    {
        switch (dir)
        {
            case 0:
                currentLocation = currentLocation.left;
                break;
            case 1:
                currentLocation = currentLocation.right;
                break;
        }
        
        UpdateLocation();
    }
}
