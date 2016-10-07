﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace CounterMetrics.Contracts.DataAccess
{
    [Table("Counters")]
    [DataContract]
    public class CounterEntity
    {
        [Key]
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public int UserID { get; set; }

        [DataMember]
        public CounterType Type { get; set; }
    }

    public enum CounterType
    {
        Water,
        Electricity
    }
}