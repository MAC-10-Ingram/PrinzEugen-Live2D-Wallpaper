using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Live2D.Cubism.Framework.LookAt; 

public class CubismLookTarget : MonoBehaviour, ICubismLookTarget
{
    public bool flag;
    public Transform center;
    public float range;
    private Vector3 target;
    public Vector3 GetPosition()
    {
        //if (!Input.GetMouseButton(0))
        //{
        //    return Vector3.zero;
        //}

        target = Input.mousePosition;

        target = Camera.main.ScreenToWorldPoint(target);

        Vector3 vec = target - center.position;
        if (flag)
        {
            if (vec.magnitude <= range)
            {
                return target;
            }
            else {
                return vec.normalized * range;
            }
            
        }
        else {
            return Vector3.zero;
        }
        

        //return target;
    }


    public bool IsActive()
    {
        return true;
    }
}
