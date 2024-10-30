﻿using Avalonia.Media;

namespace SourceGit.Models
{
    public class CommitSignInfo
    {
        public string Key { get; set; } = string.Empty;
        public char VerifyResult { get; set; } = 'N';

        public IBrush Brush
        {
            get
            {
                switch (VerifyResult)
                {
                    case 'G':
                    case 'U':
                        return Brushes.Green;
                    case 'X':
                    case 'Y':
                    case 'R':
                        return Brushes.DarkOrange;
                    case 'B':
                    case 'E':
                        return Brushes.Red;
                    default:
                        return Brushes.Transparent;
                }
            }
        }

        public string ToolTip
        {
            get
            {
                switch (VerifyResult)
                {
                    case 'G':
                        return $"Good Signature.\n\nKey: {Key}";
                    case 'B':
                        return $"Bad Signature.\n\nKey: {Key}";
                    case 'U':
                        return $"Good Signature with unknown validity.\n\nKey: {Key}";
                    case 'X':
                        return $"Good Signature but has expired.\n\nKey: {Key}";
                    case 'Y':
                        return $"Good Signature made by expired key.\n\nKey: {Key}";
                    case 'R':
                        return $"Good signature made by a revoked key.\n\nKey: {Key}";
                    case 'E':
                        return $"Signature cannot be checked.\n\nKey: {Key}";
                    default:
                        return "No signature.";
                }
            }
        }
    }
}