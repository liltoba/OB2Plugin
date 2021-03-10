# OB2Plugin
This Test Plugin For OpenBullet2

# Introduction
This guide will cover how you can develop plugins that add new blocks to OpenBullet 2.
You will need some C# knowledge in order to develop plugins.

# Setting up the project
First of all create a new C# project of the class library type. It’s important that you choose .NET 5 or above as target framework.

# For the sake of this guide, we’ll call it OB2TestPlugin.
Then reference RuriLib.dll from your project (you can find it in your compiled OpenBullet2 folder).

Now, delete the default class that is created for you and replace it with a brand new class, let’s call the file Methods.cs for example.

The code
We will create a block that simply adds two numbers together. Inside your Methods.cs file you will need to paste something like this

using RuriLib.Attributes;
using RuriLib.Logging;
using RuriLib.Models.Bots;

namespace OB2TestPlugin.Blocks.Calculator
{
    [BlockCategory("Calculator", "Blocks that allow to perform operations on numbers", "#9acd32")]
    public static class Methods
    {
        [Block("Adds two numbers together", name = "Addition")]
        public static int TestAddition(BotData data, int firstNumber, int secondNumber)
        {
            var sum = firstNumber + secondNumber;

            data.Logger.LogHeader();
            data.Logger.Log($"Calculated: {firstNumber} + {secondNumber} = {sum}", LogColors.YellowGreen);
            return sum;
        }
    }
}
The code explained
Choosing the correct namespace is very important because it will identify the path in the category tree that will be displayed in the Add block dialog. For example, if you choose

namespace OB2TestPlugin.Blocks.Calculator {
it will create a new node called OB2TestPlugin in the root of the category tree, a child node called Blocks and finally another child node called Calculator. You will find your block in there.

Note that the color of those nodes will be the same of the color you specified in the first valid category that is found.

[BlockCategory("Calculator", "Blocks that allow to perform operations on numbers", "#9acd32")]
public static class Methods
The BlockCategory attribute of the class is needed to specify the name, description and colors of the category that will appear in the new block selection menu.

[Block("Adds two numbers together", name = "Addition")]
public static int TestAddition(BotData data, int firstNumber, int secondNumber)
The Block attribute will decorate any of your methods that will be available as blocks once you import your plugin. It can be used to specify what the block does, and optionally its name (otherwise it will be inferred from the name of the method).

IMPORTANT: Try to use a unique name for your method, as it’s going to be the ID of the block in LoliCode, otherwise if another plugin has the same method name they will conflict and the user will need to delete one of them. A method name like Count is too ambiguous, so if your plugin is called TestPlugin maybe call the method TestPluginCount and then define its name using the name field of the Block attribute, as shown in the sample code.

We will then always need to pass BotData data as the first parameter, and then anything else you want among the supported types (see below).

var sum = firstNumber + secondNumber;
This is the functionality of our block, which will create a variable called sum that will be returned from the method.

data.Logger.LogHeader();
data.Logger.Log($"Calculated: {firstNumber} + {secondNumber} = {sum}", LogColors.YellowGreen);
It’s very important to log some information to let the user know if the execution of the block was successful or not. Use data.Logger.LogHeader() to print the label of the block and the name of the currently executing method, and data.Logger.Log() to print other information; use colors if you want!

return sum;
Finally we return the sum. For supported return types, see below.

# Supported types
The currently supported types that you can use as return types and parameters are:

bool
int
float
string
byte[]
List<string>
Dictionary<string, string>
enum types (only for parameters, not return types)
Stateful objects
If you need to pass a stateful object from one block to the other so you don’t have to re-initialize it, for example an HttpClient, you can use the data.Objects property, which is a Dictionary<string, object>.

Items of data.Objects that implement the IDisposable interface will automatically be disposed by a bot at the end of the execution, so you don’t need to do that manually.

# External dependencies
If your library needs to use external dependencies, you need to check if the same dependency is already included in the RuriLib.csproj file. If it is, then simply add the same line to your own OB2TestPlugin.csproj so it will use the same version.

Otherwise, feel free to add any external dependency, for example through nuget packages. You will then need to deliver these dependencies yourself.

# Packing your plugin
Once you’re done, you will be able to pack your plugin and share it with other people. Build the project in release mode and go to the output folder. Create a zip archive with the .dll file in the root and share the plugin.

If your plugin has external dependencies which are NOT included in RuriLib already, then you will need to also copy the .dll files for those dependencies into a folder with the same name of the plugin, for example your zip archive will look like this:

/MyPlugin.dll
/MyPlugin/Dependency1.dll
/MyPlugin/Dependency2.dll
Note: do not include the RuriLib.dll file in your archive, as it’s loaded by OpenBullet 2 already.

# Importing your plugin
Simply import the zip file in the Plugins section of OpenBullet 2. If you did everything correctly, you will then be able to navigate to the root of the category tree in the Add block dialog and find a section with the name of your plugin.

Source BY : LilToba
Thanks to Ruri
