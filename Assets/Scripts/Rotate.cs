using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    //    Vector3 mPrevPos = Vector3.zero;
    //    Vector3 mPosDelta = Vector3.zero;
    //    public float rotationSpeed = 3f;

    //    private void Update()
    //    {
    //        if (Input.GetMouseButton(0))
    //        {
    //            RaycastHit hit;
    //            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //            if (Physics.Raycast(ray, out hit) && hit.collider != null && hit.collider.gameObject.tag == "Product")
    //            {
    //                Debug.Log("got object");
    //            }
    //            else
    //            {
    //                //Vector3 rotation = transform.rotation.eulerAngles;

    //                //if (Mathf.Approximately(mPrevPos.x, mPrevPos.x))
    //                //    return;
    //                if (mPosDelta.x >= 0)
    //                {
    //                    //rotation.y -= rotationSpeed;
    //                    transform.Rotate(transform.up, -Vector3.Dot(mPosDelta, Camera.main.transform.right), Space.World);
    //                }
    //                else
    //                {
    //                    //rotation.y += rotationSpeed;
    //                    transform.Rotate(transform.up, Vector3.Dot(mPosDelta, -Camera.main.transform.right), Space.World);
    //                }

    //                mPosDelta = Input.mousePosition - mPrevPos;
    //                //transform.rotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
    //                mPrevPos = Input.mousePosition;
    //            }


    //        }

    //    }

    //bool rotating;
    //Vector2 startVector;
    //float rotGestureWidth;
    //float rotAngleMinimum;

    //void Update()
    //{
    //    if (Input.touchCount == 1)
    //    {
    //        if (!rotating)
    //        {
    //            startVector = Input.GetTouch(1).position - Input.GetTouch(0).position;
    //            rotating = startVector.sqrMagnitude > rotGestureWidth * rotGestureWidth;
    //        }
    //        else
    //        {
    //            var currVector = Input.GetTouch(1).position - Input.GetTouch(0).position;
    //            var angleOffset = Vector2.Angle(startVector, currVector);
    //            var LR = Vector3.Cross(startVector, currVector);

    //            if (angleOffset > rotAngleMinimum)
    //            {
    //                if (LR.z >= 0)
    //                {
    //                    //transform.Rotate(transform.up, -Vector3.Dot(currVector, Camera.main.transform.right), Space.World);
    //                    transform.Rotate(transform.up, -angleOffset, Space.World);
    //                    startVector = currVector;
    //                }
    //                else if (LR.z < 0)
    //                {
    //                    transform.Rotate(transform.up, angleOffset, Space.World);
    //                    //transform.Rotate(transform.up, Vector3.Dot(currVector, -Camera.main.transform.right), Space.World);
    //                    startVector = currVector;
    //                }
    //            }
    //        }
    //    }
    //    else
    //    {
    //        rotating = false;
    //    }
    //}
}
