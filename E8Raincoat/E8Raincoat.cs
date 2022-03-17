using BepInEx;
using R2API;
using R2API.Utils;
using RoR2;
using UnityEngine;
using System.Reflection;
using System.Runtime.Serialization;

namespace E8Raincoat
{

    [BepInDependency(R2API.R2API.PluginGUID)]
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [R2APISubmoduleDependency(nameof(ItemAPI))]
    public class E8Raincoat : BaseUnityPlugin
	{

        public const string PluginGUID = PluginAuthor + "." + PluginName;
        public const string PluginAuthor = "DarkKronicle";
        public const string PluginName = "E8Raincoat";
        public const string PluginVersion = "1.0.0";


        public void Awake()
        {
            Log.Init(Logger);

            On.RoR2.ImmuneToDebuffBehavior.OverrideDebuff_BuffDef_CharacterBody += OverrideDebuff;

            Log.LogInfo(nameof(Awake) + " done.");
        }

        public static bool OverrideDebuff(
            On.RoR2.ImmuneToDebuffBehavior.orig_OverrideDebuff_BuffDef_CharacterBody orig,
            BuffDef buffDef,
            CharacterBody body
        )
        {
            if (RoR2Content.Buffs.PermanentCurse.buffIndex == buffDef.buffIndex)
            {
                return false;
            }
            return buffDef.buffIndex != BuffIndex.None && buffDef.isDebuff && ImmuneToDebuffBehavior.TryApplyOverrideBarrier(body);
        }

    }


}
