﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Interfaces;

namespace Circle.Repositories.User
{
    public interface IUserRepository
    {
        /// <summary>
        /// ログインIDでユーザを検索する
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IUser FindById(string id);

        /// <summary>
        /// 新規ユーザを作成する
        /// </summary>
        /// <param name="properties"></param>
        /// <returns></returns>
        Task<IUser> CreateAsync(UserProperties properties);
    }
}
