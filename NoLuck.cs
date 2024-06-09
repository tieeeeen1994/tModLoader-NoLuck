using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NoLuck
{
    public class NoLuck : Mod
	{
        public NoLuck()
        {
        }

        public override void Load()
        {
            On_Player.UpdateLuck += OnUpdateLuck;
        }

        public override void Unload()
        {
            On_Player.UpdateLuck -= OnUpdateLuck;
        }

        private void OnUpdateLuck(On_Player.orig_UpdateLuck orig, Player self)
        {
            self.luck = 0f;
            if (self.luckNeedsSync && self.whoAmI == Main.myPlayer)
            {
                self.luckNeedsSync = false;
                NetMessage.SendData(MessageID.UpdatePlayerLuckFactors, -1, -1, null, self.whoAmI, 0f, 0f, 0f, 0, 0, 0);
            }
        }
    }
}
