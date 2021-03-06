﻿// The MIT License (MIT)
// 
// Copyright (c) 2016 Nelson Corrêa V. Júnior
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnjoyCQRS.Events;
using EnjoyCQRS.EventSource.Snapshots;

namespace EnjoyCQRS.Stores
{
    /// <summary>
    /// Stores the snapshots.
    /// </summary>
    public interface ISnapshotStore : IDisposable
    {
        /// <summary>
        /// Save the aggregate's snapshot.
        /// </summary>
        /// <param name="uncommittedSnapshot"></param>
        /// <returns></returns>
        Task SaveSnapshotAsync(IUncommittedSnapshot uncommittedSnapshot);

        /// <summary>
        /// Retrieves the latest aggregate's snapshot.
        /// </summary>
        /// <param name="aggregateId"></param>
        /// <returns></returns>
        Task<ICommittedSnapshot> GetLatestSnapshotByIdAsync(Guid aggregateId);

        /// <summary>
        /// Retrieves the forward events from <param name="version"></param>.
        /// </summary>
        /// <param name="aggregateId"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        Task<IEnumerable<ICommittedEvent>> GetEventsForwardAsync(Guid aggregateId, int version);
    }
}