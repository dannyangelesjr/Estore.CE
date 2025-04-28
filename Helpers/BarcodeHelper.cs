using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Symbol.Barcode;


namespace Estore.Ce.Helpers
{
    public static class BarcodeHelper
    {
        public static string PadWithZerosAndDropCheckDigit(ReaderData readerData)
        {
            // convert scanned data to required format 
            string readerString = readerData.Text;
            readerString = readerData.Text;

            // drop check digit if EAN13
            if (readerData.Type == DecoderTypes.EAN13
                || readerData.Type == DecoderTypes.EAN8
                || readerData.Type == DecoderTypes.I2OF5
                || readerData.Type == DecoderTypes.UPCA)
            {
                readerString = readerString.Remove(readerString.Length - 1, 1);
            }
            // get item details
            return readerString.PadLeft(18, '0');
        }
    }
}
