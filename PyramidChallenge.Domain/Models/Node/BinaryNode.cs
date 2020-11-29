using System;
using System.Diagnostics.CodeAnalysis;

namespace PyramidChallenge.Domain.Models.Node
{
    public class BinaryNode : IEquatable<BinaryNode>
    {
        public BinaryNode Left { get; set; }
        public BinaryNode Right { get; set; }

        public NodeValue Value { get; }

        public BinaryNode(int value)
        {
            Value = NodeValue.Create(value);
        }

        public BinaryNode(string value)
        {
            Value = NodeValue.Parse(value);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as BinaryNode);
        }

        public bool Equals([AllowNull] BinaryNode other)
        {
            if (other == null)
                return false;

            return Value == other.Value
                && Left == other.Left
                && Right == other.Right;
        }

        public override int GetHashCode()
        {
            return (Left.GetHashCode() * 0x100000) + (Right.GetHashCode() * 0x100000) + Value.GetHashCode();
        }

        public static bool operator ==(BinaryNode lhs, BinaryNode rhs)
        {
            if (lhs is null)
            {
                if (rhs is null)
                    return true;

                return false;
            }

            return lhs.Equals(rhs);
        }

        public static bool operator !=(BinaryNode lhs, BinaryNode rhs)
            => !(lhs == rhs);
    }
}
