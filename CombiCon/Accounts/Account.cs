using System;
using System.Collections.Generic;
using System.Numerics;

namespace CombiCon.Accounts
{
    public class Account
    {
        List<Vector3> _sequence;

        public Account(List<Vector3> seq)
        {
            _sequence = seq;
        }

        public double GenerateSimilarity(List<Vector3> attempt)
        {
            double similarity = 0;

            for (int i = 0; i < _sequence.Count; i++)
            {
                Vector3 delta = attempt[i] - _sequence[i];
                similarity += Math.Sqrt(Math.Pow(delta.X, 2) + Math.Pow(delta.Y, 2) + Math.Pow(delta.Z, 2));
            }

            return similarity;
        }
    }
}
