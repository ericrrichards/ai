﻿namespace WestWorld2.MinerStates {
    using System;

    using WestWorld2;

    public class QuenchThirst : IState<Miner> {
        private static readonly Lazy<QuenchThirst> Lazy = new Lazy<QuenchThirst>(() => new QuenchThirst());
        private QuenchThirst() { }
        public static QuenchThirst Instance { get { return Lazy.Value; } }

        public void Enter(Miner entity) {
            if (entity.Location != Location.Saloon) {
                entity.Location = Location.Saloon;
                entity.LogAction("Boy, ah sure is thusty! Walking to the saloon");
            }
        }

        public void Execute(Miner entity) {
            if (entity.Thirsty) {
                entity.BuyAndDrinkAWhiskey();
                entity.LogAction("That's mighty fine sippin liquer");
                entity.StateMachine.ChangeState(EnterMineAndDigForNugget.Instance);
            } else {
                entity.LogAction("ERROR!\tERROR!\tERROR!");
            }
        }

        public void Exit(Miner entity) {
            entity.LogAction("Leaving the saloon, feelin' good");
        }

        public bool OnMessage(Miner owner, Telegram telegram) { return false; }
    }
}