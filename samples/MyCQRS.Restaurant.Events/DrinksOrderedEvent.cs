﻿using System;
using MyCQRS.Events;

namespace MyCQRS.Restaurant.Events
{
    [Serializable]
    public class DrinksOrderedEvent : DomainEvent
    {
        public string Description { get; }
        public int MenuNumber { get; }
        public decimal Price { get; }
        public string Status { get; }

        public DrinksOrderedEvent(Guid id, string description, int menuNumber, decimal price, string status)
        {
            Description = description;
            MenuNumber = menuNumber;
            Price = price;
            Status = status;
            AggregateId = id;
        }
    }
}