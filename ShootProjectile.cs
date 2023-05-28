using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;
 
public class ShootProjectile : MonoBehaviour
{
    public GameObject projectile;
    public int launchVelocity = 15000;
    private KeywordRecognizer keywordRecognizer;
    private float startTime; 
    private Dictionary<string, Action> keywordActions = new Dictionary<string, Action>();

    private bool ShootBool = false;

   void Start()
   {


        
        keywordActions.Add("shoot", Shoot);

        keywordRecognizer = new KeywordRecognizer(keywordActions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += OnKeywordsRecognized;
        keywordRecognizer.Start();

        startTime = Time.time;
   }

    private void OnKeywordsRecognized(PhraseRecognizedEventArgs args)
    {

        Debug.Log("Keyword: " + args.text);
        keywordActions[args.text].Invoke(); }


    private void Shoot() {
        ShootBool = true;
    }
   void Update()
   {
    
       if (ShootBool)
       {
           GameObject ball = Instantiate(projectile, transform.position,  
                                                     transform.rotation);
           ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3 
                                                (0, 0,launchVelocity));

         ShootBool = false;

           
       }
       else{
        Debug.Log("Else");
        Destroy(projectile, 2f);
        

       }

       
   }


} 
