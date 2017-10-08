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

namespace EnjoyCQRS.Events
{
    public class Event<TEvent> : IEventWrapper
        where TEvent : IDomainEvent
    {
        IReadOnlyDictionary<string, object> IEventWrapper.Attributes => Attributes;
        IDomainEvent IEventWrapper.InnerEvent => InnerEvent;

        public IReadOnlyDictionary<string, object> Attributes { get; }
        public TEvent InnerEvent { get; }
        
        public Event(TEvent innerEvent, IReadOnlyDictionary<string, object> attributes)
        {
            if (innerEvent == null) throw new ArgumentNullException(nameof(innerEvent));

            InnerEvent = innerEvent;
            Attributes = attributes;
        }
    }
}
