﻿using System;
using System.Collections.Generic;

namespace BudgetManager.Models.Filters
{
    public class TransactionsFilter : BaseFilter
    {
        public string Keyword { get; set; }
        public int AccountId { get; set; }
        
        public DateTime? DateFrom { get; set; }
        
        public DateTime? DateTo { get; set; }
        
        public decimal? AmountFrom { get; set; }
        
        public decimal? AmountTo { get; set; }
        
        public List<int> CategoriesIds { get; set; }
        
        public List<int> TagsIds { get; set; }
    }
}