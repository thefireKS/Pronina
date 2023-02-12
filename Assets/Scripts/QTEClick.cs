
using System;
using UnityEngine;

public class QTEClick : MonoBehaviour
{
    [SerializeField] private GameObject Arrow;
    [SerializeField] private GameObject clickBarGO;
    private float mainBarWidth, normalizedMainWidth, arrowPosition;
    private RectTransform mainBarRT, clickBarRT;
    [SerializeField] private float arrowSpeed = 1;
    [SerializeField] [Range(0,1)] private float clickBarPosition = 0.5f;
    [SerializeField] [Range(0,1)] private float clickBarPercent = 0.5f;
    [SerializeField] private KeyCode clickKey;

    private void Start()
    {
        mainBarRT = GetComponent<RectTransform>();
        clickBarRT = clickBarGO.GetComponent<RectTransform>();
        mainBarWidth = mainBarRT.sizeDelta.x;

        clickBarGO.transform.localPosition = new Vector3(clickBarPosition * mainBarWidth, 0, 0);

        clickBarRT.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, clickBarPercent*mainBarWidth);

    }

    void Update()
    {
        ArrowMovement();
    }

    void ArrowMovement()
    {
        arrowPosition = Arrow.transform.localPosition.x;
        
        
        //Debug.Log(arrowPosition);
        //trying ping pong movement
        /*
        bool movingForward = true;
        if (arrowPosition < mainBarWidth && movingForward)
        {
            Arrow.transform.position += new Vector3(arrowSpeed, 0, 0) * Time.deltaTime;
            if (Math.Abs(arrowPosition - mainBarWidth) < 1) //if arrowPos == mainBarWidth
            {
                movingForward = false;
            }
        }
        else 
        {
            Arrow.transform.position -= new Vector3(arrowSpeed, 0, 0) * Time.deltaTime;
            if (arrowPosition == 0)
            {
                movingForward = true;
            }
        }
        */
        //Arrow.transform.localPosition = new Vector3(Mathf.PingPong(Time.deltaTime, mainBarWidth) * arrowSpeed, 0, 0);
        
        Arrow.transform.localPosition += new Vector3(arrowSpeed, 0, 0)*Time.deltaTime;
        if (Math.Abs(arrowPosition - mainBarWidth) < 1)
        {
            Arrow.transform.localPosition = new Vector3(0, -50, 0);
        }
        
        if(Input.GetKeyDown(clickKey))
            isHit();
    }
    void isHit()
    {
        if (arrowPosition > clickBarPosition * mainBarWidth && arrowPosition < (clickBarPosition + clickBarPercent)*mainBarWidth)
        {
            Debug.Log("U got it");
        }
    }
}
