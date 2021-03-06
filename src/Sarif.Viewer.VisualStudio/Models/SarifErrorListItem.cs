﻿// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using Microsoft.CodeAnalysis.Sarif;
using Microsoft.Sarif.Viewer.Models;
using Microsoft.Sarif.Viewer.Sarif;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.Text;

namespace Microsoft.Sarif.Viewer
{
    public class SarifErrorListItem : NotifyPropertyChangedObject
    {
        private string _fileName;
        private ToolModel _tool;
        private RuleModel _rule;
        private InvocationModel _invocation;
        private string _selectedTab;
        private AnnotatedCodeLocationCollection _locations;
        private AnnotatedCodeLocationCollection _relatedLocations;
        private CallTreeCollection _callTrees;
        private ObservableCollection<StackCollection> _stacks;
        private ObservableCollection<FixModel> _fixes;
        private DelegateCommand _openLogFileCommand;
        ResultTextMarker _lineMarker;

        internal SarifErrorListItem()
        {
            _locations = new AnnotatedCodeLocationCollection(String.Empty);
            _relatedLocations = new AnnotatedCodeLocationCollection(String.Empty);
            _callTrees = new CallTreeCollection();
            _stacks = new ObservableCollection<StackCollection>();
            _fixes = new ObservableCollection<FixModel>();
        }

        public SarifErrorListItem(Run run, Result result, string logFilePath, ProjectNameCache projectNameCache) : this()
        {
            IRule rule;
            run.TryGetRule(result.RuleId, result.RuleKey, out rule);
            Message = result.GetMessageText(rule, concise: false);
            ShortMessage = result.GetMessageText(rule, concise: true);
            FileName = result.GetPrimaryTargetFile();
            ProjectName = projectNameCache.GetName(FileName);
            Category = result.GetCategory();
            Region = result.GetPrimaryTargetRegion();
            Level = result.Level;
            SuppressionStates = result.SuppressionStates;
            LogFilePath = logFilePath;

            if (Region != null)
            {
                LineNumber = Region.StartLine;
                ColumnNumber = Region.StartColumn;
            }

            Tool = run.Tool.ToToolModel();
            Rule = rule.ToRuleModel(result.RuleId);
            Invocation = run.Invocation.ToInvocationModel();

            if (String.IsNullOrWhiteSpace(run.Id))
            {
                WorkingDirectory = Path.Combine(Path.GetTempPath(), run.GetHashCode().ToString());
            }
            else
            {
                WorkingDirectory = Path.Combine(Path.GetTempPath(), run.Id);
            }

            if (result.Locations != null)
            {
                foreach (Location location in result.Locations)
                {
                    Locations.Add(location.ToAnnotatedCodeLocationModel());
                }
            }

            if (result.RelatedLocations != null)
            {
                foreach (AnnotatedCodeLocation annotatedCodeLocation in result.RelatedLocations)
                {
                    RelatedLocations.Add(annotatedCodeLocation.ToAnnotatedCodeLocationModel());
                }
            }

            if (result.CodeFlows != null)
            {
                foreach (CodeFlow codeFlow in result.CodeFlows)
                {
                    CallTrees.Add(codeFlow.ToCallTree());
                }

                CallTrees.Verbosity = 100;
                CallTrees.IntelligentExpand();
            }

            if (result.Stacks != null)
            {
                foreach (Stack stack in result.Stacks)
                {
                    Stacks.Add(stack.ToStackCollection());
                }
            }

            if (result.Fixes != null)
            {
                foreach (Fix fix in result.Fixes)
                {
                    Fixes.Add(fix.ToFixModel());
                }
            }
        }

        [Browsable(false)]
        public string MimeType { get; set; }


        [Browsable(false)]
        public Region Region { get; set; }

        [Browsable(false)]
        public string FileName
        {
            get
            {
                return _fileName;
            }

            set
            {
                if (value == _fileName) { return; }
                _fileName = value;
                NotifyPropertyChanged("FileName");
            }
        }

        [Browsable(false)]
        public string ProjectName { get; set; }

        [Browsable(false)]
        public bool RegionPopulated { get; set; }

        [Browsable(false)]
        public string WorkingDirectory { get; set; }

        [Browsable(false)]
        public string ShortMessage { get; set; }

        [Browsable(false)]
        public string Message { get; set; }

        [Browsable(false)]
        public SnapshotSpan Span { get; set; }

        [Browsable(false)]
        public int LineNumber { get; set; }

        [Browsable(false)]
        public int ColumnNumber { get; set; }

        [Browsable(false)]
        public string Category { get; set; }

        [ReadOnly(true)]
        public ResultLevel Level { get; set; }

        [Browsable(false)]
        public string HelpLink { get; set; }

        [DisplayName("Suppression states")]
        [ReadOnly(true)]
        public SuppressionStates SuppressionStates { get; set; }

