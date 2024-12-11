using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Rocket : MonoBehaviour, IPointerClickHandler
{

    public void OnPointerClick(PointerEventData eventData)
    {
        TransitionManager.Instance.LoadScene(TransitionManager.SCENE_MERCADER);
    }

}
