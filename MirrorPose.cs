using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyButtons;
using ThunderRoad;
public class MirrorPose : MonoBehaviour
{
    public Animator NPCAnimator;
    public bool CopyFromLeft;
    protected bool CopyTransformPosition = true;
    public Dictionary<Transform, Transform> Bones;
    public Dictionary<Transform, Transform> upperBones;
    //public Dictionary<Transform, Transform> handBones;
    public void Reset()
    {
        bool animatorB = false;
        animatorB = this.TryGetComponent<Animator>(out NPCAnimator);
        if (animatorB == false)
        {
            animatorB = this.transform.Find("Mesh").gameObject.TryGetComponent<Animator>(out NPCAnimator);
            if (animatorB == false)
            {
                Debug.LogError("No animator assigned, please assign animator");
            }
        }
       
    }
    [Button]
    public void MirrorBones()
    {
        Bones = new Dictionary<Transform, Transform>{
                {NPCAnimator.GetBoneTransform(HumanBodyBones.LeftShoulder), NPCAnimator.GetBoneTransform(HumanBodyBones.RightShoulder)},
                {NPCAnimator.GetBoneTransform(HumanBodyBones.LeftUpperArm), NPCAnimator.GetBoneTransform(HumanBodyBones.RightUpperArm)},
                {NPCAnimator.GetBoneTransform(HumanBodyBones.LeftUpperLeg), NPCAnimator.GetBoneTransform(HumanBodyBones.RightUpperLeg)},
                {NPCAnimator.GetBoneTransform(HumanBodyBones.LeftLowerArm), NPCAnimator.GetBoneTransform(HumanBodyBones.RightLowerArm)},
                {NPCAnimator.GetBoneTransform(HumanBodyBones.LeftLowerLeg), NPCAnimator.GetBoneTransform(HumanBodyBones.RightLowerLeg)},
                {NPCAnimator.GetBoneTransform(HumanBodyBones.LeftFoot), NPCAnimator.GetBoneTransform(HumanBodyBones.RightFoot)},
                {NPCAnimator.GetBoneTransform(HumanBodyBones.LeftHand), NPCAnimator.GetBoneTransform(HumanBodyBones.RightHand)},
                {NPCAnimator.GetBoneTransform(HumanBodyBones.LeftIndexDistal), NPCAnimator.GetBoneTransform(HumanBodyBones.RightIndexDistal)},
                {NPCAnimator.GetBoneTransform(HumanBodyBones.LeftIndexIntermediate), NPCAnimator.GetBoneTransform(HumanBodyBones.RightIndexIntermediate)},
                {NPCAnimator.GetBoneTransform(HumanBodyBones.LeftIndexProximal), NPCAnimator.GetBoneTransform(HumanBodyBones.RightIndexProximal)},
                {NPCAnimator.GetBoneTransform(HumanBodyBones.LeftLittleDistal), NPCAnimator.GetBoneTransform(HumanBodyBones.RightLittleDistal)},
                {NPCAnimator.GetBoneTransform(HumanBodyBones.LeftLittleIntermediate), NPCAnimator.GetBoneTransform(HumanBodyBones.RightLittleIntermediate)},
                {NPCAnimator.GetBoneTransform(HumanBodyBones.LeftLittleProximal), NPCAnimator.GetBoneTransform(HumanBodyBones.RightLittleProximal)},
                {NPCAnimator.GetBoneTransform(HumanBodyBones.LeftMiddleDistal), NPCAnimator.GetBoneTransform(HumanBodyBones.RightMiddleDistal)},
                {NPCAnimator.GetBoneTransform(HumanBodyBones.LeftMiddleIntermediate), NPCAnimator.GetBoneTransform(HumanBodyBones.RightMiddleIntermediate)},
                {NPCAnimator.GetBoneTransform(HumanBodyBones.LeftMiddleProximal), NPCAnimator.GetBoneTransform(HumanBodyBones.RightMiddleProximal)},
                {NPCAnimator.GetBoneTransform(HumanBodyBones.LeftRingDistal), NPCAnimator.GetBoneTransform(HumanBodyBones.RightRingDistal)},
                {NPCAnimator.GetBoneTransform(HumanBodyBones.LeftRingIntermediate), NPCAnimator.GetBoneTransform(HumanBodyBones.RightRingIntermediate)},
                {NPCAnimator.GetBoneTransform(HumanBodyBones.LeftRingProximal), NPCAnimator.GetBoneTransform(HumanBodyBones.RightRingProximal)},
                {NPCAnimator.GetBoneTransform(HumanBodyBones.LeftThumbDistal), NPCAnimator.GetBoneTransform(HumanBodyBones.RightThumbDistal)},
                {NPCAnimator.GetBoneTransform(HumanBodyBones.LeftThumbIntermediate), NPCAnimator.GetBoneTransform(HumanBodyBones.RightThumbIntermediate)},
                {NPCAnimator.GetBoneTransform(HumanBodyBones.LeftThumbProximal), NPCAnimator.GetBoneTransform(HumanBodyBones.RightThumbProximal)},
                {NPCAnimator.GetBoneTransform(HumanBodyBones.LeftToes), NPCAnimator.GetBoneTransform(HumanBodyBones.RightToes)}

            };
            upperBones = new Dictionary<Transform, Transform>{
                {NPCAnimator.GetBoneTransform(HumanBodyBones.LeftShoulder), NPCAnimator.GetBoneTransform(HumanBodyBones.RightShoulder)},
                {NPCAnimator.GetBoneTransform(HumanBodyBones.LeftUpperArm), NPCAnimator.GetBoneTransform(HumanBodyBones.RightUpperArm)},
                {NPCAnimator.GetBoneTransform(HumanBodyBones.LeftLowerArm), NPCAnimator.GetBoneTransform(HumanBodyBones.RightLowerArm)},
                {NPCAnimator.GetBoneTransform(HumanBodyBones.LeftFoot), NPCAnimator.GetBoneTransform(HumanBodyBones.RightFoot)},
                {NPCAnimator.GetBoneTransform(HumanBodyBones.LeftHand), NPCAnimator.GetBoneTransform(HumanBodyBones.RightHand)},
                {NPCAnimator.GetBoneTransform(HumanBodyBones.LeftThumbDistal), NPCAnimator.GetBoneTransform(HumanBodyBones.RightThumbDistal)},
                {NPCAnimator.GetBoneTransform(HumanBodyBones.LeftThumbIntermediate), NPCAnimator.GetBoneTransform(HumanBodyBones.RightThumbIntermediate)},
                {NPCAnimator.GetBoneTransform(HumanBodyBones.LeftThumbProximal), NPCAnimator.GetBoneTransform(HumanBodyBones.RightThumbProximal)},
                {NPCAnimator.GetBoneTransform(HumanBodyBones.LeftLowerLeg), NPCAnimator.GetBoneTransform(HumanBodyBones.RightLowerLeg)}
            };
            // handBones = new Dictionary<Transform, Transform>{
            //     {NPCAnimator.GetBoneTransform(HumanBodyBones.LeftIndexDistal), NPCAnimator.GetBoneTransform(HumanBodyBones.RightIndexDistal)},
            //     {NPCAnimator.GetBoneTransform(HumanBodyBones.LeftIndexIntermediate), NPCAnimator.GetBoneTransform(HumanBodyBones.RightIndexIntermediate)},
            //     {NPCAnimator.GetBoneTransform(HumanBodyBones.LeftIndexProximal), NPCAnimator.GetBoneTransform(HumanBodyBones.RightIndexProximal)},
            //     {NPCAnimator.GetBoneTransform(HumanBodyBones.LeftLittleDistal), NPCAnimator.GetBoneTransform(HumanBodyBones.RightLittleDistal)},
            //     {NPCAnimator.GetBoneTransform(HumanBodyBones.LeftLittleIntermediate), NPCAnimator.GetBoneTransform(HumanBodyBones.RightLittleIntermediate)},
            //     {NPCAnimator.GetBoneTransform(HumanBodyBones.LeftLittleProximal), NPCAnimator.GetBoneTransform(HumanBodyBones.RightLittleProximal)},
            //     {NPCAnimator.GetBoneTransform(HumanBodyBones.LeftMiddleDistal), NPCAnimator.GetBoneTransform(HumanBodyBones.RightMiddleDistal)},
            //     {NPCAnimator.GetBoneTransform(HumanBodyBones.LeftMiddleIntermediate), NPCAnimator.GetBoneTransform(HumanBodyBones.RightMiddleIntermediate)},
            //     {NPCAnimator.GetBoneTransform(HumanBodyBones.LeftMiddleProximal), NPCAnimator.GetBoneTransform(HumanBodyBones.RightMiddleProximal)},
            //     {NPCAnimator.GetBoneTransform(HumanBodyBones.LeftRingDistal), NPCAnimator.GetBoneTransform(HumanBodyBones.RightRingDistal)},
            //     {NPCAnimator.GetBoneTransform(HumanBodyBones.LeftRingIntermediate), NPCAnimator.GetBoneTransform(HumanBodyBones.RightRingIntermediate)},
            //     {NPCAnimator.GetBoneTransform(HumanBodyBones.LeftRingProximal), NPCAnimator.GetBoneTransform(HumanBodyBones.RightRingProximal)},
            //     {NPCAnimator.GetBoneTransform(HumanBodyBones.LeftThumbDistal), NPCAnimator.GetBoneTransform(HumanBodyBones.RightThumbDistal)},
            //     {NPCAnimator.GetBoneTransform(HumanBodyBones.LeftThumbIntermediate), NPCAnimator.GetBoneTransform(HumanBodyBones.RightThumbIntermediate)},
            //     {NPCAnimator.GetBoneTransform(HumanBodyBones.LeftThumbProximal), NPCAnimator.GetBoneTransform(HumanBodyBones.RightThumbProximal)}
                
            // };

        /*Bones.Add(NPCAnimator.GetBoneTransform(HumanBodyBones.LeftShoulder), NPCAnimator.GetBoneTransform(HumanBodyBones.RightShoulder));//1
        Bones.Add(NPCAnimator.GetBoneTransform(HumanBodyBones.LeftUpperArm), NPCAnimator.GetBoneTransform(HumanBodyBones.RightUpperArm));//2
        Bones.Add(NPCAnimator.GetBoneTransform(HumanBodyBones.LeftUpperLeg), NPCAnimator.GetBoneTransform(HumanBodyBones.RightUpperLeg));//3
        Bones.Add(NPCAnimator.GetBoneTransform(HumanBodyBones.LeftLowerArm), NPCAnimator.GetBoneTransform(HumanBodyBones.RightLowerArm));//4
        Bones.Add(NPCAnimator.GetBoneTransform(HumanBodyBones.LeftLowerLeg), NPCAnimator.GetBoneTransform(HumanBodyBones.RightLowerLeg));//5
        Bones.Add(NPCAnimator.GetBoneTransform(HumanBodyBones.LeftFoot), NPCAnimator.GetBoneTransform(HumanBodyBones.RightFoot));//6
        Bones.Add(NPCAnimator.GetBoneTransform(HumanBodyBones.LeftHand), NPCAnimator.GetBoneTransform(HumanBodyBones.RightHand));//7
        Bones.Add(NPCAnimator.GetBoneTransform(HumanBodyBones.LeftIndexDistal), NPCAnimator.GetBoneTransform(HumanBodyBones.RightIndexDistal));//8
        Bones.Add(NPCAnimator.GetBoneTransform(HumanBodyBones.LeftIndexIntermediate), NPCAnimator.GetBoneTransform(HumanBodyBones.RightIndexIntermediate));//9
        Bones.Add(NPCAnimator.GetBoneTransform(HumanBodyBones.LeftIndexProximal), NPCAnimator.GetBoneTransform(HumanBodyBones.RightIndexProximal));//10
        Bones.Add(NPCAnimator.GetBoneTransform(HumanBodyBones.LeftLittleDistal), NPCAnimator.GetBoneTransform(HumanBodyBones.RightLittleDistal));//11
        Bones.Add(NPCAnimator.GetBoneTransform(HumanBodyBones.LeftLittleIntermediate), NPCAnimator.GetBoneTransform(HumanBodyBones.RightLittleIntermediate));//12
        Bones.Add(NPCAnimator.GetBoneTransform(HumanBodyBones.LeftLittleProximal), NPCAnimator.GetBoneTransform(HumanBodyBones.RightLittleProximal));//13
        Bones.Add(NPCAnimator.GetBoneTransform(HumanBodyBones.LeftMiddleDistal), NPCAnimator.GetBoneTransform(HumanBodyBones.RightMiddleDistal));//14
        Bones.Add(NPCAnimator.GetBoneTransform(HumanBodyBones.LeftMiddleIntermediate), NPCAnimator.GetBoneTransform(HumanBodyBones.RightMiddleIntermediate));//15
        Bones.Add(NPCAnimator.GetBoneTransform(HumanBodyBones.LeftMiddleProximal), NPCAnimator.GetBoneTransform(HumanBodyBones.RightMiddleProximal));//16
        Bones.Add(NPCAnimator.GetBoneTransform(HumanBodyBones.LeftRingDistal), NPCAnimator.GetBoneTransform(HumanBodyBones.RightRingDistal));//17
        Bones.Add(NPCAnimator.GetBoneTransform(HumanBodyBones.LeftRingIntermediate), NPCAnimator.GetBoneTransform(HumanBodyBones.RightRingIntermediate));//18
        Bones.Add(NPCAnimator.GetBoneTransform(HumanBodyBones.LeftRingProximal), NPCAnimator.GetBoneTransform(HumanBodyBones.RightRingProximal));//19
        Bones.Add(NPCAnimator.GetBoneTransform(HumanBodyBones.LeftThumbDistal), NPCAnimator.GetBoneTransform(HumanBodyBones.RightThumbDistal));//20
        Bones.Add(NPCAnimator.GetBoneTransform(HumanBodyBones.LeftThumbIntermediate), NPCAnimator.GetBoneTransform(HumanBodyBones.RightThumbIntermediate));//21
        Bones.Add(NPCAnimator.GetBoneTransform(HumanBodyBones.LeftThumbProximal), NPCAnimator.GetBoneTransform(HumanBodyBones.RightThumbProximal));
        Bones.Add(NPCAnimator.GetBoneTransform(HumanBodyBones.LeftToes), NPCAnimator.GetBoneTransform(HumanBodyBones.RightToes));*/

        foreach (KeyValuePair<Transform, Transform> bone in Bones)
        {
            //Debug.Log(bone.Key.localRotation + " key|Value " + bone.Value.localRotation);

            if (CopyFromLeft)
            {
                //bone.Value.transform.localRotation = new Quaternion(bone.Key.transform.localRotation.x, bone.Key.transform.localRotation.y, -bone.Key.transform.localRotation.z, bone.Key.transform.localRotation.x);
                bone.Value.transform.localEulerAngles = new Vector3(bone.Key.localEulerAngles.x, bone.Key.localEulerAngles.y, -bone.Key.localEulerAngles.z);
                if (CopyTransformPosition){
                    //bone.Value.transform.position = new Vector3(-bone.Key.transform.position.x, bone.Key.transform.position.y, bone.Key.transform.position.z);
                    bone.Value.transform.localPosition = new Vector3(bone.Key.transform.localPosition.x, -bone.Key.transform.localPosition.y, bone.Key.transform.localPosition.z);
                    bone.Value.transform.localScale = new Vector3(bone.Key.transform.localScale.x, bone.Key.transform.localScale.y, bone.Key.transform.localScale.z);
                }
            }
            else
            {
                bone.Key.transform.localEulerAngles = new Vector3(bone.Value.localEulerAngles.x, bone.Value.localEulerAngles.y, -bone.Value.localEulerAngles.z);
                if (CopyTransformPosition){
                    bone.Key.transform.localPosition = new Vector3(bone.Value.transform.localPosition.x, -bone.Value.transform.localPosition.y, bone.Value.transform.localPosition.z);
                    bone.Key.transform.localScale = new Vector3(bone.Value.transform.localScale.x, bone.Value.transform.localScale.y, bone.Value.transform.localScale.z);
                }
            }
        }
        foreach (KeyValuePair<Transform, Transform> bone in upperBones)
        {

            if (CopyFromLeft)
            {
                bone.Value.transform.localEulerAngles = new Vector3(-bone.Key.localEulerAngles.x, bone.Key.localEulerAngles.y, -bone.Key.localEulerAngles.z);
                if (CopyTransformPosition){
                    bone.Value.transform.localPosition = new Vector3(bone.Key.transform.localPosition.x, -bone.Key.transform.localPosition.y, bone.Key.transform.localPosition.z);
                    bone.Value.transform.localScale = new Vector3(bone.Key.transform.localScale.x, bone.Key.transform.localScale.y, bone.Key.transform.localScale.z);
                }
            }
            else
            {
                bone.Key.transform.localEulerAngles = new Vector3(-bone.Value.localEulerAngles.x, bone.Value.localEulerAngles.y, -bone.Value.localEulerAngles.z);
                if (CopyTransformPosition){
                    bone.Key.transform.localPosition = new Vector3(bone.Value.transform.localPosition.x, -bone.Value.transform.localPosition.y, bone.Value.transform.localPosition.z);
                    bone.Key.transform.localScale = new Vector3(bone.Value.transform.localScale.x, bone.Value.transform.localScale.y, bone.Value.transform.localScale.z);
                }
            }
        }
    }
}
