using System.Collections;
using System.Collections.Generic;
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
    
    public LocationScriptableObject currentLocation;
    
    void Start()
    {
        TextAsset fileText = Resources.Load<TextAsset>("Data");
        
        Debug.Log(fileText.text);
        
        UpdateLocation();
    }

    void UpdateLocation()
    {
        title.text = currentLocation.locationName;
        left.gameObject.GetComponentInChildren<Text>().text = currentLocation.left.name;
        right.gameObject.GetComponentInChildren<Text>().text = currentLocation.right.name;
        
        backG.texture = currentLocation.backdrop.texture;

        if (currentLocation.name == mathGame.gameObject.tag)
        {
            mathGame.gameObject.SetActive(true);
        }
        else
        {
            mathGame.gameObject.SetActive(false);
        }
        // else if (currentLocation.name == englishGame.gameObject.tag)
        // {
        //     englishGame.gameObject.SetActive(true);
        // }
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
