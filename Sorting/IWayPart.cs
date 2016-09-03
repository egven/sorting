using System;

namespace WayInfo
{
    public interface IWayPart : IComparable<IWayPart>
    {
        string From { get; }
        string To { get; }
    }
}
