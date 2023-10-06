using HarmonyLib;
using ResoniteModLoader;
using FrooxEngine;

namespace ResoniteNonPersistentInspectors {
	public class ResoniteNonPersistentInspectors : ResoniteMod {
		public override string Name => "ResoniteNonPersistentInspectors";
		public override string Author => "Delta";
		public override string Version => "2.0.0";
		public override string Link => "https://github.com/XDelta/NeosNonPersistentInspectors/";

		public override void OnEngineInit() {
			Harmony harmony = new Harmony("net.deltawolf.ResoniteNonPersistentInspectors");
			harmony.PatchAll();
			Msg("Inspectors NonPersistent'd!");
		}

		[HarmonyPatch(typeof(SceneInspector), "OnAttach")]
		static class SceneInspector_OnAttach_Patch {
			static void Postfix(SceneInspector __instance) {
				__instance.Slot.PersistentSelf = false;
			}
		}
	}
}