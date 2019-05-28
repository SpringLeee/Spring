using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.NET.Demo
{
    public class PredictionBaseModel
    {
        public string TrainerName;

        [ColumnName("Score")]
        public float PWear;

        public override string ToString() => PWear.ToString();
    }
}
