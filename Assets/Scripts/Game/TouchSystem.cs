using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSystem : MonoBehaviour
{
    public EggRocketManager eggRocketManager;
    private void Update()
    {
        if(Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
                eggRocketManager.endPointX = CreateEndPoint(touch);
        }
    }

    float CreateEndPoint(Touch touchCoordinate)
    {
        float xEndPoint = Camera.main.ScreenToWorldPoint(touchCoordinate.position).x;
        return xEndPoint;
    }
}
