using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WooBee : MonoBehaviour
{
    public Text display;
    public bool firstRound;
    
    public int roundIndex;
    
    private float timer = 0;
    private float timePerTurn = 5;
    
    public string[][][] questionArray;
    
    public GameObject questionA;
    // Start is called before the first frame update
    void Start()
    {
        firstRound = true;
        
        questionArray = new string[4][][];
        questionArray[0] = new string[][] { new string[] { "What's before W?", "Q" } };
        questionArray[1] = new string[][] { new string[] { "What's after R?", "T" } };
        questionArray[2] = new string[][] { new string[] { "asdf_", "G" } };
        questionArray[3] = new string[][] { new string[] { "don't move", " " } };
        roundIndex = -1;
    }

    // Update is called once per frame
    void Update()
    {
        // Increase the timer.
        timer += Time.deltaTime;
        
        if (Input.anyKeyDown)
        {
            foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(keyCode))
                {
                    string keyString = keyCode.ToString();
                    CheckInput(keyString);
                }
            }
        }
        
        if (timer >= timePerTurn)
        {
            display.text = "Time is up!\n";

            if (firstRound)
            {
                LoadRound();
                firstRound = false;
                return;
            }
            else if (timer + 20 >= timePerTurn && roundIndex == questionArray.Length - 1)
            {
                Debug.Log("Lives: " + GameManager.instance.lives);
                GameManager.instance.hasEnglished = true;
                SceneManager.LoadScene("LOBBY");
            }
            else if (timer + 20 >= timePerTurn)
            {
                GameManager.instance.MinusP();
                Debug.Log("Lives: " + GameManager.instance.lives);
                SceneManager.LoadScene("LOBBY");
            }
            
        }
        else
        {
            // Display the timer
            display.text = (timePerTurn - timer).ToString("F2");
        }
    }

    public void LoadRound()
    {
        questionA.GetComponent<Text>().text = questionArray[roundIndex][0][0];
        timer = 0;
    }

    public bool CheckInput(string key)
    {
        if (firstRound)
        {
            roundIndex++;
        }
        Debug.Log(questionArray[roundIndex][0][1]);
        Debug.Log(key);
        if (key == questionArray[roundIndex][0][1] || firstRound)
        {
            Debug.Log("true");
            if (!firstRound)
            {
                roundIndex++;
            }
            LoadRound();
            return true;
        }
        else
        {
            GameManager.instance.lives--;
            SceneManager.LoadScene("LOBBY");
            return false;
        }
    }
}
