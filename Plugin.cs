﻿using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace JustBuildOnSpawn;

[BepInPlugin(ModGUID, ModName, ModVersion)]
internal class Plugin : BaseUnityPlugin
{
    #region values

    internal const string ModName = "JustBuildOnSpawn", ModVersion = "1.0.0", ModGUID = "com.Frogger." + ModName;
    internal static Harmony harmony = new(ModGUID);

    internal static Plugin _self;

    #endregion
    
    #region tools

    public static void Debug(string msg, bool localize = false)
    {
        if (Localization.instance != null && localize)
        {
            _self.Logger.LogInfo(Localization.instance.Localize(msg));
        }
        else
        {
            _self.Logger.LogInfo(msg);
        }
    }

    public void DebugError(string msg, bool showWriteToDev)
    {
        if (showWriteToDev)
        {
            msg += "Write to the developer and moderator if this happens often.";
        }

        Logger.LogError(msg);
    }

    public void DebugWarning(string msg, bool showWriteToDev)
    {
        if (showWriteToDev)
        {
            msg += "Write to the developer and moderator if this happens often.";
        }

        Logger.LogWarning(msg);
    }

    #endregion

    private void Awake()
    {
        _self = this;
        
        harmony.PatchAll();
    }
}