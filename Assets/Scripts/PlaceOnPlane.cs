using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace UnityEngine.XR.ARFoundation.Samples
{
    /// <summary>
    /// Listens for touch events and performs an AR raycast from the screen touch point.
    /// AR raycasts will only hit detected trackables like feature points and planes.
    ///
    /// If a raycast hits a trackable, the <see cref="placedPrefab"/> is instantiated
    /// and moved to the hit position.
    /// </summary>
    [RequireComponent(typeof(ARRaycastManager))]
    public class PlaceOnPlane : MonoBehaviour
    {
        // [SerializeField]
        // [Tooltip("Instantiates this prefab on a plane at the touch location.")]
        // GameObject m_PlacedPrefab;

        bool rotating;
        Vector2 startVector;
        float rotGestureWidth;
        float rotAngleMinimum;

        Vector3 mPrevPos = Vector3.zero;
        Vector3 mPosDelta = Vector3.zero;
        public float rotationSpeed = 3f;

        // /// <summary>
        // /// The prefab to instantiate on touch.
        // /// </summary>
        // public GameObject placedPrefab
        // {
        //     get { return m_PlacedPrefab; }
        //     set { m_PlacedPrefab = value; }
        // }

        /// <summary>
        /// The object instantiated as a result of a successful raycast intersection with a plane.
        /// </summary>
        public GameObject spawnedObject { get; set; }

        void Awake()
        {
            m_RaycastManager = GetComponent<ARRaycastManager>();
        }

        bool TryGetTouchPosition(out Vector2 touchPosition)
        {
            if (Input.touchCount > 0)
            {
                touchPosition = Input.GetTouch(0).position;
                return true;
            }

            touchPosition = default;
            return false;
        }

        void Update()
        {
            // if(Input.touchCount > 0)
            // {
            //     RaycastHit hit;
            //     Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            //     if (Physics.Raycast(ray, out hit)) //If ray collides with something
            //     {
            //         if(hit.collider.gameObject.tag == "Button")
            //         {
            //             return;
            //         }
            //     }
            // }

            foreach (Touch touch in Input.touches)
            {
                if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                {
                    // you touched at least one UI element
                    return;
                }
            }

            if (spawnedObject == null)
                    {
                        return;
                    }
                    else{
                        spawnedObject.SetActive(true);
                    }

            if (Input.touchCount == 2)
            {
                if (!rotating)
                {
                    startVector = Input.GetTouch(1).position - Input.GetTouch(0).position;
                    rotating = startVector.sqrMagnitude > rotGestureWidth * rotGestureWidth;
                }
                else
                {
                    var currVector = Input.GetTouch(1).position - Input.GetTouch(0).position;
                    var angleOffset = Vector2.Angle(startVector, currVector);
                    var LR = Vector3.Cross(startVector, currVector);

                    if (angleOffset > rotAngleMinimum)
                    {
                        if (LR.z > 0)
                        {
                            //transform.Rotate(transform.up, -Vector3.Dot(currVector, Camera.main.transform.right), Space.World);
                            //transform.Rotate(transform.up, -angleOffset, Space.World);
                            spawnedObject.transform.Rotate(transform.up, -Vector3.Dot(mPosDelta * rotationSpeed, -Camera.main.transform.right), Space.World);
                            startVector = currVector;
                        }
                        else if (LR.z < 0)
                        {
                            spawnedObject.transform.Rotate(transform.up, Vector3.Dot(mPosDelta * rotationSpeed, Camera.main.transform.right), Space.World);
                            //transform.Rotate(transform.up, angleOffset, Space.World);
                            //transform.Rotate(transform.up, Vector3.Dot(currVector, -Camera.main.transform.right), Space.World);
                            startVector = currVector;
                        }
                    }
                    mPosDelta = Input.mousePosition - mPrevPos;
                    mPrevPos = Input.mousePosition;

                }
            }
            else if (Input.touchCount == 1)
            {
                rotating = false;
                if (!TryGetTouchPosition(out Vector2 touchPosition))
                    return;
                if (m_RaycastManager.Raycast(touchPosition, s_Hits, TrackableType.PlaneWithinPolygon))
                {
                    // Raycast hits are sorted by distance, so the first one
                    // will be the closest hit.
                    var hitPose = s_Hits[0].pose;

                    // if (spawnedObject == null)
                    // {
                    //     return;

                        // spawnedObject = Instantiate(m_PlacedPrefab, hitPose.position, hitPose.rotation);
                    // }
                    // else
                    // {
                        spawnedObject.transform.position = hitPose.position;
                        //if (Input.GetMouseButton(0))
                        //{
                        //    if (!gotObject)
                        //    {
                        //        RaycastHit hit;
                        //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                        //        if (Physics.Raycast(ray, out hit))
                        //        {
                        //            if (hit.collider != null && hit.collider.gameObject.tag == "Product")
                        //            {
                        //                gotObject = true;
                        //            }
                        //        }
                        //    }
                        //    else
                        //    {
                        //        spawnedObject.transform.position = hitPose.position;
                        //    }
                        //}
                        //else if (Input.GetMouseButtonUp(0))
                        //{
                        //    gotObject = false;
                        //}
                    // }
                }
            }
            else
            {
                rotating = false;
            }
        }

        static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

        ARRaycastManager m_RaycastManager;

        public void DisableObject()
        {
            spawnedObject = null;
        }
    }
}
