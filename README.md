# BaS-Armor-Tools
A few scripts that help with making armors for the VR game Blade and Sorcery. They're intended to be used in combination with the Bone Renderer from the "Animation Rigging" tab of the Unity inspector.
## Scripts
1. Pose BAS Avatar:
  Add it to the human male or human female prefab. It's used to create new poses, save poses, or load previously saved poses. Note: after saving a pose, save the scene as well. 
2. Mirror Pose: Since most armors are symmetric, you may wish to only pose one half of the avatar. This script mirrors a pose from one side to another (copies from Avatar right side to left side on default)
3. BAS Avatar: A "container" script that holds a pose's bones, their positions, rotations and scaling.

## Installation/Usage
1. Either install the unitypackage or drag and drop the scripts from the source. You'll then be able to add the Pose and Mirror scripts to the BaS avatar prefab.
2. Then, click on Animation Rigging->Bone Renderer Setup. It'll make the bones visible, but you may want to hide or delete the "Ragdoll" child in the prefab.![image](https://user-images.githubusercontent.com/32655376/199850496-26c0e495-3562-4fe6-a7ec-5ced96bff885.png)
3. Type a name into the "Pose Name" field of the Pose BAS Avatar Script and click on New Pose Asset
4. Pose the avatar so that it fits into the armor/model you're using, if the armor is symmetric you should use the Pose Mirror script so you only do half the work.
5. Save the pose and the scene. Then just proceed with the Manikin armor-making process as usual.
