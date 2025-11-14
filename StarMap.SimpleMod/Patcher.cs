using Brutal.GlfwApi;
using Brutal.ImGuiApi;
using Brutal.Numerics;
using HarmonyLib;
using KSA;
using System.Reflection;

namespace StarMap.SimpleExampleMod
{
    [HarmonyPatch]
    internal static class Patcher
    {
        private static Harmony? _harmony = new Harmony("StarMap.SimpleMod");

        public static void Patch()
        {
            _harmony?.PatchAll();
        }

        public static void Unload()
        {
            _harmony?.UnpatchAll(_harmony.Id);
            _harmony = null;
        }
    }
}
