﻿namespace Assets.HomeWork.Develop.CommonServices.DataManagment.DataProviders
{
    public interface IDataReader<TData> where TData : ISaveData
    {
        void ReadFrom(TData data);
    }
}