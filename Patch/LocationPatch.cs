using BepInEx.Bootstrap;
using HarmonyLib;
using UnityEngine;
using UnityEngine.SceneManagement;
using static JustBuildOnSpawn.Plugin;

namespace JustBuildOnSpawn;

[HarmonyPatch]
internal class LocationPatch
{
    [HarmonyPatch(typeof(Location), nameof(Location.IsInsideNoBuildLocation)), HarmonyPrefix]
    public static bool ChatAddSMode(Chat __instance, ref bool __result)
    {
        __result = false;
        return false;
    }
}