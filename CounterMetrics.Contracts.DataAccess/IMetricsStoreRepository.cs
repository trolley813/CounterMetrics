﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace CounterMetrics.Contracts.DataAccess
{
    [ServiceContract]
    public interface IMetricsStoreRepository
    {
        [OperationContract(IsOneWay = true)]
        void Persist(MetricEntity metricEntity);
    }
}
