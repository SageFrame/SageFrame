﻿#region "Copyright"

/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/

#endregion

#region "References"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using SageFrame.ProfileManagement;

#endregion


namespace SageFrame.Profile
{
    [Serializable()]
    public class ProfilePropertyDefinitionCollection : System.Collections.CollectionBase
    {


        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Constructs a new default collection
        /// </summary>
        /// <history>
        ///    [alok]    03/25/2010    created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ProfilePropertyDefinitionCollection()
        {
        }

        public ProfilePropertyDefinitionCollection(ArrayList definitionsList)
        {
            AddRange(definitionsList);
        }

        public ProfilePropertyDefinitionCollection(ProfilePropertyDefinitionCollection collection)
        {
            AddRange(collection);
        }


        public int Add(ProfileManagementInfo value)
        {
            return List.Add(value);
        }
        public ProfilePropertyDefinitionCollection GetByCategory(string PropertyTypeName)
        {
            ProfilePropertyDefinitionCollection collection = new ProfilePropertyDefinitionCollection();
            foreach (ProfileManagementInfo profileProperty in InnerList)
            {
                if ((profileProperty.PropertyTypeName == PropertyTypeName))
                {
                    // Found Profile property that satisfies category
                    collection.Add(profileProperty);
                }
            }
            return collection;
        }
        public void AddRange(ArrayList definitionsList)
        {
            foreach (ProfileManagementInfo objProfilePropertyDefinition in definitionsList)
            {
                Add(objProfilePropertyDefinition);
            }
        }

        public void AddRange(ProfilePropertyDefinitionCollection collection)
        {
            foreach (ProfileManagementInfo objProfilePropertyDefinition in collection)
            {
                Add(objProfilePropertyDefinition);
            }
        }
        public ProfileManagementInfo this[int index]
        {
            get
            {
                return ((ProfileManagementInfo)(List[index]));
            }
            set
            {
                List[index] = value;
            }
        }

        public ProfileManagementInfo this[string name]
        {
            get
            {
                return GetByName(name);
            }
        }
        public ProfileManagementInfo GetByName(string name)
        {
            ProfileManagementInfo profileItem = null;
            foreach (ProfileManagementInfo profileProperty in InnerList)
            {
                if ((profileProperty.Name == name))
                {
                    // Found Profile property
                    profileItem = profileProperty;
                }
            }
            return profileItem;
        }

        public bool Contains(ProfileManagementInfo value)
        {
            return List.Contains(value);
        }

        public ProfileManagementInfo GetById(int id)
        {
            ProfileManagementInfo profileItem = null;
            foreach (ProfileManagementInfo profileProperty in InnerList)
            {
                if ((profileProperty.ProfileID == id))
                {
                    // Found Profile property
                    profileItem = profileProperty;
                }
            }
            return profileItem;
        }



        public int IndexOf(ProfileManagementInfo value)
        {
            return List.IndexOf(value);
        }

        public void Insert(int index, ProfileManagementInfo value)
        {
            List.Insert(index, value);
        }

        public void Remove(ProfileManagementInfo value)
        {
            List.Remove(value);
        }

        public void Sort()
        {
            InnerList.Sort(new ProfilePropertyDefinitionComparer());
        }


    }
}
