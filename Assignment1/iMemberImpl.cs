using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment
{
    class iMemberImpl :　iMember{
        public string FirstName  //get and set the first name of this member
        {
            get;
            set;
        }
        public string LastName //get and set the last name of this member
        {
            get;
            set;
        }

        public string ContactNumber //get and set the contact number of this member
        {
            get;
            set;
        }

        public string PIN //get and set the password of this member
        {
            get;
            set;
        }

        public string[] Tools //get a list of tools that this memebr is currently holding
        {
            get{
                string[] results = new string[this.ToolList.Count];
                int index=0;
                foreach(iTool tool in  this.ToolList.ToArray()){
                    results[index] = tool.Name;
                    index++;
                }
                return results;
            }
        }
        public void addTool(iTool aTool){
            this.ToolList.Add(aTool);
        }

        public void deleteTool(iTool aTool){
            this.ToolList.Remove(aTool);
        }

        public override string ToString(){
            return this.FirstName + '\t' + 
                this.LastName + '\t' + 
                this.ContactNumber;
        }

        private List<iTool> ToolList = new List<iTool>();
    }
}