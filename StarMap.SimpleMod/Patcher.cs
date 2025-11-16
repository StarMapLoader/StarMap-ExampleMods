using HarmonyLib;
using KSA;

namespace StarMap.SimpleExampleMod
{
    [HarmonyPatch]
    internal static class Patcher
    {
        private static Harmony? _harmony = new Harmony("StarMap.SimpleMod");

        public static void Patch()
        {
            Console.WriteLine("Patching SimpleMod...");
            _harmony?.PatchAll(typeof(Patcher).Assembly);
        }

        public static void Unload()
        {
            _harmony?.UnpatchAll(_harmony.Id);
            _harmony = null;
        }

        [HarmonyPatch(typeof(ModLibrary), nameof(ModLibrary.LoadAll))]
        [HarmonyPostfix]
        public static void AfterLoad()
        {
            Console.WriteLine("ModLibrary.LoadAll patched by SimpleMod.");
        }
    }
}
