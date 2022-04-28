﻿using System.Collections.Generic;

namespace newsmobileapp.Models
{
    public interface IAnalyticsManager
    {
        void LogEvent(string eventId);
        void LogEvent(string eventId, string paramName, string value);
        void LogEvent(string eventId, IDictionary<string, string> parameters);
    }
}
