using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //static variable means the value is the same for all the objects of this class type and the class itself
    public static GameManager instance; //this static var will hold the Singleton
    
    public int lives = 3;
    
    public Sprite hurtRat;
    public Sprite smashPaper;
    
    // Start is called before the first frame update
    
    void Awake()
    {
        if (instance == null) //instance hasn't been set yet
        {
            DontDestroyOnLoad(gameObject);  //Dont Destroy this object when you load a new scene
            instance = this;  //set instance to this object
        }
        else  //if the instance is already set to an object
        {
            Destroy(gameObject); //destroy this new object, so there is only ever one
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void MinusP()
    {
        lives--;
        // if (lives == 2)
        // {
        //     rat.gameObject.GetComponent<RawImage>().texture = hurtRat.texture;
        //     l1.gameObject.GetComponent<RawImage>().texture = smashPaper.texture;
        // }
    }

    public void LoadMathGame()
    {
        Debug.Log("hit");
        SceneManager.LoadScene("Scenes/MATHGAME");
    }
}
