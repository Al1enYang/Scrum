using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment{
    class iToolImpl :iTool{
        public string Name // get and set the name of this tool
        {
            get;
            set;
        }

        public int Quantity //get and set the quantity of this tool
        {
            get;
            set;
        }

        public int AvailableQuantity //get and set the quantity of this tool currently available to lend
        {
            get;
            set;
        }

        public int NoBorrowings //get and set the number of times that this tool has been borrowed
        {
            get;
            set;
        }

        public iMemberCollection GetBorrowers  //get all the members who are currently holding this tool
        {
            get{
                iMemberCollection iMembers = new iMemberCollectionImpl();
                foreach(iMember member in borrowerList){
                    iMembers.add(member);
                }
                return iMembers;
            }
        }

        public void addBorrower(iMember aMember){
            this.AvailableQuantity-=1;
            this.borrowerList.Add(aMember);
        } //add a member to the borrower list

        public void deleteBorrower(iMember aMember){
            this.AvailableQuantity+=1;
            this.borrowerList.Remove(aMember);
        } //delte a member from the borrower list

        public override string ToString(){
            return this.Name + '\t' + 
                this.AvailableQuantity;
        } //return a string containning the name and the available quantity quantity this tool 
//---------------------------------------------------------------------------------------------------------------
        private List<iMember> borrowerList = new List<iMember>();
        public string type{set;get;}
        public string category{set;get;}
    }
}