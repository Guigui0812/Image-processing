﻿// This code was generated by MIL CoPilot 10.40.881
// on Wednesday, November 30, 2022
// Compiling and running generated code will require :
// MIL 10 with Service Pack 4

using System;
using System.Text;
using Matrox.MatroxImagingLibrary;

namespace MilCoPilot_TP1Traitement_Image
   {
   class Program
      {
      private const string IMAGE_FILE = @"C:\Users\HENRI_VANLEMMENS\Downloads\GE141002.bmp";

        static void Main(string[] args)
        {
            MIL_ID MilApplication = MIL.M_NULL;
            MIL_ID MilSystem = MIL.M_NULL;
            MIL_ID Display = MIL.M_NULL;
            MIL_ID GE141002 = MIL.M_NULL;
            MIL_ID MimBinarizedestination = MIL.M_NULL;
            MIL_ID MimOpendestination = MIL.M_NULL;
            MIL_ID MimClosedestination = MIL.M_NULL;
            MIL_ID BlobContext = MIL.M_NULL;
            MIL_ID BlobResult = MIL.M_NULL;
            MIL_ID MImage = MIL.M_NULL;
            MIL_ID MImFille1 = MIL.M_NULL;
            MIL_ID MImFille2 = MIL.M_NULL;

            MIL.MappAlloc(MIL.M_NULL, MIL.M_DEFAULT, ref MilApplication);
            MIL.MsysAlloc(MIL.M_DEFAULT, "M_SYSTEM_HOST", MIL.M_DEFAULT, MIL.M_DEFAULT, ref MilSystem);
            MIL.MdispAlloc(MilSystem, MIL.M_DEFAULT, "M_DEFAULT", MIL.M_DEFAULT, ref Display);

            // Control Block for Display
            MIL.MdispControl(Display, MIL.M_TITLE, "TP1 Beton");

            //MIL.MbufImport(IMAGE_FILE, MIL.M_DEFAULT, MIL.M_RESTORE + MIL.M_NO_GRAB + MIL.M_NO_COMPRESS, MilSystem, ref GE141002);
            //MIL.MbufLoad(IMAGE_FILE, MImFille1);
            //MIL.MbufClone(GE141002, MIL.M_DEFAULT, MIL.M_DEFAULT, MIL.M_DEFAULT, MIL.M_DEFAULT, MIL.M_DEFAULT, MIL.M_DEFAULT, ref MimBinarizedestination);
            //MIL.MbufClone(MimBinarizedestination, MIL.M_DEFAULT, MIL.M_DEFAULT, MIL.M_DEFAULT, MIL.M_DEFAULT, MIL.M_DEFAULT, MIL.M_DEFAULT, ref MimOpendestination);
            //MIL.MbufClone(MimOpendestination, MIL.M_DEFAULT, MIL.M_DEFAULT, MIL.M_DEFAULT, MIL.M_DEFAULT, MIL.M_DEFAULT, MIL.M_DEFAULT, ref MimClosedestination);


            MIL.MblobAlloc(MilSystem, MIL.M_DEFAULT, MIL.M_DEFAULT, ref BlobContext);

            // Control Block for Blob Context
            MIL.MblobControl(BlobContext, MIL.M_IDENTIFIER_TYPE, MIL.M_BINARY);
            MIL.MblobControl(BlobContext, MIL.M_CENTER_OF_GRAVITY + MIL.M_BINARY, MIL.M_ENABLE);

            MIL.MblobAllocResult(MilSystem, MIL.M_DEFAULT, MIL.M_DEFAULT, ref BlobResult);

            MIL.MbufAlloc2d(MilSystem, 1536, 572, 8, MIL.M_IMAGE + MIL.M_DISP + MIL.M_PROC, ref MImage);
            MIL.MbufChild2d(MImage, 0, 0, 768, 572, ref MImFille1);
            MIL.MbufChild2d(MImage, 768, 0, 768, 572, ref MImFille2);

            MIL.MbufLoad(IMAGE_FILE, MImFille1);
            MIL.MimBinarize(MImFille1, MImFille2, MIL.M_BIMODAL + MIL.M_LESS, MIL.M_NULL, MIL.M_NULL);
            MIL.MdispSelect(Display, MImage);

            Console.WriteLine("Press <ENTER> to continue");
            Console.ReadKey();

            MIL.MimOpen(MImFille2, MImFille2, 2, MIL.M_BINARY);
            MIL.MdispSelect(Display, MImage);

            Console.WriteLine("Press <ENTER> to continue");
            Console.ReadKey();

            MIL.MimClose(MImFille2, MImFille2, 2, MIL.M_BINARY);

            MIL.MdispSelect(Display, MImage);

            Console.WriteLine("Press <ENTER> to continue");
            Console.ReadKey();

            MIL.MblobCalculate(BlobContext, MImFille2, MIL.M_NULL, BlobResult);

            double nbGranulats = 0;

            MIL.MblobGetResult(BlobResult, MIL.M_DEFAULT, MIL.M_NUMBER, ref nbGranulats);

            Console.WriteLine("Il y a " + nbGranulats.ToString() + " granulats.");

            Console.WriteLine("Press <ENTER> to continue");
            Console.ReadKey();

            int nbGranulatsInt = Convert.ToInt32(nbGranulats);

            double[] airsGranul = new double[nbGranulatsInt];
            MIL.MblobGetResult(BlobResult, MIL.M_DEFAULT, MIL.M_AREA, airsGranul);

            for (int i = 0; i < nbGranulatsInt; i++)
            {

                Console.WriteLine("L'aire du granulat " + (i + 1) + " est de " + airsGranul[i] + "pixels");
            }

            Console.WriteLine("Press <ENTER> to continue");
            Console.ReadKey();

            double[] gravityCenterX = new double[nbGranulatsInt];
            double[] gravityCenterY = new double[nbGranulatsInt];

            MIL.MblobGetResult(BlobResult, MIL.M_DEFAULT, MIL.M_CENTER_OF_GRAVITY_X, gravityCenterX);
            MIL.MblobGetResult(BlobResult, MIL.M_DEFAULT, MIL.M_CENTER_OF_GRAVITY_Y, gravityCenterY);

            for (int i = 0; i < nbGranulatsInt; i++)
            {
                Console.WriteLine("Les coordonnées du centre de gravité du granulat " + (i + 1) + " sont x: " + gravityCenterX[i] + " / y:" + gravityCenterY[i]);
            }

            Console.WriteLine("Press <ENTER> to continue");
            Console.ReadKey();

            double sumArea = 0;

            for (int i = 0; i < nbGranulatsInt; i++)
            {
                sumArea += airsGranul[i];
            }

            double meanArea = sumArea / nbGranulats;
            Console.WriteLine("L'aire moyenne des granulats est de " + meanArea.ToString());

            MIL_ID graphicContext = MIL.M_NULL;
            MIL.MgraAlloc(MilSystem, ref graphicContext);

            for (int i = 0; i < nbGranulatsInt; i++)
            {
                MIL.MgraText(graphicContext, MImFille2, gravityCenterX[i], gravityCenterY[i], i.ToString());
            }

            Console.ReadKey();

            MIL.MgraFree(graphicContext);
            MIL.MblobFree(BlobResult);
            MIL.MblobFree(BlobContext);
            MIL.MbufFree(MimClosedestination);
            MIL.MbufFree(MimOpendestination);
            MIL.MbufFree(MimBinarizedestination);
            MIL.MbufFree(GE141002);
            MIL.MbufFree(MImFille1);
            MIL.MbufFree(MImFille2);
            MIL.MbufFree(MImage);
            MIL.MdispFree(Display);
            MIL.MsysFree(MilSystem);
            MIL.MappFree(MilApplication);
        }
      }
   }
