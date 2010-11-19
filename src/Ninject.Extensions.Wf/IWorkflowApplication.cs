//-------------------------------------------------------------------------------
// <copyright file="IWorkflowApplication.cs" company="bbv Software Services AG">
//   Copyright (c) 2010 bbv Software Services AG
//   Author: Daniel Marbach
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//-------------------------------------------------------------------------------

namespace Ninject.Extensions.Wf
{
    using System;
    using System.Activities;
    using System.Collections.Generic;
    using System.Runtime.DurableInstancing;
    using Extensions;

    public interface IWorkflowApplication : IResolveExtensions
    {
        Action<WorkflowApplicationEventArgs> Unloaded { set; get; }
        Func<WorkflowApplicationIdleEventArgs, PersistableIdleAction> PersistableIdle { set; get; }
        Func<WorkflowApplicationUnhandledExceptionEventArgs, UnhandledExceptionAction> OnUnhandledException { set; get; }
        InstanceStore InstanceStore { set; get; }
        Action<WorkflowApplicationIdleEventArgs> Idle { set; get; }
        Guid Id { get; }
        Action<WorkflowApplicationCompletedEventArgs> Completed { set; get; }
        Action<WorkflowApplicationAbortedEventArgs> Aborted { set; get; }
        void Initialize(Activity workflowDefinition);
        void Initialize(Activity workflowDefinition, IDictionary<string, object> inputs);
        void Unload();
        void Unload(TimeSpan timeout);
        void Terminate(string reason);
        void Terminate(Exception reason);
        void Terminate(string reason, TimeSpan timeout);
        void Run();
        void Run(TimeSpan timeout);
        BookmarkResumptionResult ResumeBookmark(string bookmarkName, object value);
        BookmarkResumptionResult ResumeBookmark(Bookmark bookmark, object value);
        BookmarkResumptionResult ResumeBookmark(string bookmarkName, object value, TimeSpan timeout);
        BookmarkResumptionResult ResumeBookmark(Bookmark bookmark, object value, TimeSpan timeout);
        void Persist();
        void Persist(TimeSpan timeout);
        void LoadRunnableInstance();
        void LoadRunnableInstance(TimeSpan timeout);
        void Load(Guid instanceId);
        void Load(Guid instanceId, TimeSpan timeout);
    }
}