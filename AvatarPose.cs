using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using EasyButtons;
using System;

[CreateAssetMenu(menuName = "ThunderRoad/Creatures/Avatar Pose")]
public class AvatarPose : ScriptableObject
{
    protected int Version;
    public int BoneCount;
    public AvatarBones[] bones = new AvatarBones[55];
    [Serializable]
    public class AvatarBones
    {
        public int boneIndex;
        public string boneName;

        public UnityEngine.Vector3 Pos;
        public UnityEngine.Quaternion Rot;
        public UnityEngine.Vector3 Scale;
    }
    protected void SaveAssetPose(int nVersion, int nBoneCount, AvatarBones[] BonesArray)
    {
        #if UNITY_EDITOR
            Version = nVersion;
            BoneCount = nBoneCount;
            bones = BonesArray;
            UnityEditor.EditorUtility.SetDirty(this);
#endif
    }
}