using System;


namespace R5T.L0017.X002
{
    public struct ConsoleLogMessage
    {
        public string TimeStamp;
        public string LevelString;
        public ConsoleColor? LevelBackground;
        public ConsoleColor? LevelForeground;
        public ConsoleColor? MessageColor;
        public string MessageText;
        public bool LogAsError;
    }
}
