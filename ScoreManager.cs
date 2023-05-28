using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreManager : MonoBehaviour
{


    public TextMeshProUGUI scoreValueText;

    public int score;

    public Transform playerTransform;
    // Start is called before the first frame update
    
    void Update()
    {
        score = (int)playerTransform.position.z + 4;
        scoreValueText.text = (score).ToString();
        
        


    }
}
