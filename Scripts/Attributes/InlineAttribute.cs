using System;

namespace XMonoNode
{
    /// <summary> Mark a serializable field inline with next field </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class InlineAttribute : Attribute
    {
    }
}
