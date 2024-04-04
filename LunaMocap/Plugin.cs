using BepInEx;
using CsvHelper;
using LunaMocap.Patches;
using System;
using System.Globalization;
using System.IO;
using UnityEngine;
using Utilla;

namespace LunaMocap
{
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        public static bool isCapturing = false;
        void Start()
        {
            HarmonyPatches.ApplyHarmonyPatches();
        }

        void OnGUI()
        {
            if (GUI.Button(new Rect(20, 40, 80, 20), "Toggle Capture"))
            {
                isCapturing = !isCapturing;
                if (isCapturing)
                {
                    RigPatch.capList.Clear();
                    RigPatch.frameCap = 0;
                } else
                {
                    if (!Directory.Exists($"{BepInEx.Paths.GameRootPath}\\Motion Captures\\"))
                        Directory.CreateDirectory($"{BepInEx.Paths.GameRootPath}\\Motion Captures\\");

                    using (var writer = new StreamWriter($"{BepInEx.Paths.GameRootPath}\\Motion Captures\\Capture-{DateTime.Now.Day}.{DateTime.Now.Month}.{DateTime.Now.Year}.{DateTime.Now.Minute}.{DateTime.Now.Second}.csv"))
                    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        csv.WriteRecords(RigPatch.capList);
                    }
                }
            }
        }
    }
}
