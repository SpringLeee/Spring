using Microsoft.Data.DataView;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Model;
using Microsoft.ML.Trainers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.NET.Demo
{ 
    public class LearningSession
    {
        private readonly MLContext mlContext;
        private readonly TextLoader textLoader;
        private readonly List<ITrainerEstimator<ISingleFeaturePredictionTransformer<ModelParametersBase<float>>, ModelParametersBase<float>>> trainers =
            new List<ITrainerEstimator<ISingleFeaturePredictionTransformer<ModelParametersBase<float>>, ModelParametersBase<float>>>();
        private readonly Dictionary<string, ITransformer> trainedModels = new Dictionary<string, ITransformer>();

        public LearningSession(MLContext mlContext, IEnumerable<ITrainerEstimator<ISingleFeaturePredictionTransformer<ModelParametersBase<float>>, ModelParametersBase<float>>> regressionTrainers)
        {
            this.mlContext = mlContext;
            textLoader = mlContext.Data.CreateTextLoader(new TextLoader.Options
            {
                Columns = new TextLoader.Column[]
                {
                    new TextLoader.Column("Cutter", DataKind.String, 0),
                    new TextLoader.Column("WorkType", DataKind.String, 1),
                    new TextLoader.Column("Cool", DataKind.String, 2),
                    new TextLoader.Column("MainRate", DataKind.Single, 3),
                    new TextLoader.Column("InPoint", DataKind.Single, 4),
                    new TextLoader.Column("InSpeed", DataKind.Single, 5),
                    new TextLoader.Column("CutSpeed", DataKind.Single, 6),
                    new TextLoader.Column("CutEat", DataKind.Single, 7),
                    new TextLoader.Column("WearPoint", DataKind.Single, 8)
                }
            });

            trainers.AddRange(regressionTrainers);  
        }

        public PredictionBaseModel Predict(ITransformer trainedModel, BaseModel model)
        {
            var engine = trainedModel.CreatePredictionEngine<BaseModel, PredictionBaseModel>(mlContext);
            return engine.Predict(model);
        }

        public IDataView LoadDataView(string path)  => textLoader.Load(path);

        public IEnumerable<KeyValuePair<string, RegressionMetrics>> TrainAndEvaluate(IDataView trainingDataView, IDataView testDataView)
        {
            var metrics = new Dictionary<string, RegressionMetrics>();
            foreach (var trainer in this.trainers)
            { 
                var pipeline = mlContext.Transforms.CopyColumns(inputColumnName: "WearPoint", outputColumnName: "Label")
                    .Append(mlContext.Transforms.Categorical.OneHotEncoding("Cutter"))
                    .Append(mlContext.Transforms.Categorical.OneHotEncoding("WorkType"))
                    .Append(mlContext.Transforms.Categorical.OneHotEncoding("Cool"))
                    .Append(mlContext.Transforms.Categorical.OneHotEncoding("MainRate"))
                    .Append(mlContext.Transforms.Categorical.OneHotEncoding("InPoint"))
                    .Append(mlContext.Transforms.Categorical.OneHotEncoding("InSpeed"))
                    .Append(mlContext.Transforms.Categorical.OneHotEncoding("CutSpeed"))
                    .Append(mlContext.Transforms.Categorical.OneHotEncoding("CutEat"))
                    .Append(mlContext.Transforms.Concatenate("Features",
                        "Cutter",
                        "WorkType",
                        "Cool",
                        "MainRate",
                        "InPoint",
                        "InSpeed",
                        "CutSpeed",
                        "CutEat"))
                    .AppendCacheCheckpoint(mlContext)
                    .Append(trainer);  

                var trainedModel = pipeline.Fit(trainingDataView);
                trainedModels.Add(trainer.GetType().Name, trainedModel);

                var predictionModel = trainedModel.Transform(testDataView);
                var regMetrics = mlContext.Regression.Evaluate(predictionModel);
                metrics.Add(trainer.GetType().Name, regMetrics);
            }

            return metrics;
        }


        public static void OutputRegressionMetrics(string trainer, RegressionMetrics regMetrics)
        {
            Console.WriteLine($"< {trainer} >");
            Console.WriteLine("*************************************");
            Console.WriteLine($" L1: {regMetrics.L1}");
            Console.WriteLine($" L2: {regMetrics.L2}");
            Console.WriteLine($" LossFn: {regMetrics.LossFn}");
            Console.WriteLine($" Rms: {regMetrics.Rms}");
            Console.WriteLine($" RSquared: {regMetrics.RSquared}");
            Console.WriteLine();
        }

        public ITransformer GetTrainedModel(string trainerName)
        {
            return trainedModels.FirstOrDefault(kvp => string.Equals(kvp.Key, trainerName)).Value;
        }




    }
}
