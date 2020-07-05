using System;
using Demo.Core.Repositories;

namespace Demo.Core.Domain.Heroes
{
    public sealed class Hero
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
