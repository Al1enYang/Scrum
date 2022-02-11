using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment
{
    class iToolLibrarySystemImpl : iToolLibrarySystem
    {
        public void add(iTool aTool)
        {
            iToolCollection.add(aTool);
        } // add a new tool to the system

        public void add(iTool aTool, int quantity)
        {
            aTool.Quantity += quantity;
            aTool.AvailableQuantity += quantity;
        } //add new pieces of an existing tool to the system

        public void delete(iTool aTool)
        {
            iToolCollection.delete(aTool);
        } //delte a given tool from the system

        public void delete(iTool aTool, int quantity)
        {
            aTool.Quantity -= quantity;
            aTool.AvailableQuantity -= quantity;
        } //remove some pieces of a tool from the system

        public void add(iMember aMember)
        {
            iMembers.add(aMember);
        } //add a new memeber to the system

        public void delete(iMember aMember)
        {
            iMembers.delete(aMember);
        } //delete a member from the system

        public void displayBorrowingTools(iMember aMember)
        {
            foreach (string toolName in aMember.Tools)
            {
                Console.WriteLine(toolName);
            }
        } //given a member, display all the tools that the member are currently renting


        public void displayTools(string aToolType)
        {
            Console.WriteLine();
            int Count = 0;
            foreach (iToolImpl tool in iToolCollection.toArray())
            {
                if (tool.type == aToolType)
                {
                    //Console.WriteLine(tool.ToString());
                    Console.WriteLine("Tool name:" + tool.Name + "\tAvailable number:" + tool.AvailableQuantity);
                    Count++;
                }
            }
            if (Count == 0) Console.WriteLine("No tool is under this type.");
            Console.WriteLine();
        } // display all the tools of a tool type selected by a member

        public void borrowTool(iMember aMember, iTool aTool)
        {
            if (iToolCollection.search(aTool) && aTool.AvailableQuantity > 0 && iMembers.search(aMember))
            {
                aMember.addTool(aTool);
                aTool.addBorrower(aMember);
                Console.WriteLine("\nSuccessfully Borrowed!");
            }
            else
            {
                Console.WriteLine("\nBorrow Failed!");
            }
        } //a member borrows a tool from the tool library

        public void returnTool(iMember aMember, iTool aTool)
        {
            if (iToolCollection.search(aTool) && aTool.GetBorrowers.search(aMember))
            {
                aMember.deleteTool(aTool);
                aTool.deleteBorrower(aMember);
                Console.WriteLine("Successfully Returned!");
            }
            else
            {
                Console.WriteLine("Return Failed!");
            }
        } //a member return a tool to the tool library

        public string[] listTools(iMember aMember)
        {
            return aMember.Tools;
        } //get a list of tools that are currently held by a given member

        public void displayTopTHree()
        {
            List<string> topThreeTools = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                iTool topTool = null;
                foreach (iTool tool in iToolCollection.toArray())
                {
                    if ((topTool == null || (topTool.Quantity - topTool.AvailableQuantity) < (tool.Quantity - tool.AvailableQuantity)) && !topThreeTools.Contains(tool.Name))
                    {
                        topTool = tool;
                    }
                }
                topThreeTools.Add(topTool.Name);
            }
            Console.WriteLine("\n Tool names are listed:");
            foreach (string toolName in topThreeTools)
                Console.WriteLine(toolName);
        } 
        //Display top three most frequently borrowed tools by the members in the descending order by the number of times each tool has been borrowed.
        //---------------------------------------------------------------------------
        public iToolCollection iToolCollection = new iToolCollectionImpl();
        public iMemberCollection iMembers = new iMemberCollectionImpl();
    }
}