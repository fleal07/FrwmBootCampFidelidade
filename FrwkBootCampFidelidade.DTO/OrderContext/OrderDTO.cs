﻿using System;
using System.Collections.Generic;

namespace FrwkBootCampFidelidade.DTO.OrderContext
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public List<OrderItemDTO> OrderItems { get; set; }
        public double TotalValue { get; set; }
        public int StoreId { get; set; }
        public int UserId { get; set; }
        public string CPF { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
