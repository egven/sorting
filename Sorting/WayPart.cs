using System;

namespace WayInfo
{    
    /// <summary>
    /// Определяет часть пути
    /// </summary>
    public class WayPart : IWayPart
    {
        public WayPart(string from, string to)
        {
            From = from;
            To = to;
        }
        /// <summary>
        /// Пункт отправления
        /// </summary>
        public string From { private set; get; }
        /// <summary>
        /// Пункт назначения
        /// </summary>
        public string To { private set; get; }
        /// <summary>
        /// Определяет отношение следования частей пути
        /// </summary>
        /// <param name="other">часть пути, сравниваемая с текущей</param>
        /// <returns>
        /// -1, если текущая (this) часть пути идет перед сравниваемой (other);
        /// 1, если после; 
        /// 0, если отношение следования не определено. 
        /// </returns>
        public int CompareTo(IWayPart other)
        {
            if (this.To == other.From)
                return -1;
            else if (other.To == this.From)
                return 1;
            else
                return 0;
        }

        public override string ToString()
        {
            return From + " " + To;
        }
    }
}
