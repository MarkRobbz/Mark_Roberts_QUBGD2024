using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{

    public Camera mainCam;
    public Camera firstPersonCam;
    public KeyCode switchKey;

    private int currentIndex;
    // Start is called before the first frame update
    void Start()
    {
        mainCam.gameObject.SetActive(true);
        firstPersonCam.gameObject.SetActive(false); //First Person Cam
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(switchKey) && mainCam.isActiveAndEnabled)
        {
            mainCam.gameObject.SetActive(false);
            firstPersonCam.gameObject.SetActive(true); 
        } else if (Input.GetKeyDown(switchKey) && firstPersonCam.isActiveAndEnabled)
        {
            mainCam.gameObject.SetActive(true);
            firstPersonCam.gameObject.SetActive(false); 
        }
        
    }
}
