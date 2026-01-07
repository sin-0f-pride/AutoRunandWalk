using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.InputSystem;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.View.Screens;
using TaleWorlds.ScreenSystem;

namespace AutoRunandWalk
{
    public class SubModule : MBSubModuleBase
    {
        protected override void OnApplicationTick(float dt)
        {
            if (Mission.Current != null)
            {
                try
                {
                    if (ScreenManager.TopScreen != null && (Mission.Current.IsFieldBattle || Mission.Current.IsSiegeBattle || Mission.Current.IsNavalBattle || Mission.Current.SceneName.Contains("arena") || (MapEvent.PlayerMapEvent != null && MapEvent.PlayerMapEvent.IsHideoutBattle)))
                    {
                        MissionScreen missionScreen = ScreenManager.TopScreen as MissionScreen;
                        if (missionScreen != null && missionScreen.InputManager != null && missionScreen.InputManager.IsKeyPressed(InputKey.Equals))
                        {
                            Input.PressKey(new Key(InputKey.W).InputKey);
                            Mission.Current.SetLastMovementKeyPressed(Agent.MovementControlFlag.Forward);
                        }
                    }
                }
                catch
                {

                }
            }
        }
    }
}