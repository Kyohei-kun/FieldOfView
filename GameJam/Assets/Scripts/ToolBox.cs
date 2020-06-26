using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;

namespace Toolbox
{

    public static class ToolBox
    {
        static public int RandomBetween(int min, int max)
        {
            RNGCryptoServiceProvider random = new RNGCryptoServiceProvider();
            byte[] roll = new byte[1];

            do
            {
                random.GetBytes(roll);
            } while (roll[0] < min || roll[0] > max);

            return roll[0];
        }
    }

}