namespace Bog.Domain.Entities.Contracts
{
    using System;

    [AttributeUsage(AttributeTargets.Property)]
    public class NotNavigableAttribute : Attribute
    {
    }
}