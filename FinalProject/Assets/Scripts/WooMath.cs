using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WooMath : MonoBehaviour
{
    public Text display;
    private float timer = 0;
    private float timePerTurn = 5;

    public GameObject canva;
    private GameObject opt;
    public int roundIndex;

    public bool lastRound;
    
    public GameObject wrongAnswer;
    public GameObject rightAnswer;
    public GameObject questionA;
    public string[][][] questionArray;

    public List<GameObject> round;
    public bool firstRound;

    public GameObject bullFrog;
    public GameObject smullFrog;

    // Start is called before the first frame update
    void Start()
    {
        questionArray = new string[4][][];
        questionArray[0] = new string[][] { new string[] { "6x8", "42" } };
        questionArray[1] = new string[][] { new string[] { "16/4", "4" } };
        questionArray[2] = new string[][] { new string[] { "(8 + 4) * 2 - 9 / 3", "13" } };
        questionArray[3] = new string[][] { new string[] { "stop.", "stop" } };
        roundIndex = 0;
        
        firstRound = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Increase the timer.
        timer += Time.deltaTime;
        
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
                GameManager.instance.hasMathed = true;
                SceneManager.LoadScene("LOBBY");
            }
            else if (timer + 20 >= timePerTurn)
            {
                GameManager.instance.MinusP();
                Debug.Log("Lives: " + GameManager.instance.lives);
                SceneManager.LoadScene("LOBBY");
            }

            smullFrog.SetActive(false);
            bullFrog.SetActive(true);
        }
        else
        {
            // Display the timer
            display.text = (timePerTurn - timer).ToString("F2");
        }
        
    }

    public void ClearRound()
    {
        foreach (GameObject obj in round)
        {
            Destroy(obj);
        }
        round.Clear();
    }

    public void LoadRound()
    {
        int numberOfObjects = 4;
        float[] offsets = new float[numberOfObjects];
        var offset = 400f;

        var randomRight = Random.Range(0, (numberOfObjects-1));
        
        questionA.GetComponent<Text>().text = questionArray[roundIndex][0][0];

        // Generate random offsets for each object
        for (int i = 0; i < numberOfObjects; i++)
        {
            offsets[i] = Random.Range(-200f, 200f);
        }

        // Instantiate objects and set their positions using the generated offsets
        for (int i = 0; i < numberOfObjects; i++)
        {
            if (randomRight == i || roundIndex == questionArray.Length - 1)
            {
                opt = Instantiate(rightAnswer, canva.transform);
                opt.GetComponent<Text>().text = questionArray[roundIndex][0][1];
                round.Add(opt);
            }
            else
            {
                opt = Instantiate(wrongAnswer, canva.transform);
                opt.GetComponent<Text>().text = "" + Random.Range(0, 99);
                round.Add(opt);
            }

            Vector3 position = Vector3.zero;

            if (i == 0)
            {
                position = Vector3.zero; // First object at the center
            }
            else if (i % 2 == 0)
            {
                position = new Vector3(offsets[i] + offset, Random.Range(-300, 120), 0f); // Even indexed objects offset to the right
            }
            else
            {
                position = new Vector3(offsets[i] - offset, Random.Range(-200, 200), 0f); // Odd indexed objects offset to the left
            }

            opt.transform.localPosition = position;
        }

        roundIndex++;
        timer = 0;
    }
}
