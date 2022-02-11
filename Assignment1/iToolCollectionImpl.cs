using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment
{
    //The specification of ToolCollection ADT, which is used to store and manipulate a collection of tools
    class iToolCollectionImpl:iToolCollection
    {
        public int Number // get the number of the types of tools in the community library
        {
            get{
                List<string> types = new List<string>();
                foreach(iToolImpl tool in iToolList){
                    if(types.Contains(tool.type)) continue;
                    else types.Add(tool.type);
                }
                return types.Count;
            }
        }
        public void add(iTool aTool){
            this.iToolList.Add(aTool);
        } //add a given tool to this tool collection
        public void delete(iTool aTool){
            this.iToolList.Remove(aTool);
        } //delete a given tool from this tool collection
        public Boolean search(iTool aTool){
            return this.iToolList.Contains(aTool);
        } //search a given tool in this tool collection. Return true if this tool is in the tool collection; return false otherwise
        public iTool[] toArray(){
            return this.iToolList.ToArray();
        } // output the tools in this tool collection to an array of iTool
        private List<iTool> iToolList = new List<iTool>();
    }
}