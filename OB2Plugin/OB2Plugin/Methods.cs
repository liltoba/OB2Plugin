using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RuriLib.Attributes;
using RuriLib.Logging;
using RuriLib.Models.Bots;

//Coded By LilToba

// And Tnx thanks for Ruri


namespace OB2Plugin.Blocks.TestCategory
{
    // Here For Making Category For All Your plugin Block
    // And About Your category

    [BlockCategory("TestCategory", "This Category Only For Testing", "#9acd32")]    // The last line indicates the color
    public static class Methods
    {
        // Here For Type Your Block Name In name And Add About Block
        [Block("TestingBlock", name = "Test")]



        public static int TestAddition(BotData data, int firstNumber, int secondNumber)
        {
            //here type your code

            var sum = firstNumber + secondNumber;

            //data logger just for showing status Plugin After Useing Block (if Working)
            data.Logger.LogHeader();
            data.Logger.Log($"Calculated: {firstNumber} + {secondNumber} = {sum}", LogColors.YellowGreen);
            return sum;
        }

        //If your library needs to use external dependencies, you need to check if the same dependency is already included in the RuriLib.csproj file. If it is, then simply add the same line to your own OB2TestPlugin.csproj so it will use the same version.

        //Otherwise, feel free to add any external dependency, for example through nuget packages.You will then need to deliver these dependencies yourself.


        //Do not forget Packing your plugin
        //Just Add plugin in ZipFile
    }
}
