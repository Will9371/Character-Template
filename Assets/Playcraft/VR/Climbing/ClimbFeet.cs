﻿using UnityEngine;

// Allows player to stand on ground without body interfering with climbing
namespace Playcraft.VR
{
    public class ClimbFeet : MonoBehaviour
    {
        #pragma warning disable 0649
        [SerializeField] Transform head;
        [SerializeField] Transform rig;
        [SerializeField] Climb leftHand, rightHand;
        [SerializeField] Collider footCollider;
        #pragma warning restore 0649

        bool isGrabbing => leftHand.isGrabbing || rightHand.isGrabbing;
        Vector3 footPosition => footCollider.transform.position; 
        float height => head.localPosition.y;
        Ray headToFeet => new Ray(head.position, Vector3.down);
        
        RaycastHit hit;


        void Update()
        {
            footCollider.enabled = !isGrabbing;
            transform.localPosition = new Vector3(head.localPosition.x, 0f, head.localPosition.z);
            
            if (isGrabbing || height < .125f)
                return;

            //Debug.DrawRay(head.position, Vector3.down * height, Color.yellow);
            if (Physics.Raycast(headToFeet, out hit, height))// && hit.transform.GetComponent<StandSurface>())
            {
                var surfaceTag = hit.transform.GetComponent<ComponentTags>();
                if (surfaceTag && surfaceTag.IsValid(TagID.Stand))
                {
                    var liftDistance = Mathf.Max(0f, hit.point.y - footPosition.y);
                    rig.Translate(Vector3.up * liftDistance); 
                }
            }    
        }
    }
}