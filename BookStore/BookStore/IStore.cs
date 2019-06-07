﻿namespace BookStore
{
    public interface IStore
    {
        void Import(string catalogAsJson);
        int Quantity(string name);
        double Buy(params string[] basketByNames);
    }
}
