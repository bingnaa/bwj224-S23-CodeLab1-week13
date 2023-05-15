using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaperBehav3 : MonoBehaviour
{
    // Start is called before the first frame update
    public bool changeLol3 = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.lives <= 0 && !changeLol3)
        {
            GetComponent<RawImage>().texture = GameManager.instance.smashPaper.texture;
            changeLol3 = true;
        }
    }
}
