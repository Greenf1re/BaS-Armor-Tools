#if UNITY_EDITOR
using Chabuk.ManikinMono;
using System.Collections;
using System;
using System.Collections.Generic;
using EasyButtons;
using UnityEditor;
using UnityEngine;
using ThunderRoad;

public class PoseBASAvatar : MonoBehaviour
{
    public string PoseName;
    public AvatarPose Pose;
    public Animator NPCAnimator;
    //Used to implement automatic generation of armor parts; won't be working on it
    // public MeshFilter Helmet;
    // public MeshFilter Chest;
    // public MeshFilter HandRight;
    // public MeshFilter HandLeft;
    // public MeshFilter Pants;
    // public MeshFilter Boots;
    // public PhysicMaterial defaultPhysicsMaterial;

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
    void NewPoseAsset()
    {
        AvatarPose NewPose = ScriptableObject.CreateInstance<AvatarPose>();
#if UNITY_EDITOR
        AssetDatabase.CreateAsset(NewPose, "Assets/BASCreatures/AvatarPoses/" + PoseName + ".asset");
        Pose = NewPose;
#endif

    }
    [Button]
    void LoadTransforms()
    {
        if (!Pose)
        {
            Debug.LogError("Pose asset not assigned");
            return;
        }
        if (!NPCAnimator)
        {
            Debug.LogError("Avatar animator not assigned");
            return;
        }

        foreach (AvatarPose.AvatarBones assetBone in Pose.bones)
        {
            try
            {
                Transform currentBone = NPCAnimator.GetBoneTransform((HumanBodyBones)assetBone.boneIndex);
                currentBone.localPosition = assetBone.Pos;
                currentBone.localRotation = assetBone.Rot;
                currentBone.localScale = assetBone.Scale;
            }
            catch
            {
                Debug.LogError("Error in Bone: " + assetBone.boneIndex);
            }
        }

    }
    [Button]
    void SaveTransforms()
    {
        if (!Pose)
        {
            Debug.LogError("Pose asset not assigned");
            return;
        }
        if (!NPCAnimator)
        {
            Debug.LogError("Avatar animator not assigned");
            return;
        }
        Pose.BoneCount = 0;
        for (int i = (int)HumanBodyBones.LastBone; i > 0; --i)
        {
            ++Pose.BoneCount;
            int curIndex = (int)(HumanBodyBones.LastBone - i);
            Transform currentBone = NPCAnimator.GetBoneTransform((HumanBodyBones)curIndex);
            AvatarPose.AvatarBones boneMatrix = new AvatarPose.AvatarBones();
            if (currentBone != null)
            {
                boneMatrix.boneIndex = curIndex;
                boneMatrix.boneName = NPCAnimator.GetBoneTransform((HumanBodyBones)curIndex).ToString();
                boneMatrix.Pos = currentBone.localPosition;
                boneMatrix.Rot = currentBone.localRotation;
                boneMatrix.Scale = currentBone.localScale;
                Pose.bones[curIndex] = boneMatrix;
                //Pose.bones.Add(boneMatrix);
                Debug.Log(boneMatrix.boneIndex + " Pos " + boneMatrix.Pos + " " + boneMatrix.Rot + "" + boneMatrix.Scale + " Total Bones: " + Pose.BoneCount + " " + NPCAnimator.GetBoneTransform((HumanBodyBones)curIndex));
            }
            else
            {
                Debug.LogWarning("Bone not found " + curIndex);
            }
        }
        Pose.bones[23] = Pose.bones[0];
        UnityEditor.EditorUtility.SetDirty(Pose);
    }
    // [Button]
    // public void GenerateParts(){
    //     Dictionary<MeshFilter, SkinnedMeshRenderer> renderers = new Dictionary<MeshFilter, SkinnedMeshRenderer>();
    //     Transform root = transform.Find("Mesh");
    //     renderers.Add(Helmet, root.Find("Head").Find("Head_LOD0").GetComponent<SkinnedMeshRenderer>());
    //     renderers.Add(Chest, root.Find("Chest").Find("Chest_LOD0").GetComponent<SkinnedMeshRenderer>());
    //     renderers.Add(Pants, root.Find("Legs").Find("Legs_LOD0").GetComponent<SkinnedMeshRenderer>());
    //     renderers.Add(HandRight, root.Find("HandRight").Find("HandRight_LOD0").GetComponent<SkinnedMeshRenderer>());
    //     renderers.Add(HandLeft, root.Find("HandLeft").Find("HandLeft_LOD0").GetComponent<SkinnedMeshRenderer>());
    //     renderers.Add(Boots, root.Find("Feet").Find("Feet_LOD0").GetComponent<SkinnedMeshRenderer>());
    //     foreach (KeyValuePair<MeshFilter, SkinnedMeshRenderer> bone in renderers)
    //     {
    //         SkinnedMeshHelper smh = bone.Key.gameObject.AddComponent<SkinnedMeshHelper>();
    //         GameObject parentObject = new GameObject();
    //         parentObject.name = bone.Key.name + "_parent";
    //         smh.mesh = bone.Key.sharedMesh;
    //         smh.fromSmr = bone.Value;
    //         smh.setupPart = true;
    //         smh.TransferBones();
    //         bone.Key.transform.SetParent(parentObject.transform);
    //         MeshPart meshPart = parentObject.AddComponent<MeshPart>();
    //         meshPart.skinnedMeshRenderer = bone.Key.gameObject.GetComponent<SkinnedMeshRenderer>();
    //         meshPart.defaultPhysicMaterial = defaultPhysicsMaterial;
    //         ManikinGroupPart mgp = parentObject.AddComponent<ManikinGroupPart>();
    //         //List<Renderer> mgp_renderers = new List<Renderer> {bone.Key.GetComponent<Renderer>()};
    //         // ManikinGroupPart.PartLOD partLodList = new ManikinGroupPart.PartLOD(); // = new List<ManikinGroupPart.PartLOD> {mgp_renderers};
    //         // partLodList.renderers.Add(bone.Key.GetComponent<SkinnedMeshRenderer>());
    //         // mgp.partLODs.Add(partLodList);
            
    //     }
    //     return;
    // }
}
    #endif

