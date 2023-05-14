using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaperBehav1 : MonoBehaviour
{
    // Start is called before the first frame update
    public bool changeLol = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.lives <= 2 && !changeLol)
        {
            GetComponent<RawImage>().texture = GameManager.instance.smashPaper.texture;
            changeLol = true;
        }
    }
}
