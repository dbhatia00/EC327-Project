using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class textBox : MonoBehaviour
{
    // Start is called before the first frame update
    public Text myText;
    int test = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        myText.text = test.ToString();

        test++;
    }
}
