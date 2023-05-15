using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaperBehav2 : MonoBehaviour
{
    // Start is called before the first frame update
    public bool changeLol2 = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.lives <= 1 && !changeLol2)
        {
            GetComponent<RawImage>().texture = GameManager.instance.smashPaper.texture;
            changeLol2 = true;
        }
    }
}
