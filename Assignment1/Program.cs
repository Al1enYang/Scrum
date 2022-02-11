using System;
using System.Collections.Generic;

namespace Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            iToolLibrarySystemImpl iToolLibrarySystem = new iToolLibrarySystemImpl();
            init(iToolLibrarySystem);
            mainMenu(iToolLibrarySystem);
        }
        private static void init(iToolLibrarySystemImpl iToolLibrarySystem)
        {
            // add some init users
            iMember member1 = new iMemberImpl();
            member1.FirstName = "Maolin";
            member1.LastName = "Tang";
            member1.ContactNumber = "12345678";
            member1.PIN = "1234";
            iToolLibrarySystem.iMembers.add(member1);

            // add some tools
            iToolImpl tool1 = new iToolImpl();
            tool1.category = "Painting Tools";
            tool1.type = "Sanding Tools";
            tool1.Name = "Irwin 125mm Orbital Sander";
            tool1.Quantity = 5;
            tool1.AvailableQuantity = 5;
            iToolLibrarySystem.iToolCollection.add(tool1);

            iToolImpl tool2 = new iToolImpl();
            tool2.category = "Painting Tools";
            tool2.type = "Sanding Tools";
            tool2.Name = "Rocket Sanding Block Holder";
            tool2.Quantity = 2;
            tool2.AvailableQuantity = 2;
            iToolLibrarySystem.iToolCollection.add(tool2);

            iToolImpl tool3 = new iToolImpl();
            tool3.category = "Painting Tools";
            tool3.type = "Sanding Tools";
            tool3.Name = "PowerFit120 Triangular Sander";
            tool3.Quantity = 1;
            tool3.AvailableQuantity = 1;
            iToolLibrarySystem.iToolCollection.add(tool3);
        }
        private static void mainMenu(iToolLibrarySystemImpl iToolLibrarySystem)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Tool Library");
                Console.WriteLine("==========Main Menu==========");
                Console.WriteLine("1. Staff Login");
                Console.WriteLine("2. Member Login");
                Console.WriteLine("0. Exit");
                Console.WriteLine("=============================\n");
                Console.WriteLine("Please make a selection (1-2, or 0 to exit):");

                string input = Console.ReadLine();
                int key;
                while (!int.TryParse(input, out key) ||
                    key < 0 || key > 2)
                {
                    Console.WriteLine("\nInvalid input, try again:");
                    input = Console.ReadLine();
                }
                switch (key)
                {
                    case 0: Console.WriteLine("System Exiting..."); return;
                    case 1: staffMenu(iToolLibrarySystem); break;
                    case 2: memberMenu(iToolLibrarySystem); break;
                    default: return;
                }
            } while (true);
        }

        private static void staffMenu(iToolLibrarySystemImpl iToolLibrarySystem)
        {
            Console.Clear();
            do
            {
                Console.WriteLine("\nWelcome to the Tool Library");
                Console.WriteLine("==========Staff Menu==========");
                Console.WriteLine("1. Add a new tool");
                Console.WriteLine("2. Add new pieces of an existing tool");
                Console.WriteLine("3. Remove some pieces of a tool");
                Console.WriteLine("4. Register a new member");
                Console.WriteLine("5. Remove a member");
                Console.WriteLine("6. Find the contract number of a member");
                Console.WriteLine("0. Return to main menu");
                Console.WriteLine("==============================\n");
                Console.WriteLine("Please make a selection (1-5, or 0 to exit):");

                string input = Console.ReadLine();
                int key;
                while (!int.TryParse(input, out key) ||
                    key < 0 || key > 6)
                {
                    Console.WriteLine("\nInvalid input, try again:");
                    input = Console.ReadLine();
                }
                switch (key)
                {
                    case 0: return;
                    case 1:
                        {
                            /*
                            Add a new tool to the system
                                •Display all the nine (9) tool categories
                                •Select a category
                                •Display all the tool types of the selected category
                                •Select a tool type
                                •Display all the tools of the selected tool type
                                •Add a new tool to the tool type
                                •Display all the tools in the selected tool type again
                            */
                            // 1 Display all the nine (9) tool categories
                            Console.WriteLine("\nAll tool categories:");
                            int index;
                            for (index = 0; index < 9; index++)
                            {
                                Console.WriteLine(index + ":" + categories[index]);
                            }
                            // 2 Select a category
                            Console.WriteLine("\nNow enter the number of category that the tool belongs to:");
                            string selectCategory = Console.ReadLine();
                            int categoryNumber;
                            while (!int.TryParse(selectCategory, out categoryNumber) ||
                                categoryNumber < 0 || categoryNumber > 8)
                            {
                                Console.WriteLine("\nInvalid input, try again:");
                                selectCategory = Console.ReadLine();
                            }

                            // 3 Display all the tool types of the selected tool category
                            Console.WriteLine("\nAll tools under this type are displayed as following:");
                            List<string> toolTypes = new List<string>();
                            index = 0;
                            foreach (iToolImpl tool in iToolLibrarySystem.iToolCollection.toArray())
                            {
                                if (tool.category.Equals(categories[categoryNumber]) && !toolTypes.Contains(tool.type))
                                {
                                    toolTypes.Add(tool.type);
                                    Console.WriteLine(index + ":" + tool.type);
                                    index++;
                                }
                            }
                            Console.WriteLine(index + ":Add a new one:");
                            if (toolTypes.Count == 0)
                            {
                                Console.WriteLine("\nThere is no tool under this category, you have to add one.");
                            }
                            // 4 Select a tool type
                            Console.WriteLine("\nNow enter the number of tool type:");
                            string selectType = Console.ReadLine();
                            int typeNumber;
                            while (!int.TryParse(selectType, out typeNumber) ||
                                typeNumber < 0 || typeNumber > toolTypes.Count)
                            {
                                Console.WriteLine("\nInvalid input, try again:");
                                selectType = Console.ReadLine();
                            }

                            // Select a tool type
                            string toolType;
                            if (typeNumber == toolTypes.Count)
                            {
                                Console.WriteLine("\nNow enter the type of the tool:");
                                toolType = Console.ReadLine();
                            }
                            else
                            {
                                toolType = toolTypes.ToArray()[typeNumber];
                            }

                            // 5 Display all the tools of the selected tool type
                            Console.WriteLine("\nAll tools under this type are displayed as following:");
                            foreach (iToolImpl tool in iToolLibrarySystem.iToolCollection.toArray())
                            {
                                if (tool.type.Equals(toolType)) Console.WriteLine(tool.Name);
                            }
                            // 5 Add a new tool to the tool type
                            string toolName;
                            int toolQuantity = 1;
                            Console.WriteLine("\nNow add a new tool.\nPlease input the name of new tool:");
                            toolName = Console.ReadLine();

                            iToolImpl newTool = new iToolImpl();
                            newTool.Name = toolName;
                            newTool.Quantity = toolQuantity;
                            newTool.AvailableQuantity = newTool.Quantity;
                            newTool.type = toolType;
                            newTool.category = categories[categoryNumber];
                            iToolLibrarySystem.iToolCollection.add(newTool);

                            // 6 Display all the tools in the selected tool type again
                            Console.WriteLine("\nNow tools are displayed as following:");
                            int count = 0;
                            foreach (iToolImpl tool in iToolLibrarySystem.iToolCollection.toArray())
                            {
                                if (tool.type.Equals(toolType))
                                {
                                    Console.WriteLine(tool.Name);
                                    count++;
                                }
                            }
                            if (count == 0) Console.WriteLine("\nThere is no tool in this tool type!");
                            else  Console.WriteLine("\nSuccessfully Added!");
                        }
                        break;
                    case 2:
                        {
                            //Add new pieces of an existing tool to the system
                            /*
                            Add new pieces of an existing tool to the system
                                •Display all the tool categories
                                •Select a category
                                •Display all the tool types of the selected category
                                •Select a tool type
                                •Display all the tools of the selected tool type
                                •Select a tool from the tool list
                                •Add the quantity of the tool
                            */
                            // 1 Display all the nine (9) tool categories
                            Console.WriteLine("\nAll tool categories:");
                            int index;
                            for (index = 0; index < 9; index++)
                            {
                                Console.WriteLine(index + ":" + categories[index]);
                            }
                            // 2 Select a category
                            Console.WriteLine("\nNow enter the number of category that the tool belongs to:");
                            string selectCategory = Console.ReadLine();
                            int categoryNumber;
                            while (!int.TryParse(selectCategory, out categoryNumber) ||
                                categoryNumber < 0 || categoryNumber > 8)
                            {
                                Console.WriteLine("\nInvalid input, try again:");
                                selectCategory = Console.ReadLine();
                            }

                            // 3 Display all the tool types of the selected tool category
                            Console.WriteLine("\nAll tools under this type are displayed as following:");
                            List<string> toolTypes = new List<string>();
                            index = 0;
                            foreach (iToolImpl tool in iToolLibrarySystem.iToolCollection.toArray())
                            {
                                if (tool.category.Equals(categories[categoryNumber]) && !toolTypes.Contains(tool.type))
                                {
                                    toolTypes.Add(tool.type);
                                    Console.WriteLine(index + ":" + tool.type);
                                    index++;
                                }
                            }
                            if (toolTypes.Count == 0)
                            {
                                Console.WriteLine("There is no tool under this category");
                                Console.ReadKey();
                                break;
                            }
                            // 4 Select a tool type
                            Console.WriteLine("\nNow enter the number of tool type:");
                            string selectType = Console.ReadLine();
                            int typeNumber;
                            while (!int.TryParse(selectType, out typeNumber) ||
                                typeNumber < 0 || typeNumber > toolTypes.Count)
                            {
                                Console.WriteLine("\nInvalid input, try again:");
                                selectType = Console.ReadLine();
                            }
                            // 5 Display all the tools of the selected tool type
                            index = 0;
                            List<iTool> tools = new List<iTool>();
                            Console.WriteLine("\nTools:");
                            foreach (iToolImpl tool in iToolLibrarySystem.iToolCollection.toArray())
                            {
                                if (tool.type.Equals(toolTypes.ToArray()[typeNumber]))
                                {
                                    Console.WriteLine(index + ":" + tool.Name);
                                    index++;
                                    tools.Add(tool);
                                }
                            }

                            // 6 Select a tool from the tool list
                            Console.WriteLine("\nNow enter the number of tool:");
                            string selectTool = Console.ReadLine();
                            int toolNumber;
                            while (!int.TryParse(selectTool, out toolNumber) ||
                                toolNumber < 0 || toolNumber > tools.Count)
                            {
                                Console.WriteLine("\nInvalid input, try again:");
                                selectTool = Console.ReadLine();
                            }
                            iTool selectedTool = tools.ToArray()[toolNumber];
                            // 7 Add the quantity of the tool
                            Console.WriteLine("\nCurrent quantity of tool:" + selectedTool.Quantity);
                            Console.WriteLine("Now enter the quantity that you want to add to this tool:");
                            string addQuantity = Console.ReadLine();
                            int addQuantityNumber;
                            while (!int.TryParse(addQuantity, out addQuantityNumber) || addQuantityNumber < 1)
                            {
                                Console.WriteLine("\nInvalid input, try again:");
                                addQuantity = Console.ReadLine();
                            }
                            iToolLibrarySystem.add(selectedTool, addQuantityNumber);
                            Console.WriteLine("\nNow new quantity of tool:" + selectedTool.Quantity);
                        }
                        break;
                    case 3:
                        {
                            /*
                            Remove some pieces of a tool from the system
                                •Display all the nine (9) tool categories
                                •Select a category
                                •Display all the tool types of the selected category
                                •Select a tool type
                                •Display all the tools of the selected tool type
                                •Select a tool from the tool list
                                •Input the number of pieces of the tool to be removed
                                •If the number of pieces of the tool is not more than the number of pieces that are currently in the library, reduce the total quantity and the available quantity of the tool
                            */
                            // 1 Display all the nine (9) tool categories
                            Console.WriteLine("\nAll tool categories:");
                            int index;
                            for (index = 0; index < 9; index++)
                            {
                                Console.WriteLine(index + ":" + categories[index]);
                            }
                            // 2 Select a category
                            Console.WriteLine("\nNow enter the number of category that the tool belongs to:");
                            string selectCategory = Console.ReadLine();
                            int categoryNumber;
                            while (!int.TryParse(selectCategory, out categoryNumber) ||
                                key < 0 || key > 8)
                            {
                                Console.WriteLine("\nInvalid input, try again:");
                                selectCategory = Console.ReadLine();
                            }

                            // 3 Display all the tool types of the selected tool category
                            Console.WriteLine("\nAll tools under this type are displayed as following:");
                            List<string> toolTypes = new List<string>();
                            index = 0;
                            foreach (iToolImpl tool in iToolLibrarySystem.iToolCollection.toArray())
                            {
                                if (tool.category.Equals(categories[categoryNumber]) && !toolTypes.Contains(tool.type))
                                {
                                    toolTypes.Add(tool.type);
                                    Console.WriteLine(index + ":" + tool.type);
                                    index++;
                                }
                            }
                            if (toolTypes.Count == 0)
                            {
                                Console.WriteLine("There is no tool under this category");
                                Console.ReadKey();
                                break;
                            }
                            // 4 Select a tool type
                            Console.WriteLine("\nNow enter the number of tool type:");
                            string selectType = Console.ReadLine();
                            int typeNumber;
                            while (!int.TryParse(selectType, out typeNumber) ||
                                typeNumber < 0 || typeNumber > toolTypes.Count)
                            {
                                Console.WriteLine("\nInvalid input, try again:");
                                selectType = Console.ReadLine();
                            }
                            // 5 Display all the tools of the selected tool type
                            index = 0;
                            List<iTool> tools = new List<iTool>();
                            Console.WriteLine("\nTools:");
                            foreach (iToolImpl tool in iToolLibrarySystem.iToolCollection.toArray())
                            {
                                if (tool.type.Equals(toolTypes.ToArray()[typeNumber]))
                                {
                                    Console.WriteLine(index + ":" + tool.Name);
                                    index++;
                                    tools.Add(tool);
                                }
                            }
                            // 6 Select a tool from the tool list
                            Console.WriteLine("\nNow enter the number of tool:");
                            string selectTool = Console.ReadLine();
                            int toolNumber;
                            while (!int.TryParse(selectTool, out toolNumber) ||
                                toolNumber < 0 || toolNumber > tools.Count)
                            {
                                Console.WriteLine("\nInvalid input, try again:");
                                selectTool = Console.ReadLine();
                            }
                            iTool selectedTool = tools.ToArray()[toolNumber];
                            // 7 Input the number of pieces of the tool to be removed
                            Console.WriteLine("\nCurrent quantity of tool:" + selectedTool.Quantity);
                            Console.WriteLine("Now enter the quantity that you want to remove from this tool:");
                            string removeQuantity = Console.ReadLine();
                            int removeQuantityNumber;
                            while (!int.TryParse(removeQuantity, out removeQuantityNumber) || removeQuantityNumber < 1)
                            {
                                Console.WriteLine("\nInvalid input, try again:");
                                removeQuantity = Console.ReadLine();
                            }
                            // 8 If the number of pieces of the tool is not more than the number of pieces that are currently in the library, reduce the total quantity and the available quantity of the tool
                            if (selectedTool.AvailableQuantity >= removeQuantityNumber)
                            {
                                iToolLibrarySystem.delete(selectedTool, removeQuantityNumber);
                                Console.WriteLine("\nNow new quantity of tool:" + selectedTool.Quantity);
                            }
                            else
                            {
                                Console.WriteLine("\nThis tool does not have enough available quantity remained in the library, remove failed!");
                            }
                        }
                        break;
                    case 4:
                        {
                            /*
                             Register a new member
                            */
                            iMember newMember = new iMemberImpl();
                            Console.WriteLine("\nPlease input the first name of the new member:");
                            newMember.FirstName = Console.ReadLine();
                            Console.WriteLine("\nPlease input the last name of the new member:");
                            newMember.LastName = Console.ReadLine();
                            Console.WriteLine("\nPlease input the PIN of the new member:");
                            newMember.PIN = Console.ReadLine();
                            Console.WriteLine("\nPlease input the contract number of the new member:");
                            newMember.ContactNumber = Console.ReadLine();
                            iToolLibrarySystem.iMembers.add(newMember);
                            Console.WriteLine("\nNow this new member is added to the system.");
                        }
                        break;
                    case 5:
                        {
                            /*
                            Remove a member
                            */
                            Console.WriteLine("\nPlease input the first name of the member:");
                            string FirstName = Console.ReadLine();
                            Console.WriteLine("\nPlease input the last name of new member:");
                            string LastName = Console.ReadLine();
                            bool temp = false;
                            foreach (iMember member in iToolLibrarySystem.iMembers.toArray())
                            {
                                if (member.FirstName.Equals(FirstName) && member.LastName.Equals(LastName))
                                {
                                    iToolLibrarySystem.iMembers.delete(member);
                                    Console.WriteLine("\nThis member is now successfully deleted!");
                                    temp = true;
                                }
                            }
                            if (!temp) Console.WriteLine("\n Failed to delete this member, member not found!");
                        }
                        break;
                    case 6:
                        {
                            /*
                              Find the contract number of a member
                            */
                            Console.WriteLine("\nPlease input the first name of the member:");
                            string FirstName = Console.ReadLine();
                            Console.WriteLine("\nPlease input the last name of new member:");
                            string LastName = Console.ReadLine();

                            string contactNumber = null;

                            foreach (iMember member in iToolLibrarySystem.iMembers.toArray())
                            {
                                if (member.FirstName.Equals(FirstName) && member.LastName.Equals(LastName))
                                {
                                    contactNumber = member.ContactNumber;
                                }
                            }
                            if (contactNumber != null)
                                Console.WriteLine("\nThe contract number is:" + contactNumber);
                            else
                                Console.WriteLine("\nUser not exist!");

                        }
                        break;
                    default: return;
                }

            } while (true);

        }
        //Console.WriteLine("");
        private static void memberMenu(iToolLibrarySystemImpl iToolLibrarySystem)
        {

            // 1 ID verify
            Console.Clear();
            string FirstName, LastName;
            string PIN;
            iMember thisMember = null;
            Console.WriteLine("Please enter your FirstName:");
            FirstName = Console.ReadLine();
            Console.WriteLine("Please enter your LastName:");
            LastName = Console.ReadLine();
            Console.WriteLine("Please enter your PIN:");
            PIN = Console.ReadLine();

            foreach (iMember member in iToolLibrarySystem.iMembers.toArray())
            {
                if (member.FirstName == FirstName && member.LastName == LastName && member.PIN == PIN)
                {
                    thisMember = member;
                    break;
                }
            }
            if (thisMember == null)
            {
                Console.WriteLine("Invalid name or PIN, press any key to return to main menu!");
                Console.ReadKey();
                return;
            }

            // 2 get user command from menu.
            Console.Clear();
            do
            {
                Console.WriteLine("\nWelcome to the Tool Library");
                Console.WriteLine("==========Member Menu==========");
                Console.WriteLine("1. Display all the tools of a tool type");
                Console.WriteLine("2. Borrow a tool");
                Console.WriteLine("3. Return a tool");
                Console.WriteLine("4. List all the tools that i am renting");
                Console.WriteLine("5. Display top three (3) most frequently rented tools");
                Console.WriteLine("0. Return to main menu");
                Console.WriteLine("===============================\n");
                Console.WriteLine("Please make a selection (1-5, or 0 to exit):");

                string input = Console.ReadLine();
                int key;
                while (!int.TryParse(input, out key) ||
                    key < 0 || key > 5)
                {
                    Console.WriteLine("\nInvalid input, try again:");
                    input = Console.ReadLine();
                }
                switch (key)
                {
                    case 0: return;
                    case 1:
                        {
                            // 1 Display all the nine (9) tool categories
                            Console.WriteLine("\nAll tool categories:");
                            int index;
                            for (index = 0; index < 9; index++)
                            {
                                Console.WriteLine(index + ":" + categories[index]);
                            }
                            // 2 Select a category
                            Console.WriteLine("\nNow enter the number of category that the tool belongs to:");
                            string selectCategory = Console.ReadLine();
                            int categoryNumber;
                            while (!int.TryParse(selectCategory, out categoryNumber) ||
                                categoryNumber < 0 || categoryNumber > 8)
                            {
                                Console.WriteLine("\nInvalid input, try again:");
                                selectCategory = Console.ReadLine();
                            }

                            // 3 Display all the tool types of the selected tool category
                            Console.WriteLine("\nAll tools under this type are displayed as following:");
                            List<string> toolTypes = new List<string>();
                            index = 0;
                            foreach (iToolImpl tool in iToolLibrarySystem.iToolCollection.toArray())
                            {
                                if (tool.category.Equals(categories[categoryNumber]) && !toolTypes.Contains(tool.type))
                                {
                                    toolTypes.Add(tool.type);
                                    Console.WriteLine(index + ":" + tool.type);
                                    index++;
                                }
                            }
                            if (toolTypes.Count == 0)
                            {
                                Console.WriteLine("There is no tool under this category");
                                Console.ReadKey();
                                break;
                            }
                            // 4 Select a tool type
                            Console.WriteLine("\nNow enter the number of tool type:");
                            string selectType = Console.ReadLine();
                            int typeNumber;
                            while (!int.TryParse(selectType, out typeNumber) ||
                                typeNumber < 0 || typeNumber > toolTypes.Count)
                            {
                                Console.WriteLine("\nInvalid input, try again:");
                                selectType = Console.ReadLine();
                            }

                            // Console.WriteLine("\nnow enter a tool type that you want to look for:");
                            // string aToolType=Console.ReadLine();
                            iToolLibrarySystem.displayTools(toolTypes.ToArray()[typeNumber]);
                        }
                        break;
                    case 2:
                        {
                            //Borrow a tool from the tool library, given the name of the tool, if the tool is available in the tool library
                            Console.WriteLine("\nNow enter a tool name that you want to borrow:");
                            string toolName = Console.ReadLine();
                            // search the tool by the name from toolcollection
                            bool found = false;
                            foreach (iTool tool in iToolLibrarySystem.iToolCollection.toArray())
                            {
                                if (tool.Name == toolName)
                                {
                                    // find the tool, start procedding
                                    iToolLibrarySystem.borrowTool(thisMember, tool);
                                    found = true;
                                    break;
                                }
                            }
                            if (!found) Console.WriteLine("Borrow Failed!");
                        }
                        break;
                    case 3:
                        {
                            //return a tool from the tool library, given the name of the tool
                            Console.WriteLine("\nNow enter a tool name that you want to return:");
                            string toolName = Console.ReadLine();
                            // search the tool by the name from toolcollection
                            bool found = false;
                            foreach (iTool tool in iToolLibrarySystem.iToolCollection.toArray())
                            {
                                if (tool.Name == toolName)
                                {
                                    // find the tool, start procedding
                                    iToolLibrarySystem.returnTool(thisMember, tool);
                                    found = true;
                                    break;
                                }
                            }
                            if (!found) Console.WriteLine("Borrow Failed!");
                        }
                        break;
                    case 4:
                        {
                            //List all the tools that are currently holding by the member
                            Console.WriteLine("\nAll tools you are borrowing is listed as follow:");
                            foreach (string toolName in iToolLibrarySystem.listTools(thisMember))
                                Console.WriteLine(toolName);
                            if (iToolLibrarySystem.listTools(thisMember).Length == 0) Console.WriteLine("you have not rent anything");
                            Console.WriteLine();
                        }
                        break;
                    case 5:
                        {
                            // Display top three most frequently borrowed tools by all the 
                            // members in the descending order by the number of times the 
                            // tool has been borrowed. The display should include the name 
                            // of the tool and the number of times that the tool has been 
                            // borrowed by now.
                            iToolLibrarySystem.displayTopTHree();
                        }
                        break;
                    default: return;
                }

            } while (true);
        }

        // constants
        private static string[] categories ={
            "Gardening Tools",
            "Flooring Tools",
            "Fencing Tools",
            "Measuring Tools",
            "Cleaning Tools",
            "Painting Tools",
            "Electronic Tools",
            "Electricity Tools",
            "Automotive Tools"
        };
    }
}
