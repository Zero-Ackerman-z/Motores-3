using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class life : MonoBehaviour
{
    public Sprite[] corazones;
        
    // Start is called before the first frame update
    void Start()
    {
        cambiovida(5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void cambiovida(int pos)
    {
        this.GetComponent<Image>().sprite = corazones[pos];
    }

}