        [DisplayName("Log file")]
        [ReadOnly(true)]
        public string LogFilePath { get; set; }

        [Browsable(false)]
        public ToolModel Tool
        {
            get
            {
                return _tool;
            }
            set
            {
                _tool = value;
                NotifyPropertyChanged("Tool");
            }
        }

        [Browsable(false)]
        public RuleModel Rule
        {
            get
            {
                return _rule;
            }
            set
            {
                _rule = value;
                NotifyPropertyChanged("Rule");
            }
        }

        [Browsable(false)]
        public InvocationModel Invocation
        {
            get
            {
                return _invocation;
            }
            set
            {
                _invocation = value;
                NotifyPropertyChanged("Invocation");
            }
        }

        [Browsable(false)]
        public string SelectedTab
        {
            get
            {
                return _selectedTab;
            }
            set
            {
                _selectedTab = value;

                // If a new tab is selected, remove all the the markers for the
                // previous tab.
                RemoveMarkers();

                // If a new tab is selected, reset the Properties window.
                SarifViewerPackage.SarifToolWindow.ResetSelection();
            }
        }

        [Browsable(false)]
        public AnnotatedCodeLocationCollection Locations
        {
            get
            {
                return _locations;
            }
        }

        [Browsable(false)]
        public AnnotatedCodeLocationCollection RelatedLocations
        {
            get
            {
                return _relatedLocations;
            }
        }

        [Browsable(false)]
        public CallTreeCollection CallTrees
        {
            get
            {
                return _callTrees;
            }
        }

        [Browsable(false)]
        public ObservableCollection<StackCollection> Stacks
        {
            get
            {
                return _stacks;
            }
        }

        [Browsable(false)]
        public ObservableCollection<FixModel> Fixes
        {
            get
            {
                return _fixes;
            }
        }

        [Browsable(false)]
        public bool HasDetails
        {
            get
            {
                return (Locations.Count + RelatedLocations.Count) > 0 || CallTrees.Count > 0 || Stacks.Count > 0 || Fixes.Count > 0;
            }
        }

        [Browsable(false)]
        public int LocationsCount
        {
            get
            {
                return Locations.Count + RelatedLocations.Count;
            }
        }

        [Browsable(false)]
        public bool HasMultipleLocations
        {
            get
            {
                return LocationsCount > 1;
            }
        }

        [Browsable(false)]
        public DelegateCommand OpenLogFileCommand
        {
            get
            {
                if (_openLogFileCommand == null)
                {
                    _openLogFileCommand = new DelegateCommand(() => OpenLogFile());
                }

                return _openLogFileCommand;
            }
        }

        internal void RemoveMarkers()
        {
            LineMarker?.RemoveHighlightMarker();

            foreach (AnnotatedCodeLocationModel location in Locations)
            {
                location.LineMarker?.RemoveHighlightMarker();
            }

            foreach (AnnotatedCodeLocationModel location in RelatedLocations)
            {
                location.LineMarker?.RemoveHighlightMarker();
            }

            foreach (CallTree callTree in CallTrees)
            {
                Stack<CallTreeNode> nodesToProcess = new Stack<CallTreeNode>();

                foreach (CallTreeNode topLevelNode in callTree.TopLevelNodes)
                {
                    nodesToProcess.Push(topLevelNode);
                }

                while (nodesToProcess.Count > 0)
                {
                    CallTreeNode current = nodesToProcess.Pop();
                    try
                    {
                        current.LineMarker?.RemoveHighlightMarker();
                    }
                    catch (ArgumentException)
                    {
                        // An argument exception is thrown if the node does not have a region.
                        // Since there's no region, there's no document to attach to.
                        // Just move on with processing the child nodes.
                    }

                    foreach (CallTreeNode childNode in current.Children)
                    {
                        nodesToProcess.Push(childNode);
                    }
                }
            }

            foreach (StackCollection stackCollection in Stacks)
            {
                foreach (StackFrameModel stackFrame in stackCollection)
                {
                    stackFrame.LineMarker?.RemoveHighlightMarker();
                }
            }
        }

        internal void OpenLogFile()
        {
            if (LogFilePath != null && System.IO.File.Exists(LogFilePath))
            {
                SarifViewerPackage.Dte.ExecuteCommand("File.OpenFile", $@"""{LogFilePath}"" /e:""JSON Editor""");
            }
        }

        public override string ToString()
        {
            return Message;
        }


        [Browsable(false)]
        public ResultTextMarker LineMarker
        {
            get
            {
                if (_lineMarker == null && Region != null && Region.StartLine > 0)
                {
                    _lineMarker = new ResultTextMarker(SarifViewerPackage.ServiceProvider, Region, FileName);
                }

                return _lineMarker;
            }
            set
            {
                _lineMarker = value;
            }
        }

