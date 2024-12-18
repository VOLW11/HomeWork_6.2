using Assets.HomeWork.Develop.CommonServices.DataManagment.DataProviders;
using Assets.HomeWork.Develop.ForHome;
using Assets.HomeWork.Develop.Utils.Reactive;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.HomeWork.ForHome
{
    public class WinLossCounterService : IDataReader<PlayerData>, IDataWriter<PlayerData>
    {
        private GameLogic _game;

        public WinLossCounterService(PlayerDataProvider playerDataProvider)
        {
            playerDataProvider.RegisterWriter(this);
            playerDataProvider.RegisterReader(this);
        }

        public void Initialize(GameLogic game)
        {
            _game = game;
            _game.Win += AddPointWin;
            _game.Loss += AddPointLoss;
        }

        public int NumberOfWin { get; private set; }
        public int NumberOfLoss { get; private set; }

        private void AddPointLoss()
        {
            NumberOfLoss++;
        }

        private void AddPointWin()
        {
            NumberOfWin++;
        }

        public void ReadFrom(PlayerData data)
        {
            NumberOfWin = data.WinCount;
            NumberOfLoss = data.LossCount;
        }

        public void WriteTo(PlayerData data)
        {
            data.WinCount = NumberOfWin;
            data.LossCount = NumberOfLoss;
        }

    }
}