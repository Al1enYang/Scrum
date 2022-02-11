/*
This class is used to save a group of users borrow 
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment
{

    class iMemberCollectionImpl : iMemberCollection{
        public int Number // get the number of members in the community library
        {
            get;
        }

        public void add(iMember aMember){
            if(members.Contains(aMember)) return;
            members.Add(aMember);
        } //add a new member to this member collection, make sure there are no duplicates in the member collection

        public void delete(iMember aMember){
            // if(!members.Contains(aMember)) return;
            members.Remove(aMember);
        } //delete a given member from this member collection, a member can be deleted only when the member currently is not holding any tool

        public Boolean search(iMember aMember){
            return members.Contains(aMember);
        } //search a given member in this member collection. Return true if this memeber is in the member collection; return false otherwise.

        public iMember[] toArray(){
            return members.ToArray();
        } //output the memebers in this collection to an array of iMember

        private List<iMember> members=new List<iMember>();
    }
    //The specification of MemberCollection ADT, which is used to store and manipulate a collection of members
    
    class iMemberCollectionImpl1 : iMemberCollection{
        public int Number // get the number of members in the community library
        {
            get;
        }

        public void add(iMember aMember){
            BinaryMemberSearchTree currentNode=root;
            while(currentNode!=null){
                if(currentNode.Compare(aMember)){
                    //true, target is smaller, put it to left
                    if(currentNode.leftChild==null) break;
                    else{
                        currentNode = currentNode.leftChild;
                        continue;
                    }
                }else{
                    //false, target is greater, put it to right
                    if(currentNode.rightChild==null) break;
                    else{
                        currentNode = currentNode.rightChild;
                        continue;
                    }
                }
            }
            currentNode=new BinaryMemberSearchTree(aMember);
        } //add a new member to this member collection, make sure there are no duplicates in the member collection

        public void delete(iMember aMember){
            // memberCollection.Remove(aMember);
            if(aMember.Tools.Length==0) return;

            BinaryMemberSearchTree fatherNode = null;
            BinaryMemberSearchTree currentNode = root;
            Queue<BinaryMemberSearchTree> q = new Queue<BinaryMemberSearchTree>();
            for(;!currentNode.node.Equals(aMember);){
                currentNode = currentNode.Compare(aMember)?(currentNode.leftChild):(currentNode.rightChild);
            }

        } //delete a given member from this member collection, a member can be deleted only when the member currently is not holding any tool

        public Boolean search(iMember aMember){
            for(BinaryMemberSearchTree currentNode = root;!currentNode.node.Equals(aMember);){
                currentNode = currentNode.Compare(aMember)?(currentNode.leftChild):(currentNode.rightChild);
                if(currentNode==null) return false;
            }
            return true;
        } //search a given member in this member collection. Return true if this memeber is in the member collection; return false otherwise.

        public iMember[] toArray(){
            List<iMember> iMembers = new List<iMember>();
            Queue<BinaryMemberSearchTree> q = new Queue<BinaryMemberSearchTree>();
            
            // BFS
            for(BinaryMemberSearchTree currentNode = root;currentNode!=null;currentNode=q.Dequeue()){
                if(currentNode.leftChild!=null) q.Enqueue(currentNode.leftChild);
                if(currentNode.rightChild!=null) q.Enqueue(currentNode.rightChild);
                iMembers.Add(currentNode.node);
            }
            return iMembers.ToArray();
        } //output the memebers in this collection to an array of iMember

        // -----------------------------------------------------------------------------------------------------------
        /*
            A private binary tree structure used to store members. All members will be stored as nodes in the tree.
            Each node is individually connected to each other. Each node has two sub nodes connected whereas it cannot call back to its father node.
            Root node will be initialized by an example member provided in the powerpoint and stored as a variable outside of this class.
            All related methods are implemented following by this class right in this page, including a binary search algorithm.
        */
        private class BinaryMemberSearchTree{
            public iMember node{get;set;}
            public BinaryMemberSearchTree leftChild{get;set;}
            public BinaryMemberSearchTree rightChild{get;set;}
            public BinaryMemberSearchTree(iMember node){
                this.node = node;
            }
            /*
                compare this member with others by FirstName
                return 
                    -true: this one is greater
                    -false: target is greater
            */
            public Boolean Compare(BinaryMemberSearchTree target){
                if(this.node.FirstName.CompareTo(target.node.FirstName)>=0){
                    return true;
                }else{
                    return false;
                }
            }
            public Boolean Compare(iMember target){
                if(this.node.FirstName.CompareTo(target.FirstName)>=0){
                    return true;
                }else{
                    return false;
                }
            }
        }
        private BinaryMemberSearchTree root = null;
        /*
            a searching algorithm based on tree structure
            return: 
                -true: find the target
                -false: does dot find it
        */
        private Boolean BinarySearch(iMember target){
            BinaryMemberSearchTree currentNode = root;
            while(currentNode != null){
                if(currentNode.Equals(target)) return true;
                else{
                    if(currentNode.Compare(target)){
                        //true, target is smaller, turn to left
                        currentNode = currentNode.leftChild;
                    }else{
                        //false, target is greater, turn to right
                        currentNode = currentNode.rightChild;
                    }
                }
            }
            return false;
            
        }
    }
}