using System;
using Flash2;
using Framework;
using UnhollowerBaseLib;
using UnhollowerBaseLib.Runtime;
using UnhollowerRuntimeLib;

namespace BMNoAutoPause.Patches
{
    internal static class MainGameStagePatch
    {
        private delegate void FixedUpdateDelegate(IntPtr _thisPtr);
        private static FixedUpdateDelegate FixedUpdateInstance;
        private static FixedUpdateDelegate FixedUpdateOriginal;

        public static unsafe void CreateDetour()
        {
            FixedUpdateInstance = FixedUpdate;
            FixedUpdateOriginal = ClassInjector.Detour.Detour(UnityVersionHandler.Wrap((Il2CppMethodInfo*)(IntPtr)UnhollowerUtils.GetIl2CppMethodInfoPointerFieldForGeneratedMethod(
                typeof(MainGameStage).GetMethod(nameof(MainGameStage.FixedUpdate)))
                .GetValue(null)).MethodPointer, FixedUpdateInstance);

        }

        static void FixedUpdate(IntPtr _thisPtr)
        {
            MainGameStage __instance = new MainGameStage(_thisPtr);

            //Removing the pause singleton will cause the original pause check to fail
            //It's a massive hack but it's like the only way I can make it fail
            Pause pauseInstance = SingletonBase<Pause>.s_Instance;
            SingletonBase<Pause>.s_Instance = null;
            FixedUpdateOriginal(_thisPtr);
            SingletonBase<Pause>.s_Instance = pauseInstance;

            //Reimplementation of the pause check that doesn't care about losing focus
            if (SingletonBase<GameManager>.Exists && SingletonBase<Pause>.Exists)
            {
                if (!GameManager.IsPause() && Pause.CanChangeState(false) && (Pause.IsDownPauseButtonFixed(__instance.m_PlayerIndex) || AppNetwork.IsShowingProfile()))
                {
                    Pause.SelectorOpitons pauseOptions = __instance.m_pauseOptions;
                    int playerIndex = __instance.m_PlayerIndex;
                    pauseOptions.playerIndex = playerIndex;
                    __instance.m_pauseOptions.itemKind = (SelPauseWindow.ItemKind)((ulong)1L);
                    Pause.Enable(Pause.OpenSelectorKind.Pause, pauseOptions);
                }
            }
        }
    }
}
