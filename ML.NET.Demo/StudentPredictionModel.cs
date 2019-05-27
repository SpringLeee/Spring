using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.NET.Demo
{
    public class StudentPredictionModel
    {
        public string TrainerName;

        [ColumnName("Score")]
        public float PredictedG2;

        public override string ToString() => PredictedG2.ToString();
    }
}
