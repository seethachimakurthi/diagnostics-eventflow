﻿// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

using System;
using System.Collections.Generic;
using Validation;

namespace Microsoft.Extensions.Diagnostics
{
    public class EventSink: IDisposable
    {
        public EventSink(IOutput output, IEnumerable<IFilter> filters)
        {
            Requires.NotNull(output, nameof(output));
            this.Output = output;
            this.Filters = filters;
        }

        public IOutput Output { get; private set; }
        public IEnumerable<IFilter> Filters { get; private set; }

        public void Dispose()
        {
            (Output as IDisposable)?.Dispose();

            if (Filters != null)
            {
                foreach (var f in Filters)
                {
                    (f as IDisposable)?.Dispose();
                }
            }
        }
    }
}
