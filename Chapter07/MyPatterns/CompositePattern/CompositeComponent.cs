﻿using System;
using System.Collections.Generic;

namespace CompositePattern
{
    public class CompositeComponent : IComponent
    {
        private readonly ICollection<IComponent> children;
        private string Name;

        public CompositeComponent(string name)
        {
            this.Name = name;
            this.children = new List<IComponent>();
        }

        public void Something(string indent)
        {
            Console.WriteLine($"{indent}{GetType().Name} 0x{GetHashCode():X}");
            foreach (var child in children)
            {
                child.Something(indent + "    ");
            }
        }

        public CompositeComponent AddComponent(IComponent component)
        {
            children.Add(component);
            return this;
        }

        public void RemoveComponent(IComponent component)
        {
            children.Remove(component);
        }

    }
}
