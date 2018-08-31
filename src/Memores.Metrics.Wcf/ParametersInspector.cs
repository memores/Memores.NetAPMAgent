﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;
using Memores.Metrics.Wcf.Model;

namespace Memores.Metrics.Wcf
{
    public class ParametersInspector : IParameterInspector
    {
        private readonly IMetricsReporter _reporter;
        private MetricsReport _paramatersInspectorMetricsReport;
        private Stopwatch _stopwatch;

        public ParametersInspector(IMetricsReporter reporter) {
            _reporter = reporter;
        }

        public object BeforeCall(string operationName, object[] inputs) {
            _stopwatch = Stopwatch.StartNew();

            _paramatersInspectorMetricsReport = new MetricsReport() {
                OperationName = operationName,
                MetricsReportType = MetricsReportTypes.Operation,
                Tags = new List<Tag>() {
                    new Tag() {
                        Key = TagsKeyTypes.SourceName.ToString(),
                        Value = nameof(ParametersInspector)
                    }
                }
            };

            return null;
        }

        public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState) {
            _stopwatch.Stop();
            _paramatersInspectorMetricsReport.ProcessingTime = _stopwatch.ElapsedMilliseconds;
            _reporter.Report(_paramatersInspectorMetricsReport);
        }
    }
}
