using ICities;

namespace UnlockZones
{
    public class UnlockZones : IUserMod
    {
        //Cities: Skylines' compiler uses old version of C#, can't use the => operator. 
        public string Name { get { return "Unlock Zones"; } } 
        public string Description { get { return "All types of zones are unlocked from the start. Requires Harmony."; } }
    }

    public class MilestoneExtension : MilestonesExtensionBase
    {
        public override void OnRefreshMilestones()
        {
            //Idea from Custom Milestones mod.
            UnlockController[] controllers = UnityEngine.Object.FindObjectsOfType<UnlockController>();
            for (int i = 0; i < controllers.Length; i++)
            {
                for (int j = 0; j < controllers[i].m_ZoneMilestones.Length; j++)
                {
				    controllers[i].m_ZoneMilestones[j] = null;
                }
            }
            base.OnRefreshMilestones();
        }
    }
}