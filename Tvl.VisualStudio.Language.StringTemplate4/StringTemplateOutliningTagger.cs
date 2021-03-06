﻿namespace Tvl.VisualStudio.Language.StringTemplate4
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using Antlr4.StringTemplate.Misc;
    using Microsoft.VisualStudio.Text;
    using Microsoft.VisualStudio.Text.Tagging;
    using Tvl.VisualStudio.Language.Parsing;

    internal sealed class StringTemplateOutliningTagger : ITagger<IOutliningRegionTag>
    {
        private List<ITagSpan<IOutliningRegionTag>> _outliningRegions;
        private readonly StringTemplateOutliningTaggerProvider _provider;

        public event EventHandler<SnapshotSpanEventArgs> TagsChanged;

        public StringTemplateOutliningTagger(ITextBuffer textBuffer, IBackgroundParser backgroundParser, StringTemplateOutliningTaggerProvider provider)
        {
            Contract.Requires<ArgumentNullException>(textBuffer != null, "textBuffer");
            Contract.Requires<ArgumentNullException>(backgroundParser != null, "backgroundParser");
            Contract.Requires<ArgumentNullException>(provider != null, "provider");

            this.TextBuffer = textBuffer;
            this.BackgroundParser = backgroundParser;
            this._provider = provider;

            this._outliningRegions = new List<ITagSpan<IOutliningRegionTag>>();

            this.BackgroundParser.ParseComplete += HandleBackgroundParseComplete;
            this.BackgroundParser.RequestParse(false);
        }

        private ITextBuffer TextBuffer
        {
            get;
            set;
        }

        private IBackgroundParser BackgroundParser
        {
            get;
            set;
        }

        public IEnumerable<ITagSpan<IOutliningRegionTag>> GetTags(NormalizedSnapshotSpanCollection spans)
        {
            return _outliningRegions;
        }

        private void OnTagsChanged(SnapshotSpanEventArgs e)
        {
            var t = TagsChanged;
            if (t != null)
                t(this, e);
        }

        private void HandleBackgroundParseComplete(object sender, ParseResultEventArgs e)
        {
            List<ITagSpan<IOutliningRegionTag>> outliningRegions = new List<ITagSpan<IOutliningRegionTag>>();
            AntlrParseResultEventArgs antlrParseResultArgs = e as AntlrParseResultEventArgs;
            if (antlrParseResultArgs != null)
            {
                var result = antlrParseResultArgs.Result as StringTemplateBackgroundParser.TemplateGroupRuleReturnScope;
                if (result != null)
                {
                    foreach (var templateInfo in result.Group.GetTemplateInformation())
                    {
                        var template = templateInfo.Template;

                        if (template.IsAnonSubtemplate)
                            continue;

                        if (template.IsRegion && template.RegionDefType != Antlr4.StringTemplate.Template.RegionType.Explicit)
                            continue;

                        Interval sourceInterval = templateInfo.GroupInterval;
                        SnapshotSpan span = new SnapshotSpan(e.Snapshot, new Span(sourceInterval.Start, sourceInterval.Length));
                        if (e.Snapshot.GetLineNumberFromPosition(span.Start) == e.Snapshot.GetLineNumberFromPosition(span.End))
                            continue;

                        IOutliningRegionTag tag = new OutliningRegionTag();
                        outliningRegions.Add(new TagSpan<IOutliningRegionTag>(span, tag));
                    }
                }
            }

            this._outliningRegions = outliningRegions;
            OnTagsChanged(new SnapshotSpanEventArgs(new SnapshotSpan(e.Snapshot, new Span(0, e.Snapshot.Length))));
        }
    }
}
