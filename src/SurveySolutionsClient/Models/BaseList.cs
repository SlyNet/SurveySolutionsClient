﻿namespace SurveySolutionsClient.Models
{
    public abstract class BaseList
    {
        public string Order { get; protected set; }

        public int Limit { get; protected set; }

        public int TotalCount { get; protected set; }

        public int Offset { get; protected set; }
    }
}