using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RatBehav : MonoBehaviour
{
    // Start is called before the first frame update
    public bool changeOnce = false;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.lives == 2 && !changeOnce)
        {
            GetComponent<RawImage>().texture = GameManager.instance.hurtRat.texture;
            changeOnce = true;
        }
    }
}
