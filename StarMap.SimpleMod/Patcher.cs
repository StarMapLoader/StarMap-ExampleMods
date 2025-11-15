using HarmonyLib;

namespace StarMap.SimpleExampleMod
{
    [HarmonyPatch]
    internal static class Patcher
    {
        private static Harmony? _harmony = new Harmony("StarMap.SimpleMod");

        public static void Patch()
        {
            Console.WriteLine("Patching SimpleMod...");
            _harmony?.PatchAll();
        }

        public static void Unload()
        {
            _harmony?.UnpatchAll(_harmony.Id);
            _harmony = null;
        }
    }
}
