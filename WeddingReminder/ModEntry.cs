using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Locations;

namespace WeddingReminder
{
    /// <summary>The mod entry point.</summary>
    internal sealed class ModEntry : Mod
    {
        /*********
        ** Public methods
        *********/
        public override void Entry(IModHelper helper)
        {
            // Run this behaviour every day, before saving
            helper.Events.GameLoop.DayStarted += this.GameLoop_DayStarted;
            // run whenever the player warps into the farmhouse
            helper.Events.Player.Warped += this.GameLoop_PlayerWarpFarmhouse;
        }

        private void GameLoop_DayStarted(object sender, DayStartedEventArgs e)
        {
            if (Game1.player.GetSpouseFriendship() is Friendship spouse && spouse.CountdownToWedding == 1)
            {
                Game1.addHUDMessage(new HUDMessage(Game1.content.LoadString("handwrittenhello.weddingReminder/HUDMessage:Default")));
            }
        }

        private void GameLoop_PlayerWarpFarmhouse(object sender, WarpedEventArgs e)
        {
            if (Game1.player.GetSpouseFriendship() is Friendship spouse && spouse.CountdownToWedding == 1 && e.NewLocation is FarmHouse house && house.owner == Game1.player)
            {
                Game1.addHUDMessage(new HUDMessage(Game1.content.LoadString("handwrittenhello.weddingReminder/HUDMessage:Deafult")));
            }
        }
    } 
}