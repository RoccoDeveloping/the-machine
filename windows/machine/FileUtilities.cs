﻿/* By devloop0 (Nikhil Athreya) */
/***
    This file contains the definition of all of the files' names to store different parts of the Machine.
    This software is licensed under the MIT License.
    The purpose of this software is to be a simulation of "the Machine" from the *Person of Interest* show.

    MIT License:
    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE.
***/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace machine
{
    class FileUtilities
    {
        public const String AdminTrainedPrefix = "ADMIN_DATA_"; // The prefix for files with ANN's trained for admin recognition.
        public const String AuxAdminTrainedPrefix = "AUX_ADMIN_DATA_"; // The prefix used for files with ANN's trained for auxiliary admin recognition.
        public const String AssetTrainedPrefix = "ASSET_DATA_"; // The prefix used for files with ANN's trained for asset recognition.
        public const String ContingencyPrefix = "CONTINGENCY_"; // The prefix used for files with ANN's trained for contingency recognition.
        public const String ThreatPrefix = "THREAT_"; // The prefix used for files with ANN's trained for threat recognition.
        public const String DirectoryName = "MACHINE_CORE_HEURISTICS"; // The folder containing all of the data generated by the Machine.
        public const String TrainingDirectoryName = DirectoryName + "\\training"; // The training directory for image samples for the Machine.
        public const String SampleImagePrefix = "sample_"; // The prefix used for images for training the Machine.
        public const String CoreImageData = "CORE_IMAGE_DATA.dat"; // The file containing the constant height and width of training and testing files.
        public const String AssetIndexData = "ASSET_INDEX.dat"; // The master index of all faces that the Machine is trained to recognition.
        public const String FileExtension = ".dat"; // The file extension of all the data files for the Machine.

        /*** 
            Function: public static void DirectoryCreation()
            Parameter(s):
            Return Value: void
                This function creates the Machine data directory if it does not exist; if the directory already exist, then nothing
                happens to the directory itself.
        ***/
        public static void DirectoryCreation()
        {
            bool dataDirectoryExists = Directory.Exists(DirectoryName);
            if (!dataDirectoryExists)
                Directory.CreateDirectory(DirectoryName);
        }

        /***
            Function: public static void TrainingDirectoryCreation()
            Parameter(s):
            Return Value: void
                This function creates the Machine training directory where it stores the image samples from the face that it is currently
                training itself to recognize. If the directory already exists, then nothing happens to the directory itself.
        ***/
        public static void TrainingDirectoryCreation()
        {
            bool trainedFacesDirectoryExists = Directory.Exists(TrainingDirectoryName);
            if (!trainedFacesDirectoryExists)
                Directory.CreateDirectory(TrainingDirectoryName);
        }

        /***
            Function: public static void CoreImageDataCreation()
            Parameter(s):
            Return Value: void
                This function creates the file where the Machine stores the constant height and width with which to scale all images for training 
                and recognition. If the file already exists, then nothing happens to the file itself.
        ***/
        public static void CoreImageDataCreation()
        {
            String fileName = DirectoryName + "\\" + CoreImageData;
            if (!File.Exists(fileName))
                File.Create(fileName);
        }

        /***
            Function: public static void AssetIndexCreation()
            Parameter(s):
            Return Value: void
                This function creates the file where the Machine stores its master index of all of the people it can recognize. If this file already
                exists, then nothing happens to the file itself.
        ***/
        public static void AssetIndexDataCreation()
        {
            String fileName = DirectoryName + "\\" + AssetIndexData;
            if (!File.Exists(fileName))
                File.Create(fileName);
        }

        /***
            Function: public static void TrainingDirectoryDeletion()
            Parameter(s):
            Return Value: void
                This function deletes the training directory used by the Machine where it stores its image samples of the person it is training itself to
                recognize. If the directory does not exist, then this function does nothing to any other file or directory.
        ***/
        public static void TrainingDirectoryDeletion()
        {
            bool trainedFacesDirectoryExists = Directory.Exists(TrainingDirectoryName);
            if (trainedFacesDirectoryExists)
                Directory.Delete(TrainingDirectoryName, true);
        }
    }
}