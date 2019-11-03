using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ML;
using CombiConML.Model;

namespace CombiCon.Compute
{
    class ShakeRecogniser
    {
        private const string DATA_FILEPATH = @"C:.\Source\passwordAttempt.csv";

        public bool CompareAttemptWithActual()
        {
            List<int> numOfDirectionChangesForPassword = new List<int>();
            List<int> numOfDirectionChangesForAttempt = new List<int>();
            var savedOutput = GetEnumerableSamples("/Source/SavedPassword.csv");
            var savedAttempt = GetEnumerableSamples("/Source/PasswordAttempt.csv");

            foreach(ModelInput mi in savedOutput)
            {
                ModelOutput predictionResult = ConsumeModel.Predict(mi);
                if (predictionResult.Prediction == true)
                    numOfDirectionChangesForPassword.Add(1);
            }

            foreach(ModelInput mi in savedAttempt)
            {
                ModelOutput predictionResult = ConsumeModel.Predict(mi);
                if (predictionResult.Prediction == true)
                    numOfDirectionChangesForAttempt.Add(1);
            }

            Console.WriteLine(numOfDirectionChangesForPassword.Count.ToString());
            Console.WriteLine(numOfDirectionChangesForAttempt.Count.ToString());

            if ((numOfDirectionChangesForAttempt.Count) < (numOfDirectionChangesForPassword.Count * 1.2) && (numOfDirectionChangesForAttempt.Count) > (numOfDirectionChangesForPassword.Count * 0.8))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Method to load single row of dataset to try a single prediction
        private IEnumerable<ModelInput> GetEnumerableSamples(string dataFilePath)
        {
            // Create MLContext
            MLContext mlContext = new MLContext();

            // Load dataset
            IDataView dataView = mlContext.Data.LoadFromTextFile<ModelInput>(
                                            path: dataFilePath,
                                            hasHeader: true,
                                            separatorChar: ',',
                                            allowQuoting: true,
                                            allowSparse: false);

            // Use first line of dataset as model input
            // You can replace this with new test data (hardcoded or from end-user application)
            IEnumerable<ModelInput> sampleForPrediction = mlContext.Data.CreateEnumerable<ModelInput>(dataView, false);
            return sampleForPrediction;
        }
    }
}
