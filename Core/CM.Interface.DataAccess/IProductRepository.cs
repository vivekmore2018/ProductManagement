﻿using CM.Models;
using System.Collections.Generic;

namespace CM.Interface.DataAccess
{
    public interface IProductRepository
    {
        /// <summary>
        /// Get all contacts
        /// </summary>
        /// <returns>List of contact model</returns>
        IEnumerable<Product> GetAll();
        /// <summary>
        /// Get Single contact by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>return single contact</returns>
        Product GetById(int id);
        /// <summary>
        /// Update existing contact
        /// </summary>
        /// <param name="contact"></param>
        /// <returns>return rowaffected</returns>
        int Update(Product contact);
        /// <summary>
        /// Change status of contact
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns>return rowaffected</returns>
        int ChangeStatus(int id, bool status);
        /// <summary>
        /// Add new contact to database
        /// </summary>
        /// <param name="contact">New contact object</param>
        /// <returns>return newly added id</returns>
        int AddProduct(Product contact);
        /// <summary>
        /// Delete contact from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>return rowaffected</returns>
        int DeleteContact(int id);
    }
}
