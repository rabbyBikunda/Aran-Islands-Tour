using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System;

public class SceneOrder : MonoBehaviour,IPointerDownHandler
{
     Transform currentImage = null;

    Transform switchObj = null;


     Transform newImage;

   
    //public void changePosition()
    //{       
        //Vector3 temp = currentImage.GetComponent<RectTransform>().position;

        //currentImage.GetComponent<RectTransform>().position = newImage.GetComponent<RectTransform>().position;
        //newImage.GetComponent<RectTransform>().position = temp;

    //}

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.Equals(GetComponent<Image>()))
        {
            currentImage = eventData.pointerCurrentRaycast.gameObject.transform;
            newImage.transform.position = currentImage.transform.position;
        }

        if (currentImage != null)
        { //if noObject now has a transform
            switchObj = eventData.pointerCurrentRaycast.gameObject.transform;
            DoTheSwitch();
        }
    }

    public void DoTheSwitch()
    {
        //throw new NotImplementedException();
        currentImage.transform.position = switchObj.transform.position;//moves the first clicked object to the second clicke objects position
        //switchObj.transform.position = newImage;
        currentImage = null;
    }
}
