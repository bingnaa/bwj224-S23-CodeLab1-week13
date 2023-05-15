using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HitB2 : MonoBehaviour
{
    [SerializeField] private Button btn = null;
    
    // Start is called before the first frame update
    private void Start()
    {
        btn.onClick.AddListener(NoParamaterOnclick);
    }
    
    private void NoParamaterOnclick()
    {
        SceneManager.LoadScene("Scenes/ENGLISHGAME");
    }
}
