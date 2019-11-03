﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ML;
using CombiConML.Model;

namespace CombiCon.Compute
{
    class ShakeRecogniser
    {
        private const string DATA_FILEPATH = @"C:\Source\testDataset.csv";

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
