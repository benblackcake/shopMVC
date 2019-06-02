﻿using MVCtest.Controllers;
using MVCtest.Models;
using MVCtest.Repository;
using MVCtest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCtest.Service
{
    public class MasterService
    {
        public MasterViewModel GetMember(string account, string password)
        {

            DBModel context = new DBModel();
            DbRepository<Master> repo = new DbRepository<Master>(context);

            string pwd = Helper.EncodePassword(password);
            Master entity = repo.GetAll().FirstOrDefault((x) => x.master_account == account & x.master_password == pwd);

            if (entity != null)
            {
                MasterViewModel cvm = new MasterViewModel()
                {
                    master_id = entity.master_id,
                    master_account = entity.master_account,
                    master_password = entity.master_password

                };
                return cvm;
            }
            else return null;

        }
        public MasterListViewModel GetAllMaster()
        {
            MasterListViewModel result = new MasterListViewModel();
            result.data = new List<MasterViewModel>();
            DBModel context = new DBModel();
            DbRepository<Master> repo = new DbRepository<Master>(context);
            foreach (var item in repo.GetAll().OrderBy((x) => x.master_id))
            {
                MasterViewModel m = new MasterViewModel()
                {
                    master_id = item.master_id,
                    master_account = item.master_account,
                    master_password = item.master_password,
                    

                };
                result.data.Add(m);
            }
            return result;

        }

    }
}