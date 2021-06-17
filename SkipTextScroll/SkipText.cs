using StardewModdingAPI;
using Harmony;

namespace SkipText {
    public class ModEntry : Mod {
        public override void Entry(IModHelper helper) {
            //Patch.Init(this);
            var harmony = HarmonyInstance.Create(this.ModManifest.UniqueID);
            System.Reflection.MethodInfo original = AccessTools.Method(typeof(StardewValley.Menus.DialogueBox), "update"); // Handles the dialogue and text boxes
            HarmonyMethod patch = new HarmonyMethod(typeof(Patch), "Prefix");
            harmony.Patch(original, prefix: patch);
        }
    }

    class Patch {
  //      private static ModEntry Mod;
  //      public static void Init(ModEntry mod) {
  //          Mod = mod;
		//}

        public static void Prefix(StardewValley.Menus.DialogueBox __instance) {
            __instance.characterIndexInDialogue = __instance.getCurrentString().Length;
        }
    }
}