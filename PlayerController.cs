using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class PlayerController : MonoBehaviour
{
    private Vector3 startMarker; 

    private bool isDead;
    private Vector3 endmarker;

    private float endPosition = 8.79f;

    public float speed = 50.0f;


    private Dictionary<string, Action> keywordActions = new Dictionary<string, Action>();
    private KeywordRecognizer keywordRecognizer;

    private Vector3 horizontalDistance;

    public Vector3 pastPosition; 

    private bool rightBool; 

    private bool leftBool;
    

    public float vectorDistance;

    public GameObject panel;

    
    
    public float mSpeed = 1.0F;

    private float startTime;

    private float journeyLength;



    // Start is called before the first frame update
    void Start()
    {


        keywordActions.Add("right", Right);
        keywordActions.Add("left", Left);

        keywordRecognizer = new KeywordRecognizer(keywordActions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += OnKeywordsRecognized;
        keywordRecognizer.Start();

        startTime = Time.time;
        panel.SetActive(false);

        transform.Translate(0, 0, 0);



    }

    
    private void OnKeywordsRecognized(PhraseRecognizedEventArgs args)
    {

        Debug.Log("Keyword: " + args.text);
        keywordActions[args.text].Invoke();
    }

    private void Right()
    {
        rightBool = true;
        leftBool = false;

        endPosition = 8.79f;

        Debug.Log("Right was called");

  



    }


    private void Left()
    {


        leftBool = true;
        rightBool = false;

        endPosition = -2.65f;

     
        Debug.Log("LEFT WAS CALLED");
    

    }

    void OnCollisionEnter(Collision col) {

        if(col.gameObject.tag == "Obstacle") {
            
            panel.SetActive(true);

            Debug.Log("Game Over");

        }
    }

  
    // Update is called once per frame
    void Update()
    {

        
        startMarker = transform.position;
        endmarker = new Vector3(endPosition, startMarker.y, startMarker.z);
        transform.position = Vector3.Lerp(startMarker, endmarker, Time.deltaTime * speed);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        transform.rotation = Quaternion.identity;

        }
    }







