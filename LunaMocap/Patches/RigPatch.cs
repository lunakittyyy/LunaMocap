using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace LunaMocap.Patches
{
    [HarmonyPatch(typeof(VRRig))]
    [HarmonyPatch("LateUpdate", MethodType.Normal)]
    internal class RigPatch
    {
        public static int frameCap;
        public static List<Capture> capList = new List<Capture>();
        private static void Postfix(VRRig __instance)
        {
            if (!__instance.isOfflineVRRig || !Plugin.isCapturing) return;
            frameCap++;

            if (frameCap % 3 == 0)
            {
                Debug.Log($"Frame {frameCap} is modulo 3, taking a capture");
                capList.Add(new Capture
                {
                    Frame = frameCap,


                    LHandPosX = __instance.leftHandTransform.position.x,
                    LHandPosY = __instance.leftHandTransform.position.y,
                    LHandPosZ = __instance.leftHandTransform.position.z,

                    LHandRotX = __instance.leftHandTransform.rotation.x,
                    LHandRotY = __instance.leftHandTransform.rotation.y,
                    LHandRotZ = __instance.leftHandTransform.rotation.z,
                    LHandRotW = __instance.leftHandTransform.rotation.w,


                    RHandPosX = __instance.rightHandTransform.position.x,
                    RHandPosY = __instance.rightHandTransform.position.y,
                    RHandPosZ = __instance.rightHandTransform.position.z,

                    RHandRotX = __instance.rightHandTransform.rotation.x,
                    RHandRotY = __instance.rightHandTransform.rotation.y,
                    RHandRotZ = __instance.rightHandTransform.rotation.z,
                    RHandRotW = __instance.rightHandTransform.rotation.w,


                    HeadPosX = __instance.headMesh.transform.position.x,
                    HeadPosY = __instance.headMesh.transform.position.y,
                    HeadPosZ = __instance.headMesh.transform.position.z,

                    HeadRotX = __instance.headMesh.transform.rotation.x,
                    HeadRotY = __instance.headMesh.transform.rotation.y,
                    HeadRotZ = __instance.headMesh.transform.rotation.z,
                    HeadRotW = __instance.headMesh.transform.rotation.w
                });
            }
        }
    }
}