        internal void RemapFilePath(string originalPath, string remappedPath)
        {
            if (FileName.Equals(originalPath, StringComparison.OrdinalIgnoreCase))
            {
                FileName = remappedPath;
            }

            foreach (AnnotatedCodeLocationModel location in Locations)
            {
                if (location.FilePath.Equals(originalPath, StringComparison.OrdinalIgnoreCase))
                {
                    location.FilePath = remappedPath;
                }
            }

            foreach (AnnotatedCodeLocationModel location in RelatedLocations)
            {
                if (location.FilePath.Equals(originalPath, StringComparison.OrdinalIgnoreCase))
                {
                    location.FilePath = remappedPath;
                }
            }

            foreach (CallTree callTree in CallTrees)
            {
                Stack<CallTreeNode> nodesToProcess = new Stack<CallTreeNode>();

                foreach (CallTreeNode topLevelNode in callTree.TopLevelNodes)
                {
                    nodesToProcess.Push(topLevelNode);
                }

                while (nodesToProcess.Count > 0)
                {
                    CallTreeNode current = nodesToProcess.Pop();
                    try
                    {
                        if (current.FilePath != null &&
                            current.FilePath.Equals(originalPath, StringComparison.OrdinalIgnoreCase))
                        {
                            current.FilePath = remappedPath;
                        }
                    }
                    catch (ArgumentException)
                    {
                        // An argument exception is thrown if the node does not have a region.
                        // Since there's no region, there's no document to attach to.
                        // Just move on with processing the child nodes.
                    }

                    foreach (CallTreeNode childNode in current.Children)
                    {
                        nodesToProcess.Push(childNode);
                    }
                }
            }

            foreach (StackCollection stackCollection in Stacks)
            {
                foreach (StackFrameModel stackFrame in stackCollection)
                {
                    if (stackFrame.FilePath.Equals(originalPath, StringComparison.OrdinalIgnoreCase))
                    {
                        stackFrame.FilePath = remappedPath;
                    }
                }
            }
        }

        internal void AttachToDocument(string documentName, long docCookie, IVsWindowFrame pFrame)
        {
            LineMarker?.AttachToDocument(documentName, docCookie, pFrame);

            foreach (AnnotatedCodeLocationModel location in Locations)
            {
                location.LineMarker?.AttachToDocument(documentName, docCookie, pFrame);
            }

            foreach (AnnotatedCodeLocationModel location in RelatedLocations)
            {
                location.LineMarker?.AttachToDocument(documentName, docCookie, pFrame);
            }

            foreach (CallTree callTree in CallTrees)
            {
                Stack<CallTreeNode> nodesToProcess = new Stack<CallTreeNode>();

                foreach (CallTreeNode topLevelNode in callTree.TopLevelNodes)
                {
                    nodesToProcess.Push(topLevelNode);
                }

                while (nodesToProcess.Count > 0)
                {
                    CallTreeNode current = nodesToProcess.Pop();

                    if (current.LineMarker?.CanAttachToDocument(documentName, docCookie, pFrame) == true)
                    {
                        current.LineMarker?.AttachToDocument(documentName, (long)docCookie, pFrame);
                        current.ApplyDefaultSourceFileHighlighting();
                    }

                    foreach (CallTreeNode childNode in current.Children)
                    {
                        nodesToProcess.Push(childNode);
                    }
                }
            }

            foreach (StackCollection stackCollection in Stacks)
            {
                foreach (StackFrameModel stackFrame in stackCollection)
                {
                    stackFrame.LineMarker?.AttachToDocument(documentName, docCookie, pFrame);
                }
            }
        }

        internal void DetachFromDocument(long docCookie)
        {
            LineMarker?.DetachFromDocument(docCookie);

            foreach (AnnotatedCodeLocationModel location in Locations)
            {
                location.LineMarker?.DetachFromDocument(docCookie);
            }

            foreach (AnnotatedCodeLocationModel location in RelatedLocations)
            {
                location.LineMarker?.DetachFromDocument(docCookie);
            }

            foreach (CallTree callTree in CallTrees)
            {
                Stack<CallTreeNode> nodesToProcess = new Stack<CallTreeNode>();

                foreach (CallTreeNode topLevelNode in callTree.TopLevelNodes)
                {
                    nodesToProcess.Push(topLevelNode);
                }

                while (nodesToProcess.Count > 0)
                {
                    CallTreeNode current = nodesToProcess.Pop();
                    current.LineMarker?.DetachFromDocument((long)docCookie);

                    foreach (CallTreeNode childNode in current.Children)
                    {
                        nodesToProcess.Push(childNode);
                    }
                }
            }

            foreach (StackCollection stackCollection in Stacks)
            {
                foreach (StackFrameModel stackFrame in stackCollection)
                {
                    stackFrame.LineMarker?.DetachFromDocument(docCookie);
                }
            }
        }
    }
}