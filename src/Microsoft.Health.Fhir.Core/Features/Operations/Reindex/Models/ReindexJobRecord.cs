﻿// -------------------------------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// -------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Microsoft.Health.Core;
using Microsoft.Health.Fhir.Core.Models;
using Newtonsoft.Json;

namespace Microsoft.Health.Fhir.Core.Features.Operations.Reindex.Models
{
    /// <summary>
    /// Class to hold metadata for an individual reindex job.
    /// </summary>
    public class ReindexJobRecord
    {
        public ReindexJobRecord(string searchParametersHash)
        {
            // Default values
            SchemaVersion = 1;
            Id = Guid.NewGuid().ToString();
            Status = OperationStatus.Queued;

            QueuedTime = Clock.UtcNow;
            LastModified = Clock.UtcNow;

            Hash = searchParametersHash;
        }

        [JsonConstructor]
        protected ReindexJobRecord()
        {
        }

        [JsonProperty(JobRecordProperties.Id)]
        public string Id { get; private set; }

        /// <summary>
        ///  The input should be a Parameters FHIR Resource
        ///  TODO: We don't want to add a dependency on the FHIR model here
        ///  but need a method to handle this type
        /// </summary>
        [JsonProperty(JobRecordProperties.Input)]
        public string Input { get; private set; }

        [JsonProperty(JobRecordProperties.QueuedTime)]
        public DateTimeOffset QueuedTime { get; private set; }

        [JsonProperty(JobRecordProperties.SchemaVersion)]
        public int SchemaVersion { get; private set; }

        [JsonProperty(JobRecordProperties.Error)]
        public IList<OperationOutcomeIssue> Error { get; private set; } = new List<OperationOutcomeIssue>();

        [JsonProperty(JobRecordProperties.Status)]
        public OperationStatus Status { get; set; }

        [JsonProperty(JobRecordProperties.StartTime)]
        public DateTimeOffset? StartTime { get; set; }

        [JsonProperty(JobRecordProperties.EndTime)]
        public DateTimeOffset? EndTime { get; set; }

        [JsonProperty(JobRecordProperties.CanceledTime)]
        public DateTimeOffset? CanceledTime { get; set; }

        [JsonProperty(JobRecordProperties.Progress)]
        public IList<ReindexJobQueryStatus> Progress { get; private set; } = new List<ReindexJobQueryStatus>();

        [JsonProperty(JobRecordProperties.Hash)]
        public string Hash { get; private set; }

        [JsonProperty(JobRecordProperties.LastModified)]
        public DateTimeOffset LastModified { get; set; }

        [JsonProperty(JobRecordProperties.FailureCount)]
        public ushort FaiureCount { get; set; }
    }
}
